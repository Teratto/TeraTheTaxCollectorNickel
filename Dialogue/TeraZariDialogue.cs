using Nanoray.PluginManager;
using Nickel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "taxes", "Need some space to dig through some papers..."),
                        new(AmZari, "annoyed", "Take your filthy tax documents away from my hoard!")
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
                        oncePerCombat = true,
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
                        new(AmZari, "annoyed", "Your eggs have just made a mess of things."),
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
                edit = [
                    new(EMod.countFromStart, 1, AmZari, "arrogant", "...Gives me a coin?")
                ]
                }},
                {"ArtifactFlightTraining_Multi_Tera_1", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmZari, "pondering", "Do they require training? I was not informed.")
                ]
                }},
                {"ManyTurns_Multi_Tera_0", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmZari, "arrogant", "Not long enough.")
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
                {"Duo_AboutToDieAndLoop_Multi_Tera_Zari_1", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerRun = true,
                    oncePerCombatTags = ["aboutToDie"],
                    allPresent = [AmTera, AmZari],
                    nonePresent = [AmDrake],
                    dialogue = [
                        new(AmZari, "resigned", "My entire fortune, about to be turned into dust..."),
                        new(AmTera, "neutral", "At least the inheritance money will look great on returns.")
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
                        new(AmTera, "neutral", "Sorry Drake, your fortune is about to go kaplooey."),
                        new(AmDrake, "squint", "What?")
                    ]
                }},
            });
        }
    }
}
