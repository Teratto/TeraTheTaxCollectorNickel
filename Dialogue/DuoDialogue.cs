using Nanoray.PluginManager;
using Nickel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeraTaxMod.Artifacts;
using TeraTaxMod.External;
using static TeraTaxMod.Dialogue.CommonDefinitions;

namespace TeraTaxMod.Dialogue
{
    internal class TeraDuoDialogue : IRegisterable
    {
        public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
        {
            LocalDB.DumpStoryToLocalLocale("en","Shockah.DuoArtifacts", new Dictionary<string, DialogueMachine>()
            {
                {"ArtifactFireSale_Multi_Tera_0", new()
                {
                    type = NodeType.combat,
                    hasArtifactTypes = [typeof(FireSale)],
                    oncePerRun = true,
                    turnStart = true,
                    oncePerRunTags = ["FireSale"],
                    maxTurnsThisCombat = 1,
                    allPresent = [AmTera, AmDrake],
                    dialogue = [
                        new(AmTera, "taxes", "Ready to burn everything to the ground?"),
                        new(AmDrake, "sly", "Way ahead of you.")
                        ]
                }},
                {"ArtifactFireSale_Multi_Tera_1", new()
                {
                    type = NodeType.combat,
                    hasArtifactTypes = [typeof(FireSale)],
                    oncePerRun = true,
                    turnStart = true,
                    oncePerRunTags = ["FireSale"],
                    maxTurnsThisCombat = 1,
                    allPresent = [AmTera, AmDrake],
                    dialogue = [
                        new(AmTera, "happy", "Drake! We make such a good team!"),
                        new(AmDrake, "slyBlush", "Yeah, yeah.")
                        ]
                }},
                {"ArtifactFireSale_Multi_Tera_2", new()
                {
                    type = NodeType.combat,
                    hasArtifactTypes = [typeof(FireSale)],
                    oncePerRun = true,
                    turnStart = true,
                    oncePerRunTags = ["FireSale"],
                    maxTurnsThisCombat = 1,
                    allPresent = [AmTera, AmDrake],
                    dialogue = [
                        new(AmDrake, "sly", "We're bringing trouble."),
                        new(AmTera, "happy", "And make it double!")
                        ]
                }},
                {"ArtifactFireSale_Multi_Tera_3", new()
                {
                    type = NodeType.combat,
                    hasArtifactTypes = [typeof(FireSale)],
                    oncePerRun = true,
                    turnStart = true,
                    oncePerRunTags = ["FireSale"],
                    maxTurnsThisCombat = 1,
                    allPresent = [AmTera, AmDrake],
                    dialogue = [
                        new(AmDrake, "sly", "Keep on printing money, Tera."),
                        new(AmTera, "happytaxes", "Totally not illegal.")
                        ]
                }},
                {"ArtifactMonetaryShock_Multi_Tera_0", new()
                {
                    type = NodeType.combat,
                    hasArtifactTypes = [typeof(MonetaryShock)],
                    oncePerRun = true,
                    turnStart = true,
                    oncePerRunTags = ["MonetaryShock"],
                    maxTurnsThisCombat = 1,
                    allPresent = [AmTera, AmDizzy],
                    dialogue = [
                        new(AmTera, "scared", "What did you do to my console?"),
                        new(AmDizzy, "explains", "Made it work, of course.")
                        ]
                }},
                {"ArtifactMonetaryShock_Multi_Tera_1", new()
                {
                    type = NodeType.combat,
                    hasArtifactTypes = [typeof(MonetaryShock)],
                    oncePerRun = true,
                    turnStart = true,
                    oncePerRunTags = ["MonetaryShock"],
                    maxTurnsThisCombat = 1,
                    allPresent = [AmTera, AmDizzy],
                    dialogue = [
                        new(AmTera, "neutral", "Time to rock the market."),
                        new(AmDizzy, "squint", "My HUD is going crazy.")
                        ]
                }},
                {"ArtifactWireTransfer_Multi_Tera_0", new()
                {
                    type = NodeType.combat,
                    hasArtifactTypes = [typeof(WireTransfer)],
                    oncePerRun = true,
                    turnStart = true,
                    oncePerRunTags = ["Economics"],
                    maxTurnsThisCombat = 1,
                    allPresent = [AmTera, AmCat],
                    dialogue = [
                        new(AmCat, "squint", "I don't like integrating taxes into the main console."),
                        new(AmTera, "happytaxes", "This'll work. Trust me.")
                        ]
                }},
                {"ArtifactWireTransfer_Multi_Tera_1", new()
                {
                    type = NodeType.combat,
                    hasArtifactTypes = [typeof(WireTransfer)],
                    oncePerRun = true,
                    turnStart = true,
                    oncePerRunTags = ["Economics"],
                    maxTurnsThisCombat = 1,
                    allPresent = [AmTera, AmCat],
                    dialogue = [
                        new(AmTera, "taxes", "I think this should help."),
                        new(AmCat, "mad", "Did you just... Tax my CPU???")
                        ]
                }},
                {"ArtifactWireTransfer_Multi_Tera_2", new()
                {
                    type = NodeType.combat,
                    hasArtifactTypes = [typeof(WireTransfer)],
                    oncePerRun = true,
                    turnStart = true,
                    oncePerRunTags = ["Economics"],
                    maxTurnsThisCombat = 1,
                    allPresent = [AmTera, AmCat],
                    dialogue = [
                        new(AmCat, "mad", "Did you just... put the stock trade on the console?"),
                        new(AmTera, "taxes", "Need to watch the markets.")
                        ]
                }},
                {"ArtifactYearlyCycle_Multi_Tera_0", new()
                {
                    type = NodeType.combat,
                    hasArtifactTypes = [typeof(YearlyCycle)],
                    oncePerRun = true,
                    turnStart = true,
                    oncePerRunTags = ["YearlyCycle"],
                    maxTurnsThisCombat = 1,
                    allPresent = [AmTera, AmRiggs],
                    dialogue = [
                        new(AmTera, "happy", "Gotta do your monthly payments!"),
                        new(AmRiggs, "neutral", "I have to pay?")
                        ]
                }},
                {"ArtifactYearlyCycle_Multi_Tera_1", new()
                {
                    type = NodeType.combat,
                    hasArtifactTypes = [typeof(YearlyCycle)],
                    oncePerRun = true,
                    turnStart = true,
                    oncePerRunTags = ["YearlyCycle"],
                    maxTurnsThisCombat = 1,
                    allPresent = [AmTera, AmRiggs],
                    dialogue = [
                        new(AmRiggs, "neutral", "So what happens every year in April?"),
                        new(AmTera, "happytaxes", "The best day of my life.")
                        ]
                }},
                {"ArtifactAssetLiquidation_Multi_Tera_0", new()
                {
                    type = NodeType.combat,
                    hasArtifactTypes = [typeof(AssetLiquidation)],
                    oncePerRun = true,
                    turnStart = true,
                    oncePerRunTags = ["AssetLiquidation"],
                    maxTurnsThisCombat = 1,
                    allPresent = [AmTera, AmMax],
                    dialogue = [
                        new(AmTera, "neutral", "Time to tie up some loose ends."),
                        new(AmMax, "neutral", "And get paid for it, too.")
                        ]
                }},
                {"ArtifactAssetLiquidation_Multi_Tera_1", new()
                {
                    type = NodeType.combat,
                    hasArtifactTypes = [typeof(AssetLiquidation)],
                    oncePerRun = true,
                    turnStart = true,
                    oncePerRunTags = ["AssetLiquidation"],
                    maxTurnsThisCombat = 1,
                    allPresent = [AmTera, AmMax],
                    dialogue = [
                        new(AmTera, "lookaway", "Hooked up your console with some wire tapping."),
                        new(AmMax, "neutral", "Rad.")
                        ]
                }},
                {"ArtifactImprovisation_Multi_Tera_0", new()
                {
                    type = NodeType.combat,
                    hasArtifactTypes = [typeof(AssetLiquidation)],
                    oncePerRun = true,
                    turnStart = true,
                    oncePerRunTags = ["Improvisation"],
                    maxTurnsThisCombat = 1,
                    allPresent = [AmTera, AmIsaac],
                    dialogue = [
                        new(AmIsaac, "squint", "What did you do to Isaac Jr.?"),
                        new(AmTera, "happytaxes", "Made him better, of course.")
                        ]
                }},
                {"ArtifactImprovisation_Multi_Tera_1", new()
                {
                    type = NodeType.combat,
                    hasArtifactTypes = [typeof(AssetLiquidation)],
                    oncePerRun = true,
                    turnStart = true,
                    oncePerRunTags = ["Improvisation"],
                    maxTurnsThisCombat = 1,
                    allPresent = [AmTera, AmIsaac],
                    dialogue = [
                        new(AmTera, "happy", "Stuffing this drone full of cash should do the trick!"),
                        new(AmIsaac, "squint", "I don't know if that's going to work.")
                        ]
                }},
                {"ArtifactImprovisation_Multi_Tera_2", new()
                {
                    type = NodeType.combat,
                    hasArtifactTypes = [typeof(AssetLiquidation)],
                    oncePerRun = true,
                    turnStart = true,
                    oncePerRunTags = ["Improvisation"],
                    maxTurnsThisCombat = 1,
                    allPresent = [AmTera, AmIsaac],
                    dialogue = [
                        new(AmTera, "happy", "We'll call these drones... IRIS!"),
                        new(AmIsaac, "shy", "Yeah, sure.")
                        ]
                }},
                {"ArtifactScrutiny_Multi_Tera_0", new()
                {
                    type = NodeType.combat,
                    hasArtifactTypes = [typeof(Scrutiny)],
                    oncePerRun = true,
                    turnStart = true,
                    oncePerRunTags = ["Scrutiny"],
                    maxTurnsThisCombat = 1,
                    allPresent = [AmTera, AmPeri],
                    dialogue = [
                        new(AmTera, "happytaxes", "Time to get what we're owed."),
                        new(AmPeri, "vengeful", "Let's take them down!")
                        ]
                }},
                {"ArtifactScrutiny_Multi_Tera_1", new()
                {
                    type = NodeType.combat,
                    hasArtifactTypes = [typeof(Scrutiny)],
                    oncePerRun = true,
                    turnStart = true,
                    oncePerRunTags = ["Scrutiny"],
                    maxTurnsThisCombat = 1,
                    allPresent = [AmTera, AmPeri],
                    dialogue = [
                        new(AmPeri, "vengeful", "Time to waste them!"),
                        new(AmTera, "happy", "Let's beat them up!")
                        ]
                }},
                {"ArtifactGemstonePrinter_Multi_Tera_0", new()
                {
                    type = NodeType.combat,
                    hasArtifactTypes = [typeof(GemstonePrinter)],
                    oncePerRun = true,
                    turnStart = true,
                    oncePerRunTags = ["GemstonePrinter"],
                    maxTurnsThisCombat = 1,
                    allPresent = [AmTera, AmBooks],
                    dialogue = [
                        new(AmTera, "taxes", "Books, I think I can use your extra shards."),
                        new(AmBooks, "crystal", "Sure thing! Let's do this!")
                        ]
                }},
                {"ArtifactGemstonePrinter_Multi_Tera_1", new()
                {
                    type = NodeType.combat,
                    hasArtifactTypes = [typeof(GemstonePrinter)],
                    oncePerRun = true,
                    turnStart = true,
                    oncePerRunTags = ["GemstonePrinter"],
                    maxTurnsThisCombat = 1,
                    allPresent = [AmTera, AmBooks],
                    dialogue = [
                        new(AmBooks, "stoked", "Shards are gonna start overflowing!"),
                        new(AmTera, "happy", "Let's use them to their advantage!")
                        ]
                }},
            });
        }
    }
}
