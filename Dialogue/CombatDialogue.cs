using Nanoray.PluginManager;
using Nickel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using TeraTaxMod.Artifacts;
//266fd8
namespace TeraTaxMod.Dialogue;
using static TeraTaxMod.Dialogue.CommonDefinitions;

internal class CombatDialogue : IRegisterable
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>()
        {
            {
                "BanditThreats_Multi_0", new()
                {
                edit = [new(EMod.countFromStart, 1, AmTera, "lookawaynervous", "C-can I cancel my order?")]
                }
            },
            {"ArtifactAresCannon_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(AresCannon)],
                turnStart = true,
                oncePerRunTags = ["AresCannon"],
                oncePerRun = true,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "neutral", "This is DEFINITELY Drake's kind of ship.")
                ]
            }},
            {"ArtifactAresCannon_Multi_Tera_1", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(AresCannon)],
                turnStart = true,
                oncePerRunTags = ["AresCannon"],
                oncePerRun = true,
                allPresent = [AmTera, AmDrake],
                dialogue = [
                    new(AmTera, "happy", "This reminds me of the ships we used to fly in!"),
                    new(AmDrake, "sly", "I'm definitely stealing it once we're done.")
                ]
            }},
            {"ArtifactAresCannon_Multi_Tera_2", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(AresCannon)],
                turnStart = true,
                oncePerRunTags = ["AresCannon"],
                oncePerRun = true,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "squint", "Why are the cannon controls so wonky? I can't wrap my head around it.")
                ]
            }},
            {"ArtifactAresCannonV2_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(AresCannonV2)],
                turnStart = true,
                oncePerRunTags = ["AresCannonV2"],
                oncePerRun = true,
                allPresent = [AmTera, AmDrake],
                dialogue = [
                    new(AmTera, "squint", "Drake is DEFINITELY frothing at the mouth right now."),
                    new(AmDrake, "sly", "Not my fault this ship is cooler than you.")
                    ]
            }},
            {"ArtifactArmoredBay_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(ArmoredBay)],
                oncePerRunTags = ["ArmoredBae"],
                oncePerRun = true,
                enemyShotJustHit = true,
                minDamageBlockedByPlayerArmorThisTurn = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "lookaway", "This armor is absolutely going down as a tax write-off."),
                    ]
            }},
            {"ArtifactArmoredBay_Multi_Tera_1", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(ArmoredBay)],
                oncePerRunTags = ["ArmoredBae"],
                oncePerRun = true,
                enemyShotJustHit = true,
                minDamageBlockedByPlayerArmorThisTurn = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "scared", "I am SO glad we have armor right now."),
                    ]
            }},
            {"ArtifactBrokenGlasses_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(BrokenGlasses)],
                oncePerRun = true,
                maxTurnsThisCombat = 1,
                turnStart = true,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "lookawaynervous", "D-did Cleo deserve that?"),
                    ]
            }},
             {"ArtifactBrokenGlasses_Multi_Tera_1", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(BrokenGlasses)],
                oncePerRun = true,
                maxTurnsThisCombat = 1,
                turnStart = true,
                allPresent = [AmTera, AmDrake],
                dialogue = [
                    new(AmDrake, "neutral", "We're untouchable!"),
                    new(AmTera, "lookawaynervous", "We didn't have to prove that to Cleo...")
                    ]
            }},
            {"ArtifactCockpitTargetIsRelevant_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(CockpitTarget)],
                oncePerRun = true,
                maxTurnsThisCombat = 1,
                turnStart = true,
                enemyHasPart = "cockpit",
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "squint", "Hey, wait a second... their cockpit looks kinda crappy."),
                    ]
            }},
            {"ArtifactCockpitTargetIsNotRelevant_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(CockpitTarget)],
                oncePerRun = true,
                maxTurnsThisCombat = 1,
                turnStart = true,
                enemyDoesNotHavePart = "cockpit",
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "scared", "What kind of ship doesn't have a cockpit?"),
                    ]
            }},
            {"ArtifactDirtyEngines_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(DirtyEngines)],
                oncePerRun = true,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "scared", "Is our engine supposed to sound like that?"),
                    ]
            }},
            {"ArtifactEnergyPrep_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(EnergyPrep)],
                oncePerRun = true,
                turnStart = true,
                maxTurnsThisCombat = 1,
                allPresent = [AmPeri, AmTera],
                dialogue = [
                    new(AmPeri, "neutral", "Batteries active!"),
                    new(AmTera, "happy", "This'll help out a bunch!")
                    ]
            }},
            {"ArtifactEarlyBird_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(EarlyBird)],
                oncePerRun = true,
                turnStart = true,
                oncePerRunTags = ["EarlyBird"],
                maxTurnsThisCombat = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "happy", "Ah! A morning snack!")
                    ]
            }},
            {"ArtifactEarlyBird_Multi_Tera_1", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(EarlyBird)],
                oncePerRun = true,
                turnStart = true,
                oncePerRunTags = ["EarlyBird"],
                maxTurnsThisCombat = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "happy", "You know what they say! The early bird..."),
                    new (new List<DialogueThing>
                    {
                        new (AmRiggs, "neutral", "I dunno, I usually sleep in."),
                        new (AmPeri, "neutral", "...Gets the worm."),
                        new (AmDizzy, "explains", "...Catches their prey, of course."),
                        new (AmIsaac, "neutral", "...Flies away?"),
                        new (AmDrake, "neutral", "...Gets hit with a stone."),
                        new (AmMax, "squint", "...I don't like worms in my code."),
                        new (AmBooks, "neutral", "...Makes me breakfast!"),
                        new (AmCat, "neutral", "Setting your alarm for 5 AM, got it.")
                    }),
                    ]
            }},
            {"ArtifactFlightTraining_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(FlightTraining)],
                oncePerRun = true,
                turnStart = true,
                oncePerRunTags = ["FlightTraining"],
                maxTurnsThisCombat = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "happy", "Extra evade should always help!")
                    ]
            }},
            {"ArtifactFlightTraining_Multi_Tera_1", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(FlightTraining)],
                oncePerRun = true,
                turnStart = true,
                oncePerRunTags = ["FlightTraining"],
                maxTurnsThisCombat = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "neutral", "Glad I got flight training! I didn't know how to fly a ship before."),
                    new (new List<DialogueThing>
                    {
                        new (AmRiggs, "neutral", "I forged my pilot's license!"),
                        new (AmPeri, "squint", "Where did you get your pilot's license?"),
                        new (AmDizzy, "neutral", "So which flightless bird species are you?"),
                        new (AmIsaac, "writing", "Teach... Tera... Flying..."),
                        new (AmDrake, "squint", "...How are you even alive."),
                        new (AmMax, "neutral", "Don't worry, CAT can steer on her own."),
                        new (AmBooks, "neutral", "I can teach you!"),
                        new (AmCat, "squint", "Engaging autopilot mode.")
                    }),
                    ]
            }},
            {"ArtifactGovernmentGrants_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(GovernmentGrant)],
                oncePerRun = true,
                turnStart = true,
                oncePerRunTags = ["GovernmentGrant"],
                maxTurnsThisCombat = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "neutral", "Hopefully I can buy us out of a pinch.")
                    ]
            }},
            {"ArtifactGovernmentGrants_Multi_Tera_1", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(GovernmentGrant)],
                oncePerRun = true,
                turnStart = true,
                oncePerRunTags = ["GovernmentGrant"],
                maxTurnsThisCombat = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "happy", "Thank you for the extra funds!")
                    ]
            }},
            {"ArtifactGovernmentGrants_Multi_Tera_2", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(GovernmentGrant)],
                oncePerRun = true,
                turnStart = true,
                oncePerRunTags = ["GovernmentGrant"],
                maxTurnsThisCombat = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "neutral", "A little cash goes a long way.")
                    ]
            }},
            {"ArtifactYearlyPayments_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(YearlyPayments)],
                oncePerRun = true,
                turnStart = true,
                oncePerRunTags = ["YearlyPayments"],
                maxTurnsThisCombat = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "taxes", "Wow, these guys are WAY overdue.")
                    ]
            }},
            {"ArtifactYearlyPayments_Multi_Tera_1", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(YearlyPayments)],
                oncePerRun = true,
                turnStart = true,
                oncePerRunTags = ["YearlyPayments"],
                maxTurnsThisCombat = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "taxes", "Have you like, ever READ one of these forms before?")
                    ]
            }},
            {"ArtifactYearlyPayments_Multi_Tera_2", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(YearlyPayments)],
                oncePerRun = true,
                turnStart = true,
                oncePerRunTags = ["YearlyPayments"],
                maxTurnsThisCombat = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "taxes", "I'm charging you extra, just for how bad your ship looks.")
                    ]
            }},
            {"ArtifactInflation_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(Inflation)],
                oncePerRun = true,
                turnStart = true,
                oncePerRunTags = ["Inflation"],
                maxTurnsThisCombat = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "happytaxes", "Awe yeah. It's tax time.")
                    ]
            }},
            {"ArtifactInflation_Multi_Tera_1", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(Inflation)],
                oncePerRun = true,
                turnStart = true,
                oncePerRunTags = ["Inflation"],
                maxTurnsThisCombat = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "neutral", "Man, the prices are soaring. That's not good for them.")
                    ]
            }},
            {"ArtifactInflation_Multi_Tera_2", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(Inflation)],
                oncePerRun = true,
                turnStart = true,
                oncePerRunTags = ["Inflation"],
                maxTurnsThisCombat = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "happytaxes", "I don't think our foes will be able to handle these costs.")
                    ]
            }},
            {"ArtifactCapitalism_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(Capitalism)],
                oncePerRun = true,
                turnStart = true,
                oncePerRunTags = ["Capitalism"],
                maxTurnsThisCombat = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "lookaway", "Capitalism has never caused any problems whatsoever.")
                    ]
            }},
            {"ArtifactCapitalism_Multi_Tera_1", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(Capitalism)],
                oncePerRun = true,
                turnStart = true,
                oncePerRunTags = ["Capitalism"],
                maxTurnsThisCombat = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "lookawaynervous", "I really hope this extra energy is worth the price.")
                    ]
            }},
             {"ArtifactCapitalism_Multi_Tera_2", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(Capitalism)],
                oncePerRun = true,
                turnStart = true,
                oncePerRunTags = ["Capitalism"],
                maxTurnsThisCombat = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "taxes", "I have so many more papers to dig through...")
                    ]
            }},
            {"ArtifactCapitalism_Multi_Tera_3", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(Capitalism)],
                oncePerRun = true,
                turnStart = true,
                oncePerRunTags = ["Capitalism"],
                maxTurnsThisCombat = 1,
                allPresent = [AmTera, AmDrake],
                dialogue = [
                    new(AmTera, "neutral", "The wonders of capitalism."),
                    new(AmDrake, "neutral", "So much opportunity for crime.")
                    ]
            }},
            {"ArtifactGeminiCore_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(GeminiCore)],
                oncePerRun = true,
                oncePerRunTags = ["GeminiCore"],
                allPresent = [AmTera, AmDrake],
                dialogue = [
                    new(AmTera, "blush", "I think it'd be kinda cute if I got the blue side, and you got the red side."),
                    new(AmDrake, "neutral", "In your dreams, birdbrain.")
                    ]
            }},
            {
                "ArtifactGeminiCore_Multi_4", new()
                {
                edit = [new(EMod.countFromStart, 1, AmTera, "happy", "Blue! Blue!")]
                }
            },
            {"ArtifactGeminiCoreBooster_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(GeminiCore)],
                oncePerRun = true,
                oncePerRunTags = ["GeminiCoreBooster"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "lookawaynervous", "I can't even begin to understand what's happening on this ship."),
                    ]
            }},
            {"ArtifactHardmode_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(HARDMODE)],
                once = true,
                priority = true,
                oncePerRunTags = ["HARDMODE"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "lookawaynervous", "I got a bad feeling about this one...")
                    ]
            }},
            {"ArtifactJetThrusters_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(JetThrusters)],
                oncePerRun = true,
                maxTurnsThisCombat = 1,
                allPresent = [AmRiggs, AmTera],
                dialogue = [
                    new(AmRiggs, "neutral", "Jet thrusters ready!"),
                    new(AmTera, "lookaway", "Just don't move too fast, please."),
                    ]
            }},
            {"ArtifactNanofiberHull_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(NanofiberHull)],
                oncePerRun = true,
                oncePerRunTags = ["NanofiberHull"],
                minDamageDealtToPlayerThisTurn = 1,
                maxDamageDealtToPlayerThisTurn = 1,
                maxTurnsThisCombat = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "neutral", "Everything is okay! The nanofibers can patch it out."),
                    ]
            }},
            {"ArtifactNanofiberHull2_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(NanofiberHull)],
                oncePerRun = true,
                oncePerRunTags = ["NanofiberHull2"],
                minDamageDealtToPlayerThisTurn = 2,
                maxTurnsThisCombat = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "lookawaynervous", "Um, guys? I don't think the nanofibers can handle that..."),
                    ]
            }},
            {
                "ArtifactOverclockedGeneratorSeenMaxMemory3_Multi_0", new()
                {
                edit = [new(EMod.countFromStart, 1, AmTera, "squint", "Dizzy... you didn't have to bring that up, you know.")]
                }
            },
            {"ArtifactPressureFuse_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(PressureFuse)],
                oncePerRun = true,
                oncePerCombatTags = ["PressureFuse"],
                allPresent = [AmDrake, AmTera],
                maxHullPercent = 0.5,
                dialogue = [
                    new(AmTera, "lookawaynervous", "Um, Drake? I don't like how the ship sounds..."),
                    new(AmDrake, "neutral", "Stop being a scardey-cat. Let's turn up the heat!"),
                    ]
            }},
            {"ArtifactRecalibrator_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(Recalibrator)],
                playerShotJustMissed = true,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "happy", "We meant to miss! I think!")
                    ]
            }},
            {"ArtifactShieldPrepIsGone_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                doesNotHaveArtifactTypes = [typeof(ShieldPrep), typeof(WarpMastery)],
                turnStart = true,
                maxTurnsThisCombat = 1,
                oncePerRunTags = ["ShieldPrepIsGoneYouFool"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "sad", "W-wait, where'd warp prep go? I can't do taxes without preparation!")
                    ]
            }},
            {"Artifacttiderunner_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(TideRunner)],
                turnStart = true,
                maxTurnsThisCombat = 1,
                oncePerRun = true,
                oncePerRunTags = ["TeraDontShipYap"],
                oncePerCombatTags = ["Tiderunner"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "blush", "Does being on this ship mean I'm the captain's parrot?")
                    ]
            }},
            {"Artifacttiderunner_Multi_Tera_1", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(TideRunner)],
                turnStart = true,
                maxTurnsThisCombat = 1,
                oncePerRunTags = ["TeraDontShipYap"],
                oncePerRun = true,
                oncePerCombatTags = ["Tiderunner"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "happy", "Squawk! Tera wants a cracker!")
                    ]
            }},
            {"ArtifactTridimensionalCockpit_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                hasArtifactTypes = [typeof(TridimensionalCockpit)],
                turnStart = true,
                maxTurnsThisCombat = 1,
                oncePerRun = true,
                oncePerCombatTags = ["TridimensionalCockpit"],
                allPresent = [AmTera, AmDrake],
                dialogue = [
                    new(AmDrake, "squint", "This cockpit change seems cowardly."),
                    new(AmTera, "lookaway", "Personally, I think it's VERY valid to be cowardly.")
                    ]
            }},
            {"BlockedALotOfAttacksWithArmor_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                minDamageBlockedByPlayerArmorThisTurn = 3,
                oncePerRun = true,
                oncePerCombatTags = ["YowzaThatWasALOTofArmorBlock"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "scared", "I am SO glad we have armor right now.")
                    ]
            }},
            {"BlockedAnEnemyAttackWithArmor_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                minDamageBlockedByPlayerArmorThisTurn = 1,
                oncePerRun = true,
                oncePerCombatTags = ["WowArmorISPrettyCoolHuh"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "neutral", "Wish the government would give MY ship armor.")
                    ]
            }},
            {"BooksJustHit_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisTurn = 1,
                whoDidThat = Deck.shard,
                oncePerCombatTags = ["BooksShotThatGuy"],
                allPresent = [AmBooks, AmTera],
                dialogue = [
                    new(AmTera, "happy", "Nice one, Books!")
                    ]
            }},
            {"BooksWentMissing_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                priority = true,
                lastTurnPlayerStatuses = [Status.missingBooks],
                oncePerRun = true,
                oncePerCombatTags = ["booksWentMissing"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "lookawaynervous", "W-where'd Books go?")
                    ]
            }},
            {"CatWentMissing_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                priority = true,
                lastTurnPlayerStatuses = [Status.missingCat],
                oncePerRun = true,
                oncePerCombatTags = ["CatWentMissing"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "sad", "W-wait, how do we operate a ship without a computer?")
                    ]
            }},
            {"CheapCardPlayed_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                maxCostOfCardJustPlayed = 0,
                oncePerRun = true,
                oncePerCombatTags = ["CheapCardPlayed"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "happy", "No energy required!")
                    ]
            }},
            {"CrabFacts1_Multi_0", new(){
                edit = [
                    new(EMod.countFromStart, 2, AmTera, "neutral", "Wait, I thought crabs were like, government drones?")
                ]
            }},
            {"CrabFacts2_Multi_0", new(){
                edit = [
                    new(EMod.countFromStart, 2, AmTera, "squint", "Are you sure these facts aren't government cover-ups?")
                ]
            }},
            {"CrabFactsAreOverNow_Multi_0", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmTera, "squint", "I'm watching you, government crab drone.")
                ]
            }},
            {"DrakeWentMissing_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                priority = true,
                lastTurnPlayerStatuses = [Status.missingDrake],
                oncePerRun = true,
                oncePerCombatTags = ["drakeWentMissing"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "lookawaynervous", "D-Drake?")
                    ]
            }},
            {"DrakeWentMissing_Multi_Tera_1", new()
            {
                type = NodeType.combat,
                priority = true,
                lastTurnPlayerStatuses = [Status.missingDrake],
                oncePerRun = true,
                oncePerCombatTags = ["drakeWentMissing"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "lookawaynervous", "Drake being gone makes me feel a lot worse.")
                    ]
            }},
            {"DualNotEnoughDronesShouts_Multi_0", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmTera, "squint", "It's coming out of YOUR taxes, bucko.")
                ]
            }},
            {"Duo_AboutToDieAndLoop_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerRun = true,
                oncePerCombatTags = ["aboutToDie"],
                allPresent = [AmTera, AmRiggs],
                dialogue = [
                    new(AmTera, "sad", "I don't wanna die!"),
                    new(AmRiggs, "neutral", "Yeah, me neither.")
                    ]
            }},
            {"Duo_AboutToDieAndLoop_Multi_Tera_1", new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerRun = true,
                oncePerCombatTags = ["aboutToDie"],
                allPresent = [AmTera, AmDizzy],
                dialogue = [
                    new(AmTera, "lookawaynervous", "Is this where we reset?"),
                    new(AmDizzy, "neutral", "Probably.")
                    ]
            }},
            {"Duo_AboutToDieAndLoop_Multi_Tera_2", new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerRun = true,
                oncePerCombatTags = ["aboutToDie"],
                allPresent = [AmTera, AmPeri],
                dialogue = [
                    new(AmTera, "sad", "Are we gonna explode?!"),
                    new(AmPeri, "neutral", "Tera, breathe.")
                    ]
            }},
            {"Duo_AboutToDieAndLoop_Multi_Tera_3", new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerRun = true,
                oncePerCombatTags = ["aboutToDie"],
                allPresent = [AmTera, AmCat],
                dialogue = [
                    new(AmTera, "lookawaynervous", "Please don't tell me we reset here..."),
                    new(AmCat, "neutral", "Alright, I won't.")
                    ]
            }},
            {"Duo_AboutToDieAndLoop_Multi_Tera_4", new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerRun = true,
                oncePerCombatTags = ["aboutToDie"],
                allPresent = [AmTera, AmIsaac],
                dialogue = [
                    new(AmTera, "sad", "I don't wanna die!"),
                    new(AmIsaac, "neutral", "You get used to it.")
                    ]
            }},
            {"Duo_AboutToDieAndLoop_Multi_Tera_5", new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerRun = true,
                oncePerCombatTags = ["aboutToDie"],
                allPresent = [AmTera, AmDrake],
                dialogue = [
                    new(AmTera, "neutral", "If I die, Drake's going down with me!"),
                    new(AmDrake, "mad", "We're ALL going down, birdbrain.")
                    ]
            }},
            {"Duo_AboutToDieAndLoop_Multi_Tera_6", new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerRun = true,
                oncePerCombatTags = ["aboutToDie"],
                allPresent = [AmTera, AmMax],
                dialogue = [
                    new(AmTera, "neutral", "Hurry, hack their ship before we go kaboom!"),
                    new(AmMax, "gloves", "Um, beep boop?")
                    ]
            }},
            {"Duo_AboutToDieAndLoop_Multi_Tera_7", new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerRun = true,
                oncePerCombatTags = ["aboutToDie"],
                allPresent = [AmTera, AmBooks],
                dialogue = [
                    new(AmTera, "sad", "We're gonna explode!"),
                    new(AmBooks, "neutral", "No! We can do it!")
                    ]
            }},
            {"Duo_AboutToDieAndLoop_Multi_Tera_8", new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerRun = true,
                oncePerCombatTags = ["aboutToDie"],
                allPresent = [AmTera, AmIsaac],
                dialogue = [
                    new(AmIsaac, "neutral", "About time to loop again."),
                    new(AmTera, "lookawaynervous", "B-but I don't wanna loop yet!")
                    ]
            }},
            {"Duo_AboutToDieAndLoop_Multi_Tera_9", new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerRun = true,
                oncePerCombatTags = ["aboutToDie"],
                allPresent = [AmTera, AmDrake],
                dialogue = [
                    new(AmDrake, "mad", "This run would be better if Tera actually listened to me."),
                    new(AmTera, "lookawaynervous", "...")
                    ]
            }},
            {"Duo_AboutToDieAndLoop_Multi_Tera_10", new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerRun = true,
                oncePerCombatTags = ["aboutToDie"],
                allPresent = [AmTera, AmDizzy],
                dialogue = [
                    new(AmDizzy, "neutral", "Welp."),
                    new(AmTera, "neutral", "Darn.")
                    ]
            }},
            {"Duo_AboutToDieAndLoop_Multi_Tera_11", new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerRun = true,
                oncePerCombatTags = ["aboutToDie"],
                allPresent = [AmTera, AmBooks],
                dialogue = [
                    new(AmBooks, "neutral", "Tera! Tax us outta here!"),
                    new(AmTera, "squint", "I... What?")
                    ]
            }},
            {"Duo_AboutToDieAndLoop_Multi_Tera_12", new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerRun = true,
                oncePerCombatTags = ["aboutToDie"],
                allPresent = [AmTera, AmMax],
                dialogue = [
                    new(AmBooks, "neutral", "It's over man."),
                    new(AmTera, "lookawaynervous", "Yeah... I can feel it.")

                    ]
            }},
            {"Duo_AboutToDieAndLoop_Multi_Tera_13", new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerRun = true,
                oncePerCombatTags = ["aboutToDie"],
                allPresent = [AmTera, AmCat],
                dialogue = [
                    new(AmCat, "neutral", "It's time to reset."),
                    new(AmTera, "lookawaynervous", "CAT? Don't scare me like this!")
                    ]
            }},
            {"Duo_AboutToDieAndLoop_Multi_Tera_14", new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerRun = true,
                oncePerCombatTags = ["aboutToDie"],
                allPresent = [AmTera, AmPeri],
                dialogue = [
                    new(AmPeri, "mad", "It's not looking good."),
                    new(AmTera, "lookawaynervous", "Shoot, is it over?")
                    ]
            }},
            {"EmptyHandWithEnergy_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                handEmpty = true,
                minEnergy = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "neutral", "Wait, what do we do now?")
                    ]
            }},
            {"EmptyHandWithEnergy_Multi_Tera_1", new()
            {
                type = NodeType.combat,
                handEmpty = true,
                minEnergy = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "squint", "Nothing to spend our energy on...")
                    ]
            }},
            {"EnemyArmorHit_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageBlockedByEnemyArmorThisTurn = 1,
                oncePerCombat = true,
                oncePerRun = true,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "squint", "Can we maybe, not aim at their armor?")
                    ]
            }},
            {"EnemyHasBrittle_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                enemyHasBrittlePart = true,
                oncePerRunTags = ["yelledAboutBrittle"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "happy", "Yeah yeah! Hit that brittle point!")
                    ]
            }},
            {"EnemyHasWeakness_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                enemyHasBrittlePart = true,
                oncePerRunTags = ["yelledAboutWeakness"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "squint", "Their ship seems kinda shoddy... we should hit that weak point.")
                    ]
            }},
            {"EuniceMiss_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                playerShotJustMissed = true,
                oncePerCombat = true,
                doesNotHaveArtifacts = ["Recalibrator", "GrazerBeam"],
                allPresent = [AmTera, AmDrake],
                dialogue = [
                    new(AmDrake, "sly", "I taught you better than that."),
                    new(AmTera, "lookawaynervous", "I'm trying!")
                    ]
            }},
            {"ExpensiveCardPlayed_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                minCostOfCardJustPlayed = 4,
                oncePerCombatTags = ["ExpensiveCardPlayed"],
                oncePerRun = true,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "neutral", "Man, that card was costly.")
                    ]
            }},
            {"FreezeIsMaxSize_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                turnStart = true,
                oncePerCombatTags = ["biggestCrystalShout"],
                enemyIntent = "biggestCrystal",
                allPresent = [AmTera, AmCrystal],
                dialogue = [
                    new(AmTera, "neutral", "Wow, that's a BIG crystal.")
                    ]
            }},
            {"HackerJustHit_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                whoDidThat = Deck.hacker,
                allPresent = [AmTera, AmMax],
                dialogue = [
                    new(AmTera, "happy", "Nice one Max!")
                    ]
            }},
            {"TeraJustHit_Multi_0", new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                whoDidThat = AmTeraDeck,
                allPresent = [AmTera,],
                dialogue = [
                    new(AmTera, "neutral", "Woa, firing cannons isn't as hard as I thought.")
                    ]
            }},
            {"TeraJustHit_Multi_1", new()
            {
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                whoDidThat = AmTeraDeck,
                allPresent = [AmTera,],
                dialogue = [
                    new(AmTera, "neutral", "We got this.")
                    ]
            }},
            {"TeraJustHit_Multi_2", new()
            {
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                whoDidThat = AmTeraDeck,
                allPresent = [AmTera,],
                dialogue = [
                    new(AmTera, "happy", "Woa, I hit them!")
                    ]
            }},
            {"TeraJustHit_Multi_3", new()
            {
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                whoDidThat = AmTeraDeck,
                allPresent = [AmTera,],
                dialogue = [
                    new(AmTera, "happy", "Heck yeah!")
                    ]
            }},
            {"TeraJustHit_Multi_4", new()
            {
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                whoDidThat = AmTeraDeck,
                allPresent = [AmTera,],
                dialogue = [
                    new(AmTera, "happy", "Pew pew!")
                    ]
            }},
            {"TeraJustHit_Multi_5", new()
            {
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                whoDidThat = AmTeraDeck,
                allPresent = [AmTera, AmPeri],
                dialogue = [
                    new(AmPeri, "neutral", "Nice shot, Tera."),
                    new(AmTera, "blush", "Thank you!")
                    ]
            }},
            {"TeraJustHit_Multi_6", new()
            {
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                whoDidThat = AmTeraDeck,
                allPresent = [AmTera, AmDrake],
                dialogue = [
                    new(AmTera, "happy", "Not too shabby!"),
                    new(AmDrake, "neutral", "Don't get ahead of yourself."),
                    ]
            }},
            {"TeraJustHit_Multi_7", new()
            {
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                whoDidThat = AmTeraDeck,
                allPresent = [AmTera, AmDrake],
                dialogue = [
                    new(AmTera, "happy", "Just like you taught me!"),
                    new(AmDrake, "sly", "You learned from the best."),
                    ]
            }},
             {"TeraJustHit_Multi_8", new()
            {
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                whoDidThat = AmTeraDeck,
                allPresent = [AmTera, AmDrake],
                dialogue = [
                    new(AmDrake, "neutral", "I gotta admit, I'm impressed."),
                    new(AmTera, "blush", "Hehe..."),
                    ]
            }},
            {"JustHitGeneric_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "happy", "Nice one!"),
                    ]
            }},
            {"JustHitGeneric_Multi_Tera_1", new()
            {
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "happy", "That's a hit!"),
                    ]
            }},
            {"JustHitGeneric_Multi_Tera_2", new()
            {
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "neutral", "Phew, it hit."),
                    ]
            }},
            {"JustHitGeneric_Multi_Tera_3", new()
            {
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "neutral", "Good shot."),
                    ]
            }},
            {"JustHitGeneric_Multi_Tera_4", new()
            {
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "happy", "Good aim!"),
                    ]
            }},
            {"HandOnlyHasTrashCard_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                handFullOfTrash = true,
                oncePerCombatTags = ["handOnlyHasTrashCards"],
                oncePerRun = true,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "squint", "Don't we pay taxes to like, have people get RID of trash?"),
                    ]
            }},
            {"JustPlayedADraculaCard_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                whoDidThat = Deck.dracula,
                oncePerRun = true,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "blush", "Man, that Dracula guy was awesome."),
                    ]
            }},
            {"DualNotEnoughDronesShouts_Multi_2", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmTera, "squint", "Hey! Birds aren't drones!")
                ]
            }},
            {"JustPlayedASashaCard_Multi_2", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmTera, "squint", "S-sports?")
                ]
            }},
            {"JustPlayedAToothCard_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                whoDidThat = Deck.tooth,
                oncePerRunTags = ["usedAToothCard"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "squint", "Eugh, we're REALLY trusting that guy?"),
                    ]
            }},
            {"ManyFlips_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                minTimesYouFlippedACardThisTurn = 4,
                oncePerCombat = true,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "squint", "My head hurts. Can't we just choose?"),
                    ]
            }},
            {"ManyFlipsAndTeraIsGettingTired_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                minTimesYouFlippedACardThisTurn = 20,
                oncePerCombat = true,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "squint", "Can you... stop that?"),
                    ]
            }},
            {"ManyFlipsAndTeraIsGettingTired_Multi_Tera_1", new()
            {
                type = NodeType.combat,
                minTimesYouFlippedACardThisTurn = 100,
                oncePerCombat = true,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "squint", "I'm just, going to ignore you now."),
                    ]
            }},
            {"ManyTurns_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                minTurnsThisCombat = 9,
                turnStart = true,
                oncePerCombatTags = ["manyTurns"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "lookawaynervous", "How long have we been flying? I'm starting to get sick..."),
                    new (new List<DialogueThing>
                    {
                        new (AmRiggs, "neutral", "I'll get the barf bag!"),
                        new (AmPeri, "neutral", "Please use the oxygen mask."),
                        new (AmDizzy, "neutral", "Even birds get sick of flying. Cool."),
                        new (AmIsaac, "writing", "Birds... hate... flying..."),
                        new (AmDrake, "neutral", "And this is why you're not a pirate."),
                        new (AmMax, "neutral", "I'd love to see how bad VR would get for you."),
                        new (AmBooks, "neutral", "Just think happy thoughts! Happy not flying thoughts!"),
                        new (AmCat, "neutral", "Tera, you never fail to surprise me.")
                    }),
                    ]
            }},
            {"VeryManyTurns_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                oncePerRun = true,
                minTurnsThisCombat = 9,
                turnStart = true,
                oncePerCombatTags = ["manyTurns"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "neutral", "Been flying for so long, I'm used to being sick now."),
                    ]
            }},
            {"MechaPossumShouts_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                priority = true,
                enemyIntent = "mechaPossumShout",
                once = true,
                oncePerRunTags = ["mechaPossumShout"],
                allPresent = [AmTera, AmRiggs2],
                dialogue = [
                    new(AmTera, "scared", "Has punching always been allowed?"),
                    new(AmRiggs2, "neutral", "Yes."),
                    ]
            }},
            {"OneHitPointThisIsFine_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                maxHull = 1,
                oncePerRun = true,
                oncePerCombatTags = ["aboutToDie"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "scared", "W-why does our ship sound like that?")
                    ]
            }},
            {"OneHitPointThisIsFine_Multi_Tera_1", new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                maxHull = 1,
                oncePerRun = true,
                oncePerCombatTags = ["aboutToDie"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "sad", "No! I'm too young to die!")
                    ]
            }},
            {"EuniceJustHit_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                whoDidThat = Deck.eunice,
                allPresent = [AmTera, AmDrake],
                dialogue = [
                    new(AmTera, "happy", "Nice one, Drake!")
                    ]
            }},
            {"EuniceJustHit_Multi_Tera_1", new()
            {
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                whoDidThat = Deck.eunice,
                allPresent = [AmTera, AmDrake],
                dialogue = [
                    new(AmTera, "happy", "Your aim is amazing!"),
                    new(AmDrake, "sly", "I know. Don't remind me.")
                    ]
            }},
            {"OverheatDrakeFix_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                wasGoingToOverheatButStopped = true,
                oncePerCombatTags = ["OverheatDrakeFix"],
                whoDidThat = Deck.eunice,
                oncePerRun = true,
                allPresent = [AmTera, AmDrake],
                dialogue = [
                    new(AmTera, "lookaway", "Thank you for not roasting me alive."),
                    new(AmDrake, "sly", "Aww, but you would have been delicious!")
                    ]
            }},
            {"OverheatDrakeFix_Multi_Tera_1", new()
            {
                type = NodeType.combat,
                wasGoingToOverheatButStopped = true,
                oncePerCombatTags = ["OverheatDrakeFix"],
                whoDidThat = Deck.eunice,
                allPresent = [AmTera, AmDrake],
                dialogue = [
                    new(AmDrake, "neutral", "See? Everything's all under control."),
                    new(AmTera, "scared", "I really hope you're sure about that!")
                    ]
            }},
             {"OverheatDrakeFix_Multi_6", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmTera, "neutral", "Phew, thank you Drake.")
                ]
            }},
            {"OverheatDrakesFault_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                goingToOverheat = true,
                oncePerCombatTags = ["OverheatDrakesFault"],
                allPresent = [AmTera, AmDrake],
                dialogue = [
                    new(AmTera, "squint", "Eunice!"),
                    new(AmDrake, "squint", "Don't call me that.")
                    ]
            }},
            {"OverheatDrakesFault_Multi_Tera_1", new()
            {
                type = NodeType.combat,
                goingToOverheat = true,
                oncePerCombatTags = ["OverheatDrakesFault"],
                allPresent = [AmTera, AmDrake],
                dialogue = [
                    new(AmDrake, "slyBlush", "Ah, consequences, we meet again."),
                    new(AmTera, "squint", "Drake! C'mon, you're more careful than this!")
                    ]
            }},
            {"OverheatDrakesFault_Multi_Tera_2", new()
            {
                type = NodeType.combat,
                goingToOverheat = true,
                oncePerCombatTags = ["OverheatDrakesFault"],
                allPresent = [AmTera, AmDrake],
                dialogue = [
                    new(AmTera, "squint", "Drake, what the heck!"),
                    new(AmDrake, "slyBlush", "My hubris has bested me.")
                    ]
            }},
            {"OverheatDrakesFault_Multi_9", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmTera, "scared", "Drake! What are you doing!?!")
                ]
            }},
            {"OverheatGeneric_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                goingToOverheat = true,
                oncePerCombatTags = ["OverheatGeneric"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "scared", "Ack! Too hot, too hot!"),
                    ]
            }},
            {"OverheatGeneric_Multi_Tera_1", new()
            {
                type = NodeType.combat,
                goingToOverheat = true,
                oncePerCombatTags = ["OverheatGeneric"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "sad", "Please someone find the AC already!"),
                    ]
            }},
            {"PeriJustHit_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                whoDidThat = Deck.peri,
                oncePerRun = true,
                oncePerCombatTags = ["PeriHitEmYo"],
                allPresent = [AmTera, AmMax],
                dialogue = [
                    new(AmTera, "happy", "Nice one Max!")
                    ]
            }},
            {"PeriWentMissing_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                priority = true,
                lastTurnPlayerStatuses = [Status.missingPeri],
                oncePerRun = true,
                oncePerCombatTags = ["periWentMissing"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "lookawaynervous", "Shoot, I don't know if we can do this without Peri...")
                    ]
            }},
            {"PlayedManyCards_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                minCardsPlayedThisTurn = 6,
                handEmpty = true,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "happy", "Maximum value!")
                    ]
            }},
            {
                "SkunkFirstTurnShouts_Multi_0", new()
                {
                edit = [new(EMod.countFromStart, 1, AmTera, "neutral", "Listen, we don't want the rocks, they're not good tax write-offs.")]
                }
            },
            {"ThatsALotOfDamageToThem_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                minDamageDealtToEnemyThisTurn = 10,
                playerShotJustHit = true,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "happy", "We are OWNING them!")
                    ]
            }},
            {"ThatsALotOfDamageToThemByTera_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                minDamageDealtToEnemyThisTurn = 10,
                whoDidThat = AmTeraDeck,
                playerShotJustHit = true,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "happytaxes", "Awe yeah, it's tax time.")
                    ]
            }},
            {"ThatsALotOfDamageToThemByTera_Multi_Tera_1", new()
            {
                type = NodeType.combat,
                minDamageDealtToEnemyThisTurn = 10,
                whoDidThat = AmTeraDeck,
                playerShotJustHit = true,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "happy", "Get ABSOLUTELY destroyed!")
                    ]
            }},
            {"ThatsALotOfDamageToThemByTera_Multi_Tera_2", new()
            {
                type = NodeType.combat,
                minDamageDealtToEnemyThisTurn = 10,
                whoDidThat = AmTeraDeck,
                playerShotJustHit = true,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "happy", "How's' it feel now, huh?!?")
                    ]
            }},
            {"ThatsALotOfDamageToThemByTera_Multi_Tera_3", new()
            {
                type = NodeType.combat,
                minDamageDealtToEnemyThisTurn = 10,
                whoDidThat = AmTeraDeck,
                playerShotJustHit = true,
                allPresent = [AmTera, AmDrake],
                dialogue = [
                    new(AmDrake, "I knew you had it in you."),
                    new(AmTera, "blush", "T-Thank you!")
                    ]
            }},
            {"ThatsALotOfDamageToThemByTera_Multi_Tera_4", new()
            {
                type = NodeType.combat,
                minDamageDealtToEnemyThisTurn = 10,
                whoDidThat = AmTeraDeck,
                playerShotJustHit = true,
                allPresent = [AmTera, AmDrake],
                dialogue = [
                    new(AmTera, "happy", "I am DESTROYING them right now!"),
                    new(AmDrake, "Once a pirate, always a pirate.")
                    ]
            }},
            {"ThatsALotOfDamageToUs_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                minDamageDealtToPlayerThisTurn = 3,
                enemyShotJustHit = true,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "scared", "I-Is the ship supposed to make that noise?")
                    ]
            }},
            {"ThatsALotOfDamageToUs_Multi_Tera_1", new()
            {
                type = NodeType.combat,
                minDamageDealtToEnemyThisTurn = 10,
                playerShotJustHit = true,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "sad", "Please please PLEASE tell me that's not gonna happen again!")
                    ]
            }},
            {"TheyGotCorroded_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                lastTurnEnemyStatuses = [Status.corrode],
                oncePerRun = true,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "neutral", "Now, let's just stall! I'm quite good at that.")
                    ]
            }},
            {"TheyHaveAutoDodgeLeft_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                lastTurnEnemyStatuses = [Status.autododgeLeft],
                oncePerCombatTags = ["aboutAutododge"],
                oncePerRun = true,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "squint", "Hey, wait! They're going left! Those cheaters!")
                    ]
            }},
            {"TheyHaveAutoDodgeRight_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                lastTurnEnemyStatuses = [Status.autododgeRight],
                oncePerCombatTags = ["aboutAutododge"],
                oncePerRun = true,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "neutral", "They're dodging right! Watch out.")
                    ]
            }},
            {"TookZeroDamageAtLowHealth_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                maxDamageDealtToPlayerThisTurn = 0,
                maxHull = 2,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "happy", "We survived! Phew!")
                    ]
            }},
            {"WeAreCorroded_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                lastTurnPlayerStatuses = [Status.corrode],
                oncePerRun = true,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "scared", "Agh! We gotta hurry up!")
                    ]
            }},
            {"WeDidOverFiveDamage_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 6,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "happy", "Big hit confirmed!")
                    ]
            }},
            {"WeDidOverThreeDamage_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 4,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "happytaxes", "That'll show those tax evaders.")
                    ]
            }},
            {"WeDontOverlapWithEnemyAtAllButWeDoHaveASeekerToDealWith_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                priority = true,
                shipsDontOverlapAtAll = true,
                oncePerCombatTags = ["NoOverlapBetweenShipsSeeker"],
                anyDronesHostile = ["missile_seeker"],
                nonePresent = ["crab"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "squint", "We may have ran, but I still think a missile is comin' after us.")
                    ]
            }},
            {"WeDontOverlapWithEnemyAtAll_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                priority = true,
                shipsDontOverlapAtAll = true,
                oncePerRun = true,
                oncePerCombatTags = ["NoOverlapBetweenShips"],
                nonePresent =["crab", "scrap"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "happy", "See ya later!")
                    ]
            }},
            {"WeGotHurtButNotTooBad_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                minDamageDealtToPlayerThisTurn = 1,
                maxDamageDealtToPlayerThisTurn = 1,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "closed", "It's okay, that wasn't too bad.")
                    ]
            }},
            {"WeGotShotButTookNoDamage_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                enemyShotJustHit = true,
                maxDamageDealtToPlayerThisTurn = 0,
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "happy", "We're safe!")
                    ]
            }},
            {
                "WeJustGainedHeatAndDrakeIsHere_Multi_0", new()
                {
                edit = [new(EMod.countFromStart, 1, AmTera, "squint", "Drake, cool it. Now.")]
                }
            },
            {"WeMissedOopsie_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                playerShotJustMissed = true,
                oncePerCombat = true,
                doesNotHaveArtifacts = ["Recalibrator", "GrazerBeam"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "neutral", "Next time we'll hit them. I hope.")
                    ]
            }},
            {"WeMissedOopsie_Multi_Tera_1", new()
            {
                type = NodeType.combat,
                playerShotJustMissed = true,
                oncePerCombat = true,
                doesNotHaveArtifacts = ["Recalibrator", "GrazerBeam"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "closed", "Just concentrate...")
                    ]
            }},
            {"WeMissedOopsie_Multi_Tera_2", new()
            {
                type = NodeType.combat,
                playerShotJustMissed = true,
                oncePerCombat = true,
                doesNotHaveArtifacts = ["Recalibrator", "GrazerBeam"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "lookawaynervous", "I don't think we were supposed to miss.")
                    ]
            }},
            {"WeMissedOopsie_Multi_Tera_3", new()
            {
                type = NodeType.combat,
                playerShotJustMissed = true,
                oncePerCombat = true,
                doesNotHaveArtifacts = ["Recalibrator", "GrazerBeam"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "neutral", "Gosh darn it.")
                    ]
            }},
            {"WeJustOverheated_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                justOverheated = true,
                oncePerCombatTags = ["WeJustOverheated"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "neutral", "This heat is unbearable.")
                    ]
            }},
            {"ShopKeepBattleInsult", new(){
                edit = [
                    new(EMod.countFromStart, 0, AmTera, "scared", "Oh. Oh no.")
                ]
            }},
            {"LookOutMissile_Multi_Tera_0", new()
            {
                type = NodeType.combat,
                priority = true,
                once = true,
                justOverheated = true,
                oncePerRunTags = ["goodMissleAdvice"],
                anyDronesHostile = ["missile_normal",
                                    "missile_heavy",
                                    "missile_corrode",
                                    "missile_breacher"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "lookaway", "I can't tax a missile. <c=stuffLabel>Shoot it</c>, maybe?")
                    ]
            }},
            
        });
    }
}

