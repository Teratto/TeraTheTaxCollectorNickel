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
    internal class EventDialogue : IRegisterable
    {
        public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
        {
            LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>()
            {
            {$"ChoiceCardRewardOfYourColorChoice_{AmTera}", new(){
                type = NodeType.@event,
                oncePerRun = true,
                allPresent = [AmTera],
                bg = "BGBootSequence",
                dialogue = [
                    new(AmTera, "squint", "Eugh, let's never do that again."),
                    new(AmCat, "Energy readings are back to normal.")
                ]
            }},
            {$"Pirate_Infinite_AfterCrew_Multi_Tera_0", new(){
                type = NodeType.@event,
                lookup = ["before_pirate"],
                once = false,
                priority = false,
                requireCharsUnlocked = ["eunice"],
                requiredScenes = ["pirate_1"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmDrake, "Ready for your final lesson?", flipped: true),
                    new(AmTera, "I-I guess so.")
                ]
            }},
            {$"Pirate_Infinite_AfterCrew_Multi_Tera_1", new(){
                type = NodeType.@event,
                lookup = ["before_pirate"],
                once = false,
                priority = false,
                requireCharsUnlocked = ["eunice"],
                requiredScenes = ["pirate_1"],
                allPresent = [AmTera],
                dialogue = [
                    new(AmTera, "lookawaynervous", "D-Do we really have to do this?"),
                    new(AmDrake, "Gotta prove who's the better pirate.", flipped: true)
                ]
            }},
            {"Sasha_2_Multi_2", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmTera, "squint", "S-sports?")
                ]
            }},
            {"ShopkeeperInfinite_Tera_Multi_0", new(){
                type = NodeType.@event,
                lookup = [ "shopBefore" ],
                bg = "BGShop",
                allPresent = [ AmTera ],
                dialogue = [
                    new(AmShopkeeper, "Hey Tera! Gonna try and tax me again?", true),
                    new(AmTera, "squint", "I'm watching you."),
                    new(new Jump{key = "NewShop"})
                ]
            }},
            {"ShopkeeperInfinite_Tera_Multi_1", new(){
                type = NodeType.@event,
                lookup = [ "shopBefore" ],
                bg = "BGShop",
                allPresent = [ AmTera ],
                dialogue = [
                    new(AmShopkeeper, "Taxbird! You know you can't tax free, right?", true),
                    new(AmTera, "squint", "Something fishy is going on here, I just know it."),
                    new(new Jump{key = "NewShop"})
                ]
            }},
            {"ShopkeeperInfinite_Tera_Multi_2", new(){
                type = NodeType.@event,
                lookup = [ "shopBefore" ],
                bg = "BGShop",
                allPresent = [ AmTera ],
                dialogue = [
                    new(AmShopkeeper, "Hey.", true),
                    new(AmTera, "squint", "...Hey."),
                    new(new Jump{key = "NewShop"})
                ]
            }},
            });
        }
    }
}
