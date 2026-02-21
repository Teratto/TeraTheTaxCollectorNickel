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
    internal class TaxingEscape : Card, IRegisterable
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
                    dontOffer = false,
                    upgradesTo = [Upgrade.A, Upgrade.B]
                },
                Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "TaxingEscape", "name"]).Localize,
                Art = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Card/cardTaxingEscape.png")).Sprite,
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
                        new AMove()
                        {
                            dir = 2,
                            targetPlayer = true
                        },
                        new AAttack()
                        {
                            damage = GetDmg(s,0),
                            status = ModEntry.Instance.TeraTaxationStatus.Status,
                            statusAmount = 1
                        },
                        new AStatus()
                        {
                            status = ModEntry.TeraCharacter.MissingStatus.Status,
                            statusAmount = 1,
                            targetPlayer = true
                        }
                    };
                    }
                case Upgrade.A:
                    {
                        return new List<CardAction>
                    {
                        new AMove()
                        {
                            dir = 2,
                            targetPlayer = true
                        },
                        new AAttack()
                        {
                            damage = GetDmg(s,0),
                            status = ModEntry.Instance.TeraTaxationStatus.Status,
                            statusAmount = 1
                        },
                        new AStatus()
                        {
                            status = ModEntry.TeraCharacter.MissingStatus.Status,
                            statusAmount = 1,
                            targetPlayer = true
                        }
                    };
                    }
                case Upgrade.B:
                    {
                        return new List<CardAction>
                    {
                        new AMove()
                        {
                            dir = 2,
                            targetPlayer = true
                        },
                        new AAttack()
                        {
                            damage = GetDmg(s,0),
                            status = ModEntry.Instance.TeraTaxationStatus.Status,
                            statusAmount = 1
                        },
                    };
                    }
                default:
                    {
                        return new List<CardAction>
                    {
                        new AMove()
                        {
                            dir = 2,
                            targetPlayer = true
                        },
                        new AAttack()
                        {
                            damage = GetDmg(s,0),
                            status = ModEntry.Instance.TeraTaxationStatus.Status,
                            statusAmount = 1
                        },
                        new AStatus()
                        {
                            status = ModEntry.TeraCharacter.MissingStatus.Status,
                            statusAmount = 1,
                            targetPlayer = true
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
                flippable = upgrade == Upgrade.A ? true : false
            };
        }

    }
}
