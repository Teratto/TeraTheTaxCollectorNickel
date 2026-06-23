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
    internal class TeraGarrusDialogue : IRegisterable
    {
        public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
        {
            LocalDB.DumpStoryToLocalLocale("en", "Vintage.VicCharacter", new Dictionary<string, DialogueMachine>()
            {
                {
                    "Tenacity_Garrus_0",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmGarrus],
                        lookup = ["Tenacity"],
                        oncePerCombatTags = ["Tenacity"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmGarrus, "neutraltalk", "Tera. Status report."),
                        new(AmTera, "taxes", "Gimme some time. I'm thinking right now."),
                        
                        ]
                    }
                },
                {
                    "EggToss_Garrus_0",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmGarrus],
                        lookup = ["EggToss"],
                        oncePerCombatTags = ["EggNormal"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmGarrus, "pressured", "How did you... what?!"),
                        new(AmTera, "lookaway", "Don't worry about it.")
                        ]
                    }
                },
                {
                    "EggShells_Garrus_0",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmGarrus],
                        lookup = ["EggShells"],
                        oncePerRunTags = ["EggHurtie"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmGarrus, "annoyed", "...Do I want to know how you're doing this?"),
                        new(AmTera, "squint", "Shut it and fly, bird man.")
                        ]
                    }
                },
                {
                    "SpareCash_Garrus_0",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmGarrus],
                        lookup = ["SpareCash"],
                        oncePerRunTags = ["SpareCash"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmGarrus, "neutraltalk", "Your funding should support our flight."),
                        new(AmTera, "scared", "MY funding?")
                        ]
                    }
                },
                {"ArtifactEarlyBird_Multi_Tera_1", new(){
                dialogue = [
                    new(),
                    new(AmGarrus, "doubtful", "...I'm not hungry.")
                ]
                }},
                {"ArtifactFlightTraining_Multi_Tera_1", new(){
                dialogue = [
                    new(),
                    new(AmGarrus, "doubtful", "You are no longer permitted to steer.")
                ]
                }},
                {"ManyTurns_Multi_Tera_0", new(){
                dialogue = [
                    new(),
                    new(AmGarrus, "annoyed", "Please do not face in my direction.")
                ]
                }},
                {
                    "TeraWentMissing_Garrus_0",
                    new()
                    {
                        type = NodeType.combat,
                        priority = true,
                        lastTurnPlayerStatuses = [MissingTera],
                        oncePerRun = true,
                        oncePerCombatTags = ["teraWentMissing"],
                        allPresent = [AmGarrus],
                        dialogue = [
                        new(AmGarrus, "pressured", "You alright Tera? You're shivering under the console."),
                        ]
                    }
                },
                {
                    "TeraWentMissing_Garrus_1",
                    new()
                    {
                        type = NodeType.combat,
                        priority = true,
                        lastTurnPlayerStatuses = [MissingTera],
                        oncePerRun = true,
                        oncePerCombatTags = ["teraWentMissing"],
                        allPresent = [AmGarrus],
                        dialogue = [
                        new(AmGarrus, "annoyed", "Tera, get away from my chair."),
                        ]
                    }
                },
                {"Duo_AboutToDieAndLoop_Multi_Tera_Garrus_0", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerRun = true,
                    oncePerCombatTags = ["aboutToDie"],
                    allPresent = [AmTera, AmGarrus],
                    dialogue = [
                        new(AmTera, "scared", "The ship is making some bad noises..."),
                        new(AmGarrus, "determined", "This isn't the end yet.")
                    ]
                }},
                {"Duo_AboutToDieAndLoop_Multi_Tera_Garrus_1", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerRun = true,
                    oncePerCombatTags = ["aboutToDie"],
                    allPresent = [AmTera, AmGarrus],
                    dialogue = [
                        new(AmGarrus, "pressured", "This might be the end of the line."),
                        new(AmTera, "scared", "Garrus? Don't say that!")
                    ]
                }},
            });
        }
    }
}
