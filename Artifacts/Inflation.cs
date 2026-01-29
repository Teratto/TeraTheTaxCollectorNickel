using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using Nanoray.PluginManager;
using Nickel;
using TeraTaxMod.Cards;

namespace TeraTaxMod.Artifacts;

/*
 * Artifacts are a nice way to accentuate a character's potential.
 * They can be simple effects that occur at simple times, they can modify an existing mechanic or one introduced by the character.
 * Similarly to cards, ensure you add this type to your ModEntry for registration.
 */
public class Inflation : Artifact, IRegisterable
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Artifacts.RegisterArtifact(new ArtifactConfiguration
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new ArtifactMeta
            {
                pools = [ArtifactPool.Boss],
                owner = ModEntry.Instance.TeraTaxDeck.Deck
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "Inflation", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "Inflation", "desc"]).Localize,
            /*
             * For Artifacts with just one sprite, registering them at the place of usage helps simplify things.
             */
            Sprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Artifact/ArtifactInflation.png")).Sprite
        });
    }

    /*
     * HIIII HOW ARE YOUUUU 
     * I'M TERATTO I CODED MOST OF THIS WITH HELP FROM VINTAGE AND SNIPER AND CERES BECAUSE FUCKINNNNNNNNNNNNNNNNNNN MAN
     * IT'S LIKE "HOW DO I SAY THIS THING" AND THEN IT'S JUST SKIMMING THE GAME'S CODE FOR HOW IT WANTS ***YOU*** TO SAY IT
     * tl;dr most of my struggling was figuring out how to understand cc's internal code since there's like no resource for that
     * ok cool bye
     * also hi again
     * why are u reading this
     * this code just registers this artifact, but it actually doesn't do anything isn't that funny
     * check out taxation manager if u wanna see where the code for this artifact is, it's like two lines
     * *Inflates you big and round*
     */

}