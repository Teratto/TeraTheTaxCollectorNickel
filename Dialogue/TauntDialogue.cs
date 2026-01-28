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
    internal class TauntDialogue : IRegisterable
    {
        public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
        {
            LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>()
            {
                {
                    "Taunt_0",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "happy", "You're an egg smeller!")
                        ]
                    }
                },
                {
                    "Taunt_1",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "happy", "You taste like onions!")
                        ]
                    }
                },
                {
                    "Taunt_2",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "happy", "You have a tiny brain!")
                        ]
                    }
                },
                {
                    "Taunt_3",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "happy", "You can't pay your taxes on time!")
                        ]
                    }
                },
                {
                    "Taunt_4",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "happy", "You're gonna have a fiscal year!")
                        ]
                    }
                },
                {
                    "Taunt_5",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "happy", "I bet your taxes look like butt!")
                        ]
                    }
                },
                {
                    "Taunt_6",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "squint", "You look like a furry.")
                        ]
                    }
                },
                {
                    "Taunt_7",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "lookaway", "You look like you failed flight school. Yup. Definitely you.")
                        ]
                    }
                },
                {
                    "Taunt_8",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "squint", "I bet you like science stuff.")
                        ]
                    }
                },
                {
                    "Taunt_9",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "happy", "You should try being us next time!")
                        ]
                    }
                },
                {
                    "Taunt_10",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "happy", "That guy over there is worse than a space pirate!"),
                        new(AmDrake, "neutral", "I'll take the compliment.")
                        ]
                    }
                },
                {
                    "Taunt_11",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "squint", "You're... uh... aw beans, I can't think of anything.")
                        ]
                    }
                },
                {
                    "Taunt_12",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "happy", "You're short!")
                        ]
                    }
                },
                {
                    "Taunt_13",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "lookawaynervous", "You, um, look like a bird??? Listen, insults are hard.")
                        ]
                    }
                },
                {
                    "Taunt_14",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "happy", "You look like grumpy grass on a wind farm!")
                        //have every person just say "what."
                        ]
                    }
                },
                {
                    "Taunt_15",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "happy", "You smell like a bad hair day!")
                        ]
                    }
                },
                {
                    "Taunt_16",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "happy", "You probably were hatched from an egg!")
                        ]
                    }
                },
                {
                    "Taunt_17",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "happy", "I bet you're a gamer! Boo!")
                        ]
                    }
                },
                {
                    "Taunt_18",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "happytaxes", "Heh, your tax return is SO small.")
                        ]
                    }
                },
                {
                    "Taunt_19",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "happy", "Your mom is probably very lovely!")
                        ]
                    }
                },
                {
                    "Taunt_20",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "squint", "You, erm... aren't good at video games?")
                        ]
                    }
                },
                {
                    "Taunt_21",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "squint", "Hey, you... wait, no... ugh, nevermind.")
                        ]
                    }
                },
                {
                    "Taunt_22",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "squint", "You look like a mobile game ad.")
                        ]
                    }
                },
                {
                    "Taunt_23",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "happytaxes", "I'm gonna tax you so frickin' hard.")
                        ]
                    }
                },
                {
                    "Taunt_24",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "happy", "Stinky!")
                        ]
                    }
                },
                {
                    "Taunt_25",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "happy", "Stupid!")
                        ]
                    }
                },
                {
                    "Taunt_26",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "happy", "Dummy!")
                        ]
                    }
                },
                {
                    "Taunt_27",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "happy", "Stinky!")
                        ]
                    }
                },
                {
                    "Taunt_28",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "happy", "Your nose looks funny!")
                        ]
                    }
                },
                {
                    "Taunt_29",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "squint", "Your ship sucks at literally everything.")
                        ]
                    }
                },
                {
                    "Taunt_30",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "lookaway", "I'm out of ideas. Can you insult yourself this time?")
                        ]
                    }
                },
                {
                    "Taunt_31",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "squint", "Ugh, you're so BORING.")
                        ]
                    }
                },
                {
                    "Taunt_32",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "lookaway", "I wish I could avoid you as much as people avoid taxes.")
                        ]
                    }
                },
                {
                    "Taunt_33",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "happy", "You're a goober!")
                        ]
                    }
                },
                {
                    "Taunt_34",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "happy", "You breathe too much!")
                        ]
                    }
                },
                {
                    "Taunt_35",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "taxes", "Hmm.. this paper says you're a butthead.")
                        ]
                    }
                },
                {
                    "Taunt_36",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "neutral", "You don't even deserve an insult.")
                        ]
                    }
                },
                {
                    "Taunt_37",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "neutral", "Just like, go look in a mirror or something.")
                        ]
                    }
                },
                {
                    "Taunt_38",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                        new(AmTera, "happy", "You breathe too much!")
                        ]
                    }
                },
            });
        }
    }
}
