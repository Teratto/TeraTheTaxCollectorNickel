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
                doesNotHaveArtifactTypes = [typeof(ShieldPrep)],
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
                oncePerRun = true,
                oncePerCombatTags = ["Tiderunner"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "happy", "Squawk! Tera wants a cracker!")
                    ]
            }},
            {
                "ArtifactTridimensionalCockpit_Multi_5", new()
                {
                edit = [new(EMod.countFromStart, 1, AmTera, "lookaway", "Personally, I think it's VERY valid to be cowardly.")]
                }
            },
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
        });
    }
}

