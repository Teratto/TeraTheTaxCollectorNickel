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
    internal class CardDialogue : IRegisterable
    {
        public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
        {
            LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>()
            {
                {
                    "EggToss_0",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["EggToss"],
                        oncePerRunTags = ["EggNormal"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmTera, "happy", "Egg time!")
                        ]
                    }
                },
                {
                    "EggToss_1",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["EggToss"],
                        oncePerRunTags = ["EggNormal"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmTera, "neutral", "Wonder where that came from.")
                        ]
                    }
                },
                {
                    "EggToss_2",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["EggToss"],
                        oncePerRunTags = ["EggNormal"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmTera, "egg", "I believe in you...")
                        ]
                    }
                },
                {
                    "EggToss_3",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["EggTOss"],
                        oncePerRunTags = ["EggNormal"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmTera, "happy", "Yolk 'em up!")
                        ]
                    }
                },
                 {
                    "EggToss_4",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["EggToss"],
                        oncePerRunTags = ["EggNormal"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmTera, "egg", "I believe in you...")
                        ]
                    }
                },
                 {
                    "EggToss_5",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmPeri],
                        lookup = ["EggToss"],
                        oncePerRunTags = ["EggNormal"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmPeri, "neutral", "Where did you find that egg?"),
                        new(AmTera, "lookaway", "I dunno.")
                        ]
                    }
                },
                 {
                    "EggToss_6",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmDizzy],
                        lookup = ["EggToss"],
                        oncePerRunTags = ["EggNormal"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmDizzy, "explains", "Using an egg to stun? That's genius."),
                        new(AmTera, "blush", "Thank you!")
                        ]
                    }
                },
                 {
                    "EggToss_7",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmRiggs],
                        lookup = ["EggToss"],
                        oncePerRunTags = ["EggNormal"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmRiggs, "squint", "Was that an... egg?"),
                        new(AmTera, "lookaway", "Maybe.")
                        ]
                    }
                },
                 {
                    "EggToss_8",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmDrake],
                        lookup = ["EggToss"],
                        oncePerRunTags = ["EggNormal"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmDrake, "squint", "You did not."),
                        new(AmTera, "neutral", "I did.")
                        ]
                    }
                },
                 {
                    "EggToss_9",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmIsaac],
                        lookup = ["EggToss"],
                        oncePerRunTags = ["EggNormal"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmIsaac, "shy", "It smells like egg in here."),
                        new(AmTera, "neutral", "Wonder how that could have happened.")
                        ]
                    }
                },
                 {
                    "EggToss_10",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmMax],
                        lookup = ["EggToss"],
                        oncePerRunTags = ["EggNormal"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmMax, "smile", "Woa. Egg."),
                        new(AmTera, "happy", "Egg indeed!")
                        ]
                    }
                },
                 {
                    "EggToss_11",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmBooks],
                        lookup = ["EggToss"],
                        oncePerRunTags = ["EggNormal"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmBooks, "paws", "I want eggs for breakfast!"),
                        new(AmTera, "sad", "Books! No!")
                        ]
                    }
                },
                 {
                    "EggToss_12",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmCat],
                        lookup = ["EggToss"],
                        oncePerRunTags = ["EggNormal"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmCat, "neutral", "I thought male birds don't lay-"),
                        new(AmTera, "squint", "Shut it, CAT.")
                        ]
                    }
                },
                 {
                    "EggShells_0",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["EggShells"],
                        oncePerRunTags = ["EggHurtie"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmTera, "happy", "How 'bout another!")
                        ]
                    }
                },
                 {
                    "EggShells_1",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["EggShells"],
                        oncePerRunTags = ["EggHurtie"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmTera, "happy", "Yeah! Eat it!")
                        ]
                    }
                },
                 {
                    "EggShells_2",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmPeri],
                        lookup = ["EggShells"],
                        oncePerRunTags = ["EggHurtie"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmPeri, "mad", "Tera, stop shooting eggs out of our cannons."),
                        new(AmTera, "lookawaynervous", "It's a valid tactical maneuver!")
                        ]
                    }
                },
                 {
                    "EggShells_3",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmDizzy],
                        lookup = ["EggShells"],
                        oncePerRunTags = ["EggHurtie"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmDizzy, "neutral", "How did you load shells into the cannon?"),
                        new(AmTera, "lookaway", "It takes a few hours.")
                        ]
                    }
                },
                 {
                    "EggShells_4",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmRiggs],
                        lookup = ["EggShells"],
                        oncePerRunTags = ["EggHurtie"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmRiggs, "neutral", "Are eggs supposed to hurt?"),
                        new(AmTera, "neutral", "Only when you throw them really, really hard.")
                        ]
                    }
                },
                {
                    "EggShells_5",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmDrake],
                        lookup = ["EggShells"],
                        oncePerRunTags = ["EggHurtie"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmDrake, "squint", "Tera, PLEASE stop hogging up the fridge."),
                        new(AmTera, "sad", "But my eggs need a place to sleep!")
                        ]
                    }
                },
                {
                    "EggShells_6",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmIsaac],
                        lookup = ["EggShells"],
                        oncePerRunTags = ["EggHurtie"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmIsaac, "neutral", "I wonder if I can load eggs into my drones."),
                        new(AmTera, "neutral", "If you need ammo, I know where to find some.")
                        ]
                    }
                },
                {
                    "EggShells_7",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmMax],
                        lookup = ["EggShells"],
                        oncePerRunTags = ["EggHurtie"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmMax, "neutral", "Wonder if this is an easter egg."),
                        new(AmTera, "neutral", "No, it's just a bird egg.")
                        ]
                    }
                },
                {
                    "EggShells_8",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmBooks],
                        lookup = ["EggShells"],
                        oncePerRunTags = ["EggHurtie"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmBooks, "stoked", "You're eggselent!"),
                        new(AmTera, "happy", "And you're eggceptional!")
                        ]
                    }
                },
                {
                    "EggShells_9",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmCat],
                        lookup = ["EggShells"],
                        oncePerRunTags = ["EggHurtie"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmCat, "grumpy", "These eggs are getting out of control."),
                        new(AmTera, "lookaway", "...I didn't do it.")
                        ]
                    }
                },
                {
                    "Desperation_0",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Desperation"],
                        oncePerRunTags = ["Desperation"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmTera, "scared", "W-wait, we're doing this now?")
                        ]
                    }
                },
                {
                    "Desperation_1",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Desperation"],
                        oncePerRunTags = ["Desperation"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmTera, "lookawaynervous", "Let's hope this works...")
                        ]
                    }
                },
                {
                    "Desperation_2",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Desperation"],
                        oncePerRunTags = ["Desperation"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmTera, "closed", "Desperate times call for desperate measures.")
                        ]
                    }
                },
                {
                    "Desperation_3",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmDrake],
                        lookup = ["Desperation"],
                        oncePerRunTags = ["Desperation"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmTera, "lookawaynervous", "I hope this plan works."),
                        new(AmDrake, "squint", "It better.")
                        ]
                    }
                },
                {
                    "Desperation_4",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmPeri],
                        lookup = ["Desperation"],
                        oncePerRunTags = ["Desperation"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmPeri, "neutral", "It's time to unleash some firepower."),
                        new(AmTera, "lookawaynervous", "I hope it's worth the price."),
                        
                        ]
                    }
                },
                {
                    "Desperation_5",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Desperation"],
                        oncePerRunTags = ["Desperation"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmTera, "closed", "Just breathe. Everything is gonna be okay.")

                        ]
                    }
                },
                {
                    "Tenacity_0",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Tenacity"],
                        oncePerRunTags = ["Tenacity"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmTera, "closed", "Give me a second to think.")
                        ]
                    }
                },
                {
                    "Tenacity_1",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Tenacity"],
                        oncePerRunTags = ["Tenacity"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmTera, "closed", "I can do this. I know I can. Just gotta breathe.")
                        ]
                    }
                },
                {
                    "Tenacity_2",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmPeri],
                        lookup = ["Tenacity"],
                        oncePerRunTags = ["Tenacity"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmPeri, "neutral", "Tera, your face lit up. Got a plan?"),
                        new(AmTera, "happy", "Yeah! I just got a buncha new ideas.")
                        ]
                    }
                },
                {
                    "Tenacity_3",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmDrake],
                        lookup = ["Tenacity"],
                        oncePerRunTags = ["Tenacity"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmDrake, "neutral", "All of your forms are making a mess."),
                        new(AmTera, "happytaxes", "But these forms are flowing with ideas.")
                        ]
                    }
                },
                {
                    "Tenacity_4",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera,],
                        lookup = ["Tenacity"],
                        oncePerRunTags = ["Tenacity"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmTera, "taxes", "Hmm... I think there's something here. Gimme a sec.")
                        ]
                    }
                },
                {
                    "Breakout_0",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera,],
                        lookup = ["Breakout"],
                        oncePerRunTags = ["Breakout"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmTera, "happytaxes", "Gotta hit 'em where it hurts.")
                        ]
                    }
                },
                {
                    "Breakout_1",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera,],
                        lookup = ["Breakout"],
                        oncePerRunTags = ["Breakout"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmTera, "happy", "It's my lucky break!")
                        ]
                    }
                },
                {
                    "Breakout_2",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera,],
                        lookup = ["Breakout"],
                        oncePerRunTags = ["Breakout"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmTera, "happy", "Yeah yeah! Let's get 'em!")
                        ]
                    }
                },
                {
                    "Breakout_3",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmIsaac],
                        lookup = ["Breakout"],
                        oncePerRunTags = ["Breakout"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmTera, "happy", "Time to get some payback!"),
                        new(AmIsaac, "explains", "They're the ones paying us back, obviously.")
                        ]
                    }
                },
                {
                    "Breakout_4",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmCat],
                        lookup = ["Breakout"],
                        oncePerRunTags = ["Breakout"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmTera, "neutral", "This should help a ton."),
                        new(AmCat, "squint", "I still don't know how your tax works.")
                        ]
                    }
                },
                {
                    "Breakout_5",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera,],
                        lookup = ["Breakout"],
                        oncePerRunTags = ["Breakout"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmTera, "happytaxes", "Things are lookin' up for us.")
                        ]
                    }
                },
                {
                    "Forgiveness_0",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera,],
                        lookup = ["Forgiveness"],
                        oncePerRunTags = ["Forgiveness"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmTera, "closed", "You've been pardoned.")
                        ]
                    }
                },
                {
                    "Forgiveness_1",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmDizzy],
                        lookup = ["Forgiveness"],
                        oncePerRunTags = ["Forgiveness"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmDizzy, "neutral", "Does this mean you forgive me for exploding the Cobalt?"),
                        new(AmTera, "squint", "Not even close.")
                        ]
                    }
                },
                {
                    "Forgiveness_2",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera, AmDrake],
                        lookup = ["Forgiveness"],
                        oncePerRunTags = ["Forgiveness"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmTera, "neutral", "We all make mistakes sometimes."),
                        new(AmDrake, "squint", "Why are you staring at me?")
                        ]
                    }
                },
                {
                    "Forgiveness_3",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Forgiveness"],
                        oncePerRunTags = ["Forgiveness"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmTera, "blush", "Doing nice things makes me feel all giddy.")
                        ]
                    }
                },
                {
                    "Forgiveness_4",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Forgiveness"],
                        oncePerRunTags = ["Forgiveness"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmTera, "taxes", "Just this once, I'll let you slip up on your taxes.")
                        ]
                    }
                },
                {
                    "Forgiveness_5",
                    new()
                    {
                        type = NodeType.combat,
                        allPresent = [AmTera],
                        lookup = ["Forgiveness"],
                        oncePerRunTags = ["Forgiveness"],
                        oncePerRun = true,
                        dialogue = [
                        new(AmTera, "neutral", "Let me ease up on their payments for a bit.")
                        ]
                    }
                },
            });
        }
    }
}
