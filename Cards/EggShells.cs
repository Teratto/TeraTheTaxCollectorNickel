using Nanoray.PluginManager;
using Nickel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TeraTaxMod;

namespace TeraTaxMod.Cards
{
    internal class EggShells : Card, IRegisterable
    {
        public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
        {
            helper.Content.Cards.RegisterCard(new CardConfiguration
            {
                /*
                 * This is a trick to obtain the type housing the current method, to reduce the effort of making a new card.
                 */
                CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
                Meta = new CardMeta
                {
                    deck = ModEntry.Instance.TeraTaxDeck.Deck,
                    rarity = Rarity.common,
                    dontOffer = true,
                    upgradesTo = [Upgrade.A, Upgrade.B]
                },
                Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "EggShells", "name"]).Localize,
                Art = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Card/cardEggShells.png")).Sprite,
            });
        }


        /*
         * Each card has a list of actions, which decides both what is rendered on the card, and what actually happens on play.
         * There are many ways to construct the actions a card contains.
         * The following is a simple approach, good for if the actions on the card only vary in their numbers.
         */
        public override List<CardAction> GetActions(State s, Combat c)
        {
            switch (this.upgrade)
            {
                case Upgrade.None:
                    {
                        return new List<CardAction>
                    {
                        new AAttack()
                        {
                            damage = GetDmg(s,1),
                            stunEnemy = true,
                            dialogueSelector = ".EggShells"
                        }
                    };
                    }
                case Upgrade.A:
                    {
                        return new List<CardAction>
                    {
                        new AAttack()
                        {
                            damage = GetDmg(s,1),
                            stunEnemy = true,
                            dialogueSelector = ".EggShells"
                        },
                        new AMove()
                        {
                            dir = 1,
                            targetPlayer = true
                        },
                        new AAttack()
                        {
                            damage = GetDmg(s,1),
                            stunEnemy = true,
                            dialogueSelector = ".EggShells"
                        },
                    };
                    }
                case Upgrade.B:
                    {
                        return new List<CardAction>
                    {
                        new AAttack()
                        {
                            damage = GetDmg(s,1),
                            stunEnemy = true,
                            status = Status.lockdown,
                            statusAmount = 1,
                            dialogueSelector = ".EggShells"
                        }
                    };
                    }
                default:
                    {
                        return new List<CardAction>
                    {
                        new AAttack()
                        {
                            damage = GetDmg(s,0),
                            stunEnemy = true,
                            dialogueSelector = ".EggShells"
                        }
                    };
                    }
            }

        }

        
        public override CardData GetData(State state)
        {
            return new CardData
            {
                cost = 0,
                temporary = true,
                exhaust = true
            };
        }

    }
}
