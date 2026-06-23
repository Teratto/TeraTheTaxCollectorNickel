using Nanoray.PluginManager;
using Nickel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TeraTaxMod.External;
using static TeraTaxMod.Dialogue.CommonDefinitions;

namespace TeraTaxMod.Dialogue
{
    internal class TeraZariDialogue : IRegisterable
    {
        public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
        {
            LocalDB.DumpStoryToLocalLocale("en", "Vintage.ZariMod", new Dictionary<string, DialogueMachine>()
            {
                {
                    "Tenacity_Zari_0",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmZari],
                        lookup = ["Tenacity"],
                        oncePerCombatTags = ["Tenacity"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmTera, "taxes", "Need to dig through some papers..."),
                        new(AmZari, "annoyed", "Keep your filthy documents away from my hoard!")
                        ]
                    }
                },
                {
                    "EggToss_Zari_0",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmZari],
                        lookup = ["EggToss"],
                        oncePerCombatTags = ["EggNormal"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmZari, "pondering", "...Do birds throw their young in self defence?"),
                        new(AmTera, "lookaway", "Probably.")
                        ]
                    }
                },
                {
                    "EggShells_Zari_0",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmZari],
                        lookup = ["EggShells"],
                        oncePerRunTags = ["EggHurtie"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmZari, "annoyed", "Your eggs have made a mess of things."),
                        new(AmTera, "lookaway", "I didn't do it.")
                        ]
                    }
                },
                {
                    "SpareCash_Zari_0",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmZari],
                        lookup = ["SpareCash"],
                        oncePerRunTags = ["SpareCash"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmZari, "arrogant", "Spare capital? I suppose I shall help myself."),
                        new(AmDrake, "sad", "That was mine! Give it back!")
                        ]
                    }
                },
                {"ArtifactEarlyBird_Multi_Tera_1", new(){
                dialogue = [
                    new(),
                    new(AmZari, "arrogant", "...Gives me a coin?")
                ]
                }},
                {"ArtifactFlightTraining_Multi_Tera_1", new(){
                dialogue = [
                    new(),
                    new(AmZari, "pondering", "Do they require training? I was not informed.")
                ]
                }},
                {"ManyTurns_Multi_Tera_0", new(){
                dialogue = [
                    new(),
                    new(AmZari, "arrogant", "Not long enough.")
                ]
                }},
                {
                    "TeraWentMissing_Zari_0",
                    new()
                    {
                        type = NodeType.combat,
                        priority = true,
                        lastTurnPlayerStatuses = [MissingTera],
                        oncePerRun = true,
                        oncePerCombatTags = ["teraWentMissing"],
                        allPresent = [AmZari],
                        dialogue = [
                        new(AmZari, "pondering", "Tera? Why are you hiding behind my tail?"),
                        ]
                    }
                },
                {
                    "TeraWentMissing_Zari_1",
                    new()
                    {
                        type = NodeType.combat,
                        priority = true,
                        lastTurnPlayerStatuses = [MissingTera],
                        oncePerRun = true,
                        oncePerCombatTags = ["teraWentMissing"],
                        allPresent = [AmZari],
                        dialogue = [
                        new(AmZari, "arrogant", "Tera, get out of my hoard!"),
                        ]
                    }
                },
                {"Duo_AboutToDieAndLoop_Multi_Tera_Zari_0", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerRun = true,
                    oncePerCombatTags = ["aboutToDie"],
                    allPresent = [AmTera, AmZari],
                    dialogue = [
                        new(AmTera, "squint", "Zari, can't you just, carry us away?"),
                        new(AmZari, "annoyed", "...And abandon my hoard?")
                    ]
                }},
                {"Duo_AboutToDieAndLoop_Multi_Tera_Zari_2", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerRun = true,
                    oncePerCombatTags = ["aboutToDie"],
                    allPresent = [AmTera, AmZari, AmDrake],
                    dialogue = [
                        new(AmZari, "resigned", "My entire fortune, about to be turned into dust..."),
                        new(AmTera, "neutral", "Sorry Drake, your inheritance is about to go kaplooey."),
                        new(AmDrake, "squint", "I'm sorry, what?")
                    ]
                }},
                {"ArtifactRansomWithDrakeTeraZari", new(){
                type = NodeType.@event,
                canSpawnOnMap = true,
                oncePerRun = true,
                zones = ["zone_first"],
                allPresent = [ AmTera, AmDrake, AmZari],
                dialogue = [
                    new(AmCat, "I'm picking up a distress signal?"),
                    new(AmZari, "annoyed", "This signal smells of trickery."),
                    new(AmDrake, "sly", "Ah, my fake signal. Used it to rob idiots like Tera all the time. Never fails."),
                    new(AmTera, "squint", "Excuse me?"),
                    new(AmDrakebot, "Hey. Give me that artifact or else.", flipped: true),
                    new(AmDrake, "squint", "Oh wait, what the hell? Am I getting robbed by myself???")
                ],
                choiceFunc = "ArtifactRansom"
                }},

                {$"Pirate_Infinite_AfterCrew_Multi_Tera_Zari_0", new(){
                type = NodeType.@event,
                lookup = ["before_pirate"],
                once = false,
                priority = true,
                requireCharsUnlocked = ["eunice"],
                requiredScenes = ["Pirate_1"],
                allPresent = [AmTera, AmZari],
                dialogue = [
                    new(AmDrakeEnemy, "sly", "I'd like to redeem my inheritance early.", flipped: true),
                    new(AmZari, "annoyed", "'Your' inheritance? How presumptuous!"),
                    new(AmTera, "squint", "...Let's stop the family drama and fight already.")
                ]
                }},
                {$"Pirate_Infinite_AfterCrew_Multi_Tera_Zari_1", new(){
                type = NodeType.@event,
                lookup = ["before_pirate"],
                once = false,
                priority = true,
                requireCharsUnlocked = ["eunice"],
                requiredScenes = ["Pirate_1"],
                allPresent = [AmTera, AmZari],
                dialogue = [
                    new(AmDrakeEnemy, "sly", "If isn't it my two favorite pushovers.", flipped: true),
                    new(AmTera, "blush", "I knew Drake always had a soft spot for me!"),
                    new(AmZari, "annoyed", "You are the fool in this court, Tera.")
                ]
                }},
                {$"Pirate_Infinite_AfterCrew_Multi_Tera_Zari_2", new(){
                type = NodeType.@event,
                lookup = ["before_pirate"],
                once = false,
                priority = true,
                requireCharsUnlocked = ["eunice"],
                requiredScenes = ["Pirate_1"],
                allPresent = [AmTera, AmZari],
                dialogue = [
                    new(AmDrakeEnemy, "sly", "Can you even see out of your cockpit?", flipped: true),
                    new(AmTera, "lookaway", "Barely."),
                    new(AmZari, "arrogant", "My view is splendid.")
                ]
                }},
                {$"Pirate_Infinite_AfterCrew_Multi_Tera_Zari_3", new(){
                type = NodeType.@event,
                lookup = ["before_pirate"],
                once = false,
                priority = true,
                requireCharsUnlocked = ["eunice"],
                requiredScenes = ["Pirate_1"],
                allPresent = [AmTera, AmZari],
                dialogue = [
                    new(AmZari, "arrogant", "Ah, my muck-spouting niece."),
                    new(AmTera, "happy", "She's a real blockhead, huh?"),
                    new(AmDrakeEnemy, "reallymad", "You both are SO dead.",  flipped: true)
                ]
                }},
           
                {$"Pirate_Infinite_AfterCrew_Multi_Tera_Zari_4", new(){
                type = NodeType.@event,
                lookup = ["before_pirate"],
                once = false,
                priority = true,
                requireCharsUnlocked = ["eunice"],
                requiredScenes = ["Pirate_1"],
                allPresent = [AmTera, AmZari],
                dialogue = [
                    new(AmTera, "taxes", "Drake, when are you finally gonna pay up?"),
                    new(AmDrakeEnemy, "sly", "When you and granny drop dead.", flipped: true),
                    new(AmZari, "neutral", "You will be waiting for many years.")
                ]
                }},
                {
                    "Taunt_Zari_0",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmZari],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "happy", "You're as fat as Zari's tail!"),
                        new(AmZari, "annoyed", "That's preposterous. My tail is of normal size.")
                        ]
                    }
                },
                {
                    "Taunt_Zari_1",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmZari],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "happy", "You're as poor as a common man!"),
                        new(AmZari, "greedycrystal", "And just as bafoonish as one.")
                        ]
                    }
                },
                {"TeraJustHit_Multi_Zari_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisAction = 1,
                    whoDidThat = AmTeraDeck,
                    allPresent = [AmTera,AmZari],
                    dialogue = [
                        new(AmZari, "neutral", "Excellent aim."),
                        new(AmTera, "blush", "Hehe!")
                        ]
                }},
                {"TeraJustHit_Multi_Zari_1", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisAction = 1,
                    whoDidThat = AmTeraDeck,
                    allPresent = [AmTera,AmZari],
                    dialogue = [
                        new(AmZari, "neutral", "Well wrought!"),
                        new(AmTera, "lookaway", "I have no clue what that means, but thank you.")
                        ]
                }},
            });
        }
    }
}
