
using HarmonyLib;
using Microsoft.Extensions.Logging;
using Nanoray.PluginManager;
using Nickel;
using Nickel.Common;
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

   

    internal static IPlayableCharacterEntryV2 TeraCharacter { get; private set; } = null!;

    internal ISpriteEntry TaxDroneCard { get; }
    internal ISpriteEntry TaxDroneMidrow { get; }
    internal IDeckEntry TeraTaxDeck { get; }
    internal IStatusEntry TeraPersistenceStatus { get; }
    internal IStatusEntry TeraTaxationStatus { get; }
    internal IStatusEntry TeraStallNextStatus { get; }
    internal IStatusEntry TeraLockNextStatus { get; }
    internal IStatusEntry TeraBailoutStatus { get; }
    internal IStatusEntry TeraDividendsStatus { get; }
    public LocalDB localDB { get; set; } = null!;  // For dialogue machine
    internal ILocalizationProvider<IReadOnlyList<string>> AnyLocalizations { get; }
    internal ILocaleBoundNonNullLocalizationProvider<IReadOnlyList<string>> Localizations { get; }
    

    
    private static List<Type> TeraTaxCommonCardTypes = [
        typeof(Tariff),
        typeof(EggToss),
        typeof(TaxEvasion),
        typeof(Taunt),
        typeof(TaxingEscape),
        typeof(NumberCrunching),
        typeof(FrenziedGetaway),
        typeof(SalesTax),
        typeof(Overdraft),
        typeof(Breakout)
    ];
    private static List<Type> TeraTaxUncommonCardTypes = [
        typeof(MarketCrash),
        typeof(HealthInsurance),
        typeof(TaxHike),
        typeof(TaxExemption),
        typeof(AllIn),
      
        typeof(SpareCash),
    ];
    private static List<Type> TeraTaxRareCardTypes = [
        typeof(Persistence),
        typeof(Desperation),
        typeof(Forgiveness),
        typeof(Tenacity),
        typeof(Siphon),
    ];
    private static List<Type> TeraTaxSpecialCardTypes = [
        typeof(EggShells),
        typeof(GetsTheWorm),
        typeof(TaxationDrone),
        
    ];
    private static List<Type> TeraEXECardTypes =
    [
        typeof(TeraCatEXE)
    ];
    private static IEnumerable<Type> TeraTaxCardTypes =
        TeraTaxCommonCardTypes
            .Concat(TeraTaxUncommonCardTypes)
            .Concat(TeraTaxRareCardTypes)
            .Concat(TeraTaxSpecialCardTypes)
            .Concat(TeraEXECardTypes);

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
    internal static List<Type> DuoArtifacts = [
        typeof(FireSale),
        typeof(MonetaryShock),
        typeof(WireTransfer),
        typeof(YearlyCycle),
        typeof(AssetLiquidation),
        typeof(Improvisation),
        typeof(Scrutiny),
    ];
    private static List<Type> TeraTaxDialogueTypes = [
        typeof(TauntDialogue),
        typeof(CardDialogue),
        typeof(CombatDialogue),
        typeof(EventDialogue),
        typeof(TeraZariDialogue)
   ];



    private static IEnumerable<Type> TeraTaxArtifactTypes =
        TeraTaxCommonArtifacts
            .Concat(TeraTaxBossArtifacts);


    private static IEnumerable<Type> AllRegisterableTypes =
        TeraTaxCardTypes
            .Concat(TeraTaxArtifactTypes)
            .Concat(TeraTaxDialogueTypes);

    internal static readonly IEnumerable<Type> LateRegisterableTypes
        = DuoArtifacts;




    public ModEntry(IPluginPackage<IModManifest> package, IModHelper helper, ILogger logger) : base(package, helper, logger)
    {
        Instance = this;
        Harmony = new Harmony("rft.TeraTaxMod");

        KokoroApi = helper.ModRegistry.GetApi<IKokoroApi>("Shockah.Kokoro")!.V2;

        AnyLocalizations = new JsonLocalizationProvider(
            tokenExtractor: new SimpleLocalizationTokenExtractor(),
            localeStreamFunction: locale => package.PackageRoot.GetRelativeFile($"i18n/{locale}.json").OpenRead()
        );
        Localizations = new MissingPlaceholderLocalizationProvider<IReadOnlyList<string>>(
            new CurrentLocaleOrEnglishLocalizationProvider<IReadOnlyList<string>>(AnyLocalizations)
        );


       


        TeraTaxDeck = helper.Content.Decks.RegisterDeck("Tera", new DeckConfiguration
        {
            Definition = new DeckDef
            {
      
                color = new Color("266fd8"),

                titleColor = new Color("000000")
            },

            DefaultCardArt = StableSpr.cards_colorless,
            BorderSprite = RegisterSprite(package, "assets/Animation/border_tera.png").Sprite,
            Name = AnyLocalizations.Bind(["character", "name"]).Localize

        });
        helper.ModRegistry.AwaitApi<IMoreDifficultiesApi>(
            "TheJazMaster.MoreDifficulties",
            new SemanticVersion(1, 3, 0),
            api => api.RegisterAltStarters(
                deck: TeraTaxDeck.Deck,
                starterDeck: new StarterDeck
                {
                    cards = [
                        new Overdraft(),
                        new TaxingEscape(),
                    ]
                }

            )
        );
        helper.ModRegistry.AwaitApi<ICustomRunOptionsApi>("Shockah.CustomRunOptions", cro =>
        {
            cro.RegisterPartialDuoDeck(TeraTaxDeck.Deck, new StarterDeck
            {
                cards = [
                    new Tariff(),
                    new TaxEvasion(),
                    new EggToss()
                ]
            });
        
        });
        helper.ModRegistry.AwaitApi<IDuoApi>("Shockah.DuoArtifacts", api =>
        {
            foreach (var artifactType in DuoArtifacts)
                AccessTools.DeclaredMethod(artifactType, nameof(IDuoArtifact.Register))?.Invoke(null, [package, helper, api]);
        });



      
      
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


        TeraCharacter = helper.Content.Characters.V2.RegisterPlayableCharacter("Tera", new PlayableCharacterConfigurationV2
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

            },
            SoloStarters = new StarterDeck
            {
                cards = [
                    new Taunt(),
                    new TaxEvasion(), 
                    new SpareCash(),
                    new Tariff(),
                    new DodgeColorless(),
                    new CannonColorless()
                ]
            },
            ExeCardType = typeof(TeraCatEXE),
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
        helper.Content.Characters.V2.RegisterCharacterAnimation(new()
        {
            CharacterType = TeraTaxDeck.UniqueName,
            LoopTag = "egg",
            Frames = Enumerable.Range(0, 1)
              .Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Animation/teraegg.png")).Sprite)
              .ToList()
        });
      
        TaxDroneCard = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Artifact/FireSale.png"));
        TaxDroneMidrow = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Artifact/FireSale.png"));




        TeraTaxationStatus = helper.Content.Statuses.RegisterStatus("Tax", new StatusConfiguration
        {
            Definition = new StatusDef
            {
                isGood = false,
                affectedByTimestop = false,
                color = new Color("FFD700"),
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
                color = new Color("FFFFFF"),
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
                color = new Color("D5B60A"),
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
                color = new Color("29AB87"),
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
                color = new Color("0B6623"),
                icon = RegisterSprite(package, "assets/Feature/Bailout.png").Sprite
            },
            Name = AnyLocalizations.Bind(["status", "Bailout", "name"]).Localize,
            Description = AnyLocalizations.Bind(["status", "Bailout", "desc"]).Localize
        });
        TeraDividendsStatus = helper.Content.Statuses.RegisterStatus("Dividends", new StatusConfiguration
        {
            Definition = new StatusDef
            {
                isGood = true,
                affectedByTimestop = false,
                color = new Color("4CBB17"),
                icon = RegisterSprite(package, "assets/Feature/Dividends.png").Sprite
            },
            Name = AnyLocalizations.Bind(["status", "Dividends", "name"]).Localize,
            Description = AnyLocalizations.Bind(["status", "Dividends", "desc"]).Localize
        });


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
        TeraDividendsManager dividendsManager = new();
        KokoroApi.StatusLogic.RegisterHook(dividendsManager);

        _ = new TeraBailoutManager();
        _ = new FlightTraining();
        _ = new MonetaryShock();
        _ = new AssetLiquidation();

        foreach (var type in AllRegisterableTypes)
            AccessTools.DeclaredMethod(type, nameof(IRegisterable.Register))?.Invoke(null, [package, helper]);

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

    }


    public static ISpriteEntry RegisterSprite(IPluginPackage<IModManifest> package, string dir)
    {
        return Instance.Helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile(dir));
    }


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

