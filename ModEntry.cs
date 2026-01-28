using HarmonyLib;
using Microsoft.Extensions.Logging;
using Nanoray.PluginManager;
using Nickel;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TeraTaxMod.Artifacts;
using TeraTaxMod.Cards;
using TeraTaxMod.Dialogue;


//using TeraTaxMod.Actions;
//using TeraTaxMod.Artifacts;
using TeraTaxMod.External;
using TeraTaxMod.Features;

namespace TeraTaxMod;

internal class ModEntry : SimpleMod
{
    internal static ModEntry Instance { get; private set; } = null!;
    internal Harmony Harmony { get; }
    internal IKokoroApi.IV2 KokoroApi { get; }

    public LocalDB localDB { get; set; } = null!;  // For dialogue machine

    internal IPlayableCharacterEntryV2 TeraCharacter {get;}
    //Note: this IPlayableCharacterEntryV2 was originally in the helper.content function. I changed code
    //to try and get the "ismissing" status to work. Let's hope I did this right. If it breaks, remove
    //this from internal and add it back to the helper.content function.
    internal IDeckEntry TeraTaxDeck { get; }
    internal IStatusEntry TeraPersistenceStatus { get; }
    internal IStatusEntry TeraTaxationStatus { get; }
    internal IStatusEntry TeraStallNextStatus { get; }
    internal IStatusEntry TeraLockNextStatus { get; }
    internal IStatusEntry TeraBailoutStatus { get; }
    internal ILocalizationProvider<IReadOnlyList<string>> AnyLocalizations { get; }
    internal ILocaleBoundNonNullLocalizationProvider<IReadOnlyList<string>> Localizations { get; }

    /*
     * The following lists contain references to all types that will be registered to the game.
     * All cards and artifacts must be registered before they may be used in the game.
     * In theory only one collection could be used, containing all registrable types, but it is seperated this way for ease of organization.
     */
    private static List<Type> TeraTaxCommonCardTypes = [
        typeof(Tariff),
        typeof(EggToss),
        typeof(TaxEvasion),
        typeof(Taunt),
        typeof(TaxingEscape),
        typeof(NumberCrunching),
        typeof(FrenziedGetaway),
        typeof(SalesTax),
        typeof(SpareCash)
    ];
    private static List<Type> TeraTaxUncommonCardTypes = [
        typeof(MarketCrash),
        typeof(HealthInsurance),
        typeof(TaxHike),
        typeof(TaxExemption),
        typeof(AllIn),
        typeof(Overdraft),
        typeof(Siphon)
    ];
    private static List<Type> TeraTaxRareCardTypes = [
        typeof(Persistence),
        typeof(Desperation),
        typeof(Forgiveness),
        typeof(Tenacity),
        typeof(Breakout)
    ];
    private static List<Type> TeraTaxSpecialCardTypes = [
        typeof(EggShells),
        typeof(SpareCash),
        typeof(GetsTheWorm),
        typeof(Payment),
        
    ];
    private static IEnumerable<Type> TeraTaxCardTypes =
        TeraTaxCommonCardTypes
            .Concat(TeraTaxUncommonCardTypes)
            .Concat(TeraTaxRareCardTypes)
            .Concat(TeraTaxSpecialCardTypes);

    private static List<Type> TeraTaxCommonArtifacts = [
       typeof(EarlyBird),
       typeof(YearlyPayments),
       typeof(GovernmentGrant),
       typeof(FlightTraining),
    ];
    private static List<Type> TeraTaxBossArtifacts = [
        typeof(Capitalism),
        typeof(Inflation)
    ];

    private static List<Type> TeraTaxDialogueTypes = [
        typeof(TauntDialogue),
   ];

    private static IEnumerable<Type> TeraTaxArtifactTypes =
        TeraTaxCommonArtifacts
            .Concat(TeraTaxBossArtifacts);

    private static IEnumerable<Type> AllRegisterableTypes =
        TeraTaxCardTypes
            .Concat(TeraTaxArtifactTypes)
            .Concat(TeraTaxDialogueTypes);

    //private static List<Type> TeraCharacterEXETypes = [
        //typeof(TeraCatEXE) - DON'T FORGET TO ADD THIS

   

    public ModEntry(IPluginPackage<IModManifest> package, IModHelper helper, ILogger logger) : base(package, helper, logger)
    {
        Instance = this;
        Harmony = new Harmony("rft.TeraTaxMod");
        
        /*
         * Some mods provide an API, which can be requested from the ModRegistry.
         * The following is an example of a required dependency - the code would have unexpected errors if Kokoro was not present.
         * Dependencies can (and should) be defined within the nickel.json file, to ensure proper load mod load order.
         */
        KokoroApi = helper.ModRegistry.GetApi<IKokoroApi>("Shockah.Kokoro")!.V2;

        AnyLocalizations = new JsonLocalizationProvider(
            tokenExtractor: new SimpleLocalizationTokenExtractor(),
            localeStreamFunction: locale => package.PackageRoot.GetRelativeFile($"i18n/{locale}.json").OpenRead()
        );
        Localizations = new MissingPlaceholderLocalizationProvider<IReadOnlyList<string>>(
            new CurrentLocaleOrEnglishLocalizationProvider<IReadOnlyList<string>>(AnyLocalizations)
        );


        // The following two are used for the dialogue machine
        helper.Events.OnModLoadPhaseFinished += (_, phase) =>
        {
            if (phase == ModLoadPhase.AfterDbInit)
            {
                localDB = new(helper, package);
            }
        };
        helper.Events.OnLoadStringsForLocale += (_, thing) =>
        {
            foreach (KeyValuePair<string, string> entry in localDB.GetLocalizationResults(thing.Locale))
            {
                thing.Localizations[entry.Key] = entry.Value;
            }
        };

        /*
         * A deck only defines how cards should be grouped, for things such as codex sorting and Second Opinions.
         * A character must be defined with a deck to allow the cards to be obtainable as a character's cards.
         */
        TeraTaxDeck = helper.Content.Decks.RegisterDeck("Tera", new DeckConfiguration
        {
            Definition = new DeckDef
            {
                /*
                 * This color is used in a few places:
                 * TODO On cards, it dictates the sheen on higher rarities, as well as influences the color of the energy cost.
                 * If this deck is given to a playable character, their name will be this color, and their mini will have this color as their border.
                 */
                color = new Color("266fd8"),

                titleColor = new Color("000000")
            },

            DefaultCardArt = StableSpr.cards_colorless,
            BorderSprite = RegisterSprite(package, "assets/Animation/border_tera.png").Sprite,
            Name = AnyLocalizations.Bind(["character", "name"]).Localize
        });

        /*
         * All the IRegisterable types placed into the static lists at the start of the class are initialized here.
         * This snippet invokes all of them, allowing them to register themselves with the package and helper.
         */
        foreach (var type in AllRegisterableTypes)
            AccessTools.DeclaredMethod(type, nameof(IRegisterable.Register))?.Invoke(null, [package, helper]);
        
        /*
         * Characters have required animations, recommended animations, and you have the option to add more.
         * In addition, they must be registered before the character themselves is registered.
         * The game requires you to have a neutral animation and mini animation, used for normal gameplay and the map and run start screen, respectively.
         * The game uses the squint animation for the Extra-Planar Being and High-Pitched Static events, and the gameover animation while you are dying.
         * You may define any other animations, and they will only be used when explicitly referenced (such as dialogue).
         */
      
      
        Instance.Helper.Content.Characters.V2.RegisterCharacterAnimation(new CharacterAnimationConfigurationV2
        {
            CharacterType = TeraTaxDeck.Deck.Key(),
            LoopTag = "gameover",
            Frames = [
                RegisterSprite(package, "assets/Animation/bird_GameOver_0.png").Sprite,
            ]
        });
        Instance.Helper.Content.Characters.V2.RegisterCharacterAnimation(new CharacterAnimationConfigurationV2
        {
            CharacterType = TeraTaxDeck.Deck.Key(),
            LoopTag = "mini",
            Frames = [
                RegisterSprite(package, "assets/Animation/bird_mini_0.png").Sprite,
            ]
        });

        TeraCharacter = helper.Content.Characters.V2.RegisterPlayableCharacter("Tera", new()
        {
            Deck = TeraTaxDeck.Deck,
            BorderSprite = RegisterSprite(package, "assets/Animation/panel_tera.png").Sprite,
            NeutralAnimation = new()
            {
                CharacterType = TeraTaxDeck.UniqueName,
                LoopTag = "neutral",
                Frames = Enumerable.Range(0, 4)
                    .Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Animation/NormalIdle/{i}.png")).Sprite)
                    .ToList()
            },

           
            Starters = new StarterDeck

            {
                cards = [
                   new Tariff(),
                   new TaxEvasion()
                ],
                /*
                 * Some characters have starting artifacts, in addition to starting cards.
                 * This is where they would be added, much like their starter cards.
                 * This can be safely removed if you have no starting artifacts.
                 */
                artifacts = [
                ]
            },
            Description = AnyLocalizations.Bind(["character", "desc"]).Localize
        });

        //Animation directory Below VVVVVVV
        helper.Content.Characters.V2.RegisterCharacterAnimation(new()
        {
            CharacterType = TeraTaxDeck.UniqueName,
            LoopTag = "squint",
            Frames = Enumerable.Range(0, 4)
                    .Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Animation/SquintIdle/{i}.png")).Sprite)
                    .ToList()
        });
        helper.Content.Characters.V2.RegisterCharacterAnimation(new()
        {
            CharacterType = TeraTaxDeck.UniqueName,
            LoopTag = "happy",
            Frames = Enumerable.Range(0, 4)
                .Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Animation/HappyIdle/{i}.png")).Sprite)
                .ToList()
        });
        helper.Content.Characters.V2.RegisterCharacterAnimation(new()
        {
            CharacterType = TeraTaxDeck.UniqueName,
            LoopTag = "closed",
            Frames = Enumerable.Range(0, 4)
                .Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Animation/ClosedIdle/{i}.png")).Sprite)
                .ToList()
        });
        helper.Content.Characters.V2.RegisterCharacterAnimation(new()
        {
            CharacterType = TeraTaxDeck.UniqueName,
            LoopTag = "lookaway",
            Frames = Enumerable.Range(0, 4)
               .Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Animation/LookAwayIdle/{i}.png")).Sprite)
               .ToList()
        });
        helper.Content.Characters.V2.RegisterCharacterAnimation(new()
        {
            CharacterType = TeraTaxDeck.UniqueName,
            LoopTag = "lookawaynervous",
            Frames = Enumerable.Range(0, 4)
               .Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Animation/LookAwayIdleNervous/{i}.png")).Sprite)
               .ToList()
        });
        helper.Content.Characters.V2.RegisterCharacterAnimation(new()
        {
            CharacterType = TeraTaxDeck.UniqueName,
            LoopTag = "sad",
            Frames = Enumerable.Range(0, 4)
               .Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Animation/SadIdle/{i}.png")).Sprite)
               .ToList()
        });
        helper.Content.Characters.V2.RegisterCharacterAnimation(new()
        {
            CharacterType = TeraTaxDeck.UniqueName,
            LoopTag = "scared",
            Frames = Enumerable.Range(0, 4)
               .Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Animation/ScaredIdle/{i}.png")).Sprite)
               .ToList()
        });
        helper.Content.Characters.V2.RegisterCharacterAnimation(new()
        {
            CharacterType = TeraTaxDeck.UniqueName,
            LoopTag = "taxes",
            Frames = Enumerable.Range(0, 4)
               .Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Animation/TaxesIdle/{i}.png")).Sprite)
               .ToList()
        });
        helper.Content.Characters.V2.RegisterCharacterAnimation(new()
        {
            CharacterType = TeraTaxDeck.UniqueName,
            LoopTag = "happytaxes",
            Frames = Enumerable.Range(0, 4)
               .Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Animation/TaxesHappyIdle/{i}.png")).Sprite)
               .ToList()
        });
        helper.Content.Characters.V2.RegisterCharacterAnimation(new()
        {
            CharacterType = TeraTaxDeck.UniqueName,
            LoopTag = "blush",
            Frames = Enumerable.Range(0, 4)
               .Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Animation/BlushIdle/{i}.png")).Sprite)
               .ToList()
        });





        /*
         * Statuses are used to achieve many mechanics.
         * However, statuses themselves do not contain any code - they just keep track of how much you have.
         */

        TeraTaxationStatus = helper.Content.Statuses.RegisterStatus("Tax", new StatusConfiguration
        {
            Definition = new StatusDef
            {
                isGood = false,
                affectedByTimestop = false,
                color = new Color("FF00FF"),
                icon = RegisterSprite(package, "assets/Feature/coin.png").Sprite
            },
            Name = AnyLocalizations.Bind(["status", "tax", "name"]).Localize,
            Description = AnyLocalizations.Bind(["status", "tax", "desc"]).Localize
        });
        TeraPersistenceStatus = helper.Content.Statuses.RegisterStatus("Persistence", new StatusConfiguration
        {
            Definition = new StatusDef
            {
                isGood = false,
                affectedByTimestop = false,
                color = new Color("FF00FF"),
                icon = RegisterSprite(package, "assets/Feature/taxes.png").Sprite
            },
            Name = AnyLocalizations.Bind(["status", "persistence", "name"]).Localize,
            Description = AnyLocalizations.Bind(["status", "persistence", "desc"]).Localize
        });
        TeraStallNextStatus = helper.Content.Statuses.RegisterStatus("StallNext", new StatusConfiguration
        {
            Definition = new StatusDef
            {
                isGood = false,
                affectedByTimestop = false,
                color = new Color("FF00FF"),
                icon = RegisterSprite(package, "assets/Feature/StallNext.png").Sprite
            },
            Name = AnyLocalizations.Bind(["status", "StallNext", "name"]).Localize,
            Description = AnyLocalizations.Bind(["status", "StallNext", "desc"]).Localize
        });
        TeraLockNextStatus = helper.Content.Statuses.RegisterStatus("LockNext", new StatusConfiguration
        {
            Definition = new StatusDef
            {
                isGood = false,
                affectedByTimestop = false,
                color = new Color("FF00FF"),
                icon = RegisterSprite(package, "assets/Feature/LockNext.png").Sprite
            },
            Name = AnyLocalizations.Bind(["status", "LockNext", "name"]).Localize,
            Description = AnyLocalizations.Bind(["status", "LockNext", "desc"]).Localize
        });
        TeraBailoutStatus = helper.Content.Statuses.RegisterStatus("Bailout", new StatusConfiguration
        {
            Definition = new StatusDef
            {
                isGood = true,
                affectedByTimestop = false,
                color = new Color("FFFFFF"),
                icon = RegisterSprite(package, "assets/Feature/Bailout.png").Sprite
            },
            Name = AnyLocalizations.Bind(["status", "Bailout", "name"]).Localize,
            Description = AnyLocalizations.Bind(["status", "Bailout", "desc"]).Localize
        });

        /*
         * Managers are typically made to register themselves when constructed.
         * _ = makes the compiler not complain about the fact that you are constructing something for seemingly no reason.
         */

        TeraTaxationManager taxationManager = new();
        KokoroApi.StatusLogic.RegisterHook(taxationManager);
        TeraPersistenceManager persistenceManager = new();
        KokoroApi.StatusLogic.RegisterHook(persistenceManager);
        TeraStallNextTurnManager stallNextManager = new();
        KokoroApi.StatusLogic.RegisterHook(stallNextManager);
        TeraLockNextTurnManager lockNextManager = new();
        KokoroApi.StatusLogic.RegisterHook(lockNextManager);
        TeraBailoutManager bailoutManager = new();
        KokoroApi.StatusLogic.RegisterHook(bailoutManager);


        /*
         * Some classes require so little management that a manager may not be worth writing.
         * In AGainPonder's case, it is simply a need for two sprites and evaluation of an artifact's effect.
         */

    }

    /*
     * assets must also be registered before they may be used.
     * Unlike cards and artifacts, however, they are very simple to register, and often do not need to be referenced in more than one place.
     * This utility method exists to easily register a sprite, but nothing prevents you from calling the method used yourself.
     */
    public static ISpriteEntry RegisterSprite(IPluginPackage<IModManifest> package, string dir)
    {
        return Instance.Helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile(dir));
    }

    /*
     * Animation frames are typically named very similarly, only differing by the number of the frame itself.
     * This utility method exists to easily register an animation.
     * It expects the animation to start at frame 0, up to frames - 1.
     * TODO It is advised to avoid animations consisting of 2 or 3 frames.
     */
    public static void RegisterAnimation(IPluginPackage<IModManifest> package, string tag, string dir, int frames)
    {
        Instance.Helper.Content.Characters.V2.RegisterCharacterAnimation(new CharacterAnimationConfigurationV2
        {
            CharacterType = Instance.TeraTaxDeck.Deck.Key(),
            LoopTag = tag,
            Frames = Enumerable.Range(0, frames)
                .Select(i => RegisterSprite(package, dir + i + ".png").Sprite)
                .ToImmutableList()
        });
    }
}

