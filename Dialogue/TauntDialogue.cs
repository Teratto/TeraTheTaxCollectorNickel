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
                    "VicRemember_0",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Taunt"],
                        oncePerCombatTags = ["Taunt"],
                        oncePerCombat = true,
                        dialogue = [
                  new(AmTera, "happy", "Uhh, you're an egg smeller!")
                ]
                    }
                },
            });
        }
    }
}
