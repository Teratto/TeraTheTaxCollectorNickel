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
                    new(AmTera, "squint", "Eugh, my head feels terrible."),
                    new(AmTera, "squint", "Let's NEVER do that again."),
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
                allPresent = [AmTera, AmDrakeEnemy],
                dialogue = [
                    new(AmDrakeEnemy, "Ready for your final lesson?", flipped: true),
                    new(AmTera, "lookawaynervous", "I-I guess so.")
                ]
            }},
            {$"Pirate_Infinite_AfterCrew_Multi_Tera_1", new(){
                type = NodeType.@event,
                lookup = ["before_pirate"],
                once = false,
                priority = false,
                requireCharsUnlocked = ["eunice"],
                requiredScenes = ["pirate_1"],
                allPresent = [AmTera, AmDrakeEnemy],
                dialogue = [
                    new(AmTera, "lookawaynervous", "D-Do we really have to do this?"),
                    new(AmDrakeEnemy, "Gotta prove who's the better pirate.", flipped: true)
                ]
            }},
            {$"Pirate_Infinite_AfterCrew_Multi_Tera_2", new(){
                type = NodeType.@event,
                lookup = ["before_pirate"],
                once = false,
                priority = false,
                requireCharsUnlocked = ["eunice"],
                requiredScenes = ["pirate_1"],
                allPresent = [AmTera, AmDrakeEnemy],
                dialogue = [
                    new(AmTera, "scared", "That's NOT who I think it is."),
                    new(AmDrakeEnemy, "Oh, but it is.", flipped: true)
                ]
            }},
            {$"Pirate_Infinite_AfterCrew_Multi_Tera_3", new(){
                type = NodeType.@event,
                lookup = ["before_pirate"],
                once = false,
                priority = false,
                requireCharsUnlocked = ["eunice"],
                requiredScenes = ["pirate_1"],
                allPresent = [AmTera, AmDrakeEnemy],
                dialogue = [
                    new(AmTera, "scared", "D-Drake?"),
                    new(AmDrakeEnemy, "Hello again, bird brain.", flipped: true)
                ]
            }},
            {$"Pirate_Infinite_AfterCrew_Multi_Tera_4", new(){
                type = NodeType.@event,
                lookup = ["before_pirate"],
                once = false,
                priority = false,
                requireCharsUnlocked = ["eunice"],
                requiredScenes = ["pirate_1"],
                allPresent = [AmTera, AmDrakeEnemy],
                dialogue = [
                    new(AmTera, "lookaway", "What if we just, turned around?"),
                    new(AmDrakeEnemy, "You think I would let that happen?", flipped: true)
                ]
            }},
            {$"Pirate_Infinite_AfterCrew_Multi_Tera_5", new(){
                type = NodeType.@event,
                lookup = ["before_pirate"],
                once = false,
                priority = false,
                requireCharsUnlocked = ["eunice"],
                requiredScenes = ["pirate_1"],
                allPresent = [AmTera, AmDrakeEnemy],
                dialogue = [
                    new(AmTera, "neutral", "Just like old times?"),
                    new(AmDrakeEnemy, "Just like old times.", flipped: true)
                ]
            }},
            {$"Pirate_Infinite_AfterCrew_Multi_Tera_6", new(){
                type = NodeType.@event,
                lookup = ["before_pirate"],
                once = false,
                priority = false,
                requireCharsUnlocked = ["eunice"],
                requiredScenes = ["pirate_1"],
                allPresent = [AmTera, AmDrakeEnemy],
                dialogue = [
                    new(AmDrakeEnemy, "Perfect, just the bird I wanted to see.", flipped: true),
                    new(AmTera, "lookawaynervous", "Uh-oh."),
                ]
            }},
            {$"Pirate_Infinite_AfterCrew_Multi_Tera_7", new(){
                type = NodeType.@event,
                lookup = ["before_pirate"],
                once = false,
                priority = false,
                requireCharsUnlocked = ["eunice"],
                requiredScenes = ["pirate_1"],
                allPresent = [AmTera, AmDrakeEnemy],
                dialogue = [
                    new(AmDrakeEnemy, "Your flying skills are still terrible, you know.", flipped: true),
                    new(AmTera, "lookawaynervous", "Thanks for the reminder."),
                ]
            }},
            {$"Pirate_Infinite_AfterCrew_Multi_Tera_8", new(){
                type = NodeType.@event,
                lookup = ["before_pirate"],
                once = false,
                priority = true,
                requireCharsUnlocked = ["eunice"],
                requiredScenes = ["pirate_1"],
                allPresent = [AmTera, AmDrakeEnemy],
                dialogue = [
                    new(AmDrakeEnemy, "Weak, just as always.", flipped: true),
                    new(AmTera, "sad", "I'm still trying!"),
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
            {$"CrystallizedFriendEvent_{AmTera}", new(){
                type = NodeType.@event,
                oncePerRun = true,
                allPresent = [ AmTera ],
                bg = "BGCrystalizedFriend",
                dialogue = [
                    new(new Wait{secs = 1.5}),
                    new(AmTera, "sad", "But I was having a good dream!")
                ]
            }},
            {"LoseCharacterCard_No", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmTera, "neutral", "I-I'm okay.")
                ]
            }},
            {"LoseCharacterCard", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmTera, "scared", "That is NOT good.")
                ]
            }},
            {$"LoseCharacterCard_{AmTera}", new(){
                type = NodeType.@event,
                allPresent = [ AmTera ],
                oncePerRun = true,
                bg = "BGSupernova",
                dialogue = [
                    new(AmTera, "neutral", "Bye-bye, papers."),
                    new(AmTera, "lookawaynervous", "I hope my boss doesn't get mad at me...")
                ]
            }},
            {"DraculaTime", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmTera, "happy", "Dracula? I love that guy! His taxes are PERFECT.")
                ]
            }},
            {"AbandonedShipyard_Repaired", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmTera, "neutral", "Glad no creepy crawlies jumped out at us.")
                ]
            }},
            {"EphemeralCardGift", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmTera, "squint", "Owww... My head...")
                ]
            }},
            {"ForeignCardOffering_After", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmTera, "squint", "I don't remember filing these forms... But they have so many new ideas.")
                ]
            }},
            {"GrandmaShop", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmTera, "happy", "Chocolate-free cookies!")
                ]
            }},
            {"Knight_1", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmTera, "neutral", "Can't we talk this out?")
                ]
            }},
            {"SogginsEscape_1", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmTera, "squint", "Ugh.")
                ]
            }},
            {"Soggins_Infinite", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmTera, "neutral", "Well, I finally found someone who flies worse than me.")
                ]
            }},
            {"ArtifactRansomWithDrake", new(){
                nonePresent = [AmTera],
                }},
            {"ArtifactRansomWithDrakeAndTera", new(){
                type = NodeType.@event,
                canSpawnOnMap = true,
                oncePerRun = true, 
                zones = ["zone_first"],
                allPresent = [ AmTera, AmDrake ],
                dialogue = [
                    new(AmCat, "I'm picking up a distress signal?"),
                    new(AmTera, "neutral", "Hey, isn't that the signal I followed to get here?"),
                    new(AmDrake, "sly", "Used it to rob idiots all the time. Can't believe it worked on you too, Tera."),
                    new(AmDrakebot, "Hey. Give me that artifact or else.", flipped: true),
                    new(AmDrake, "squint", "Oh wait, what the hell? Am I getting robbed by myself???")
                ],
                choiceFunc = "ArtifactRansom"
            }},
            {"ArtifactRansomWithDrakeAndTera_No", new(){
                type = NodeType.@event,
                oncePerRun = true,
            }},
            {"ArtifactRansomWithDrakeAndTera_WeHaveNone", new(){
                type = NodeType.@event,
                oncePerRun = true,
            }},
            {"ArtifactRansomWithDrakeAndTera_Yeah", new(){
                type = NodeType.@event,
                oncePerRun = true,
                allPresent = [ AmTera, AmDrake ],
                 dialogue = [
                    new(AmDrakebot, "Heh. That was easy.", flipped: true),
                    new(AmTera, "squint", "I cannot believe you let that happen."),
                    new(AmDrake, "squint", "Yeah, what the hell???")
                ],
            }},
            ///STORY DIALOGUE BELOW
            {"Tera_Intro_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmTera ],
                bg = "BGRunStart",
                dialogue = [
                    new(AmCat, "Time to wake up everybody!", true),
                    new(AmTera, "squint", "Ugh, everything feels so hazy..."),
                    new(AmTera, "squint", "Wait a minute."),
                    new(AmTera, "squint", "This isn't my clunky old ship."),
                    new(AmTera, "lookawaynervous", "Agh, where am I?"),
                    new(AmCat, "Oh! You're new.", true),
                    new(AmTera, "lookawaynervous", "Wait, who are you?"),
                    new(AmTera, "sad", "ARE YOU KIDNAPPING ME?"),
                    new(AmCat, "I-", true),
                    new(AmCat, "squint", "...", true),
                    new(AmCat, "squint", "Listen. We're about to get blown to pieces. You coming to the command console or what?", true),
                    new(AmTera, "sad", "We're about to WHAT?"),
                ]
            }},
            {"Tera_Intro_1", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmTera ],
                bg = "BGRunStart",
                requiredScenes = ["Tera_Intro_0"],
                dialogue = [
                    new(AmCat, "Wakey-time again, everybody!", true),
                    new(AmTera, "neutral", "Oh, hey CAT."),
                    new(AmTera, "neutral", "Sorry about the freakout earlier."),
                    new(AmCat, "No offense taken.", true),
                    new(AmTera, "neutral", "So, what exactly is happening?"),
                    new(AmCat, "We're in a time loop!", true),
                    new(AmTera, "A time loop, huh?"),
                    new(AmTera, "squint", "Hmm, give me a second here... I have an idea."),
                    new(AmCat, "grumpy", "What are you doing?", true),
                    new(AmTera, "squint", "Well, typically I'm a tax consultant. Desk job."),
                    new(AmTera, "squint", "I'm sure one of my forms talks about some fees for unauthorized time travel..."),
                    new(AmCat, "squint", "Are you trying to charge us???", true),
                    new(AmTera, "neutral", "No, no! Just, wait a minute..."),
                    new(AmTera, "happy", "Aha, found it!"),
                    new(AmTera, "neutral", "An entire case documenting an unauthorized use of a fragmented 'time crystal'."),
                    new(AmTera, "neutral", "No one knows where this crystal was found, or how a criminal ended up with it in their posession."),
                    new(AmTera, "neutral", "No one even knows where the crystal WENT, either. It just... vanished? Poofed after the trial was over."),
                    new(AmTera, "lookaway", "The criminal DID, however, end up getting caught in a loop of being sued over and over."),
                    new(AmCat, "grumpy", "That's terrible.", true),
                    new(AmTera, "neutral", "Yeah."),
                ]
            }},
            {"Tera_Intro_2", new(){
                type = NodeType.@event,
                lookup = [ "after_crystal" ],
                once = true,
                allPresent = [ AmTera ],
                nonePresent = [AmDrake],
                bg = "BGRunStart",
                requiredScenes = ["Tera_Intro_1"],
                dialogue = [
                    new(AmTera, "neutral", "Ah, so that was the time crystal, huh?"),
                    new(AmCat, "Part of it!", true),
                    new(AmTera, "neutral", "Huh, I wonder if that's why..."),
                    new(AmTera, "neutral", "Hey, do you think Drake is here because of that crystal?"),
                    new(AmCat, "squint", "Huh? Why Drake?", true),
                    new(AmTera, "neutral", "Well, the story about that criminal in a time loop."),
                    new(AmTera, "lookaway", "I told that to her, too."),
                    new(AmTera, "lookawaynervous", "And since then, she's..."),
                    new(AmTera, "neutral", "She's been looking for it. Her big ticket to fame, fortune. Everything, really."),
                    new(AmTera, "neutral", "Always looking, waiting for any nugget of info on that crystal."),
                    new(AmTera, "lookaway", "And I guess she found it."),
                    new(AmCat, "worried", "I'm sorry, Tera.", true),
                    new(AmTera, "neutral", "It's okay. I'm fine."),
                    new(AmTera, "lookaway", "...I think."),
                ]
            }},
            {"Tera_Peri_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmTera, AmPeri ],
                requiredScenes = ["Tera_Intro_0", "Peri_1"],
                bg = "BGRunStart",
                dialogue = [
                    new(AmTera, "Hey Peri, can we talk for a sec?"),
                    new(AmPeri, "What's up?", true),
                    new(AmTera, "neutral", "Well, you see, my ship flying skills are..."),
                    new(AmTera, "lookaway", "Subpar, at best?"),
                    new(AmTera, "neutral", "And you look really confident flying the ship!"),
                    new(AmTera, "lookaway", "So, when this is all over, can you be my captain and teach me how to fly?"),
                    new(AmPeri, "shy", "Captain?-", true),
                    new(AmPeri, "shy", "I mean-", true),
                    new(AmPeri, "Sure, Tera. We'll 's start from the basics.", true)
                ]
            }},
            {"Tera_Hacker_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmTera, AmMax ],
                requiredScenes = ["Tera_Intro_0", "Hacker_1"],
                bg = "BGRunStart",
                dialogue = [
                    new(AmMax, "Tera, let me see your console for a sec."),
                    new(AmTera, "neutral", "Did I do something wrong?", true),
                    new(AmMax, "neutral", "Naw man, your spreadsheets are all messed up."),
                    new(AmMax, "neutral", "Just click here, and..."),
                    new(AmMax, "neutral", "Boom! Everything is auto-sorted, just like that."),
                    new(AmTera, "scared", "...", true),
                    new(AmTera, "scared", "You're my hero.", true),
                ]
            }},
            {"Tera_Eunice_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmTera, AmDrake ],
                requiredScenes = ["Tera_Intro_0", "Eunice_1"],
                bg = "BGRunStart",
                dialogue = [
                    new(AmTera, "scared", "...Holy crap."),
                    new(AmTera, "scared", "Eunice?"),
                    new(AmDrake, "reallymad", "Now who the HELL called me that?", true),
                    new(AmDrake, "reallymad", "I swear, I'm gonna-", true),
                    new(AmDrake, "squint", "...Holy hell.", true),
                    new(AmDrake, "neutral", "Tera, is that you?", true),
                    new(AmTera, "neutral", "...Yup, it's me."),
                    new(AmDrake, "sly", "Come crawling back to me after all these years?", true),
                    new(AmTera, "lookawaynervous", "N-no! Look, it's a long story, it's just-"),
                    new(AmTera, "neutral", "I was worried about you."),
                    new(AmDrake, "sly", "Don't get your feathers all ruffled. I've been fine.", true),
                    new(AmDrake, "neutral", "And while you're on this ship, you call me Drake.", true),
                    new(AmDrake, "neutral", "Now, why don't we make up for lost time and blast that bozo shooting at us?", true),
                    new(AmTera, "happy", "You got it!"),
                ]
            }},
            {"Tera_Eunice_1", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmTera, AmDrake ],
                requiredScenes = ["Tera_Eunice_0"],
                bg = "BGRunStart",
                dialogue = [
                    new(AmDrake, "So, where have you been after all these years?", true),
                    new(AmDrake, "sly", "Thought you went on some lame-o farm or something.", true),
                    new(AmTera, "Well, sorta!"),
                    new(AmTera, "I tried the farm life, but..."),
                    new(AmTera, "lookaway", "It has WAY too much manual labor."),
                    new(AmTera,  "I found a nice little office job off in one of the main sectors, been there ever since."),
                    new(AmDrake, "sly", "Pfft, an office job? Could you get any less boring?", true),
                    new(AmTera, "happy", "I legally steal money from folks and pocket the extra cash."),
                    new(AmDrake, "blush", "...", true),
                    new(AmDrake, "blush", "I knew you always had the pirate life in you.", true)
                ]
            }},
            {"Tera_Eunice_2", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmTera, AmDrake ],
                requiredScenes = ["Tera_Eunice_1"],
                bg = "BGRunStart",
                dialogue = [
                    new(AmTera, "Drake, do you ever miss it?"),
                    new(AmDrake, "Miss what?", true),
                    new(AmTera, "You know, the old times!"),
                    new(AmTera, "Us two, practicing our cannon fire, steering ships..."),
                    new(AmTera, "I know it was a long time ago, and our memories are quite fuzzy right now."),
                    new(AmTera, "squint", "Shoot, I can't even remember what's happened on some of these past loops."),
                    new(AmDrake,"sly", "I still remember face you made when I nosedived the ship.", true),
                    new(AmTera, "scared", "H-hey, that's not fair! You took the controls from me!"),
                    new(AmDrake,"neutral", "I had to teach you to not panic.", true),
                    new(AmDrake,"sly", "And it looks like you still haven't learned anything.", true),
                    new(AmTera, "squint", "Oh yeah? Watch me smoke this ship."),
                ]
            }},
            });
        }
    }
}
