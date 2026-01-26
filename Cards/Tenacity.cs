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
    internal class Tenacity : Card, IRegisterable
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
                    rarity = Rarity.rare,
                    dontOffer = false,
                    upgradesTo = [Upgrade.A, Upgrade.B]
                },
                Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "Tenacity", "name"]).Localize,
                Art = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Card/cardTenacity.png")).Sprite,
            });
        }

        private int GetX(State state)
        {
            var x = state.ship.Get(ModEntry.Instance.TeraTaxationStatus.Status);
            return x;
        }
        /*
         * Each card has a list of actions, which decides both what is rendered on the card, and what actually happens on play.
         * There are many ways to construct the actions a card contains.
         * The following is a simple approach, good for if the actions on the card only vary in their numbers.
         */
        public override List<CardAction> GetActions(State s, Combat c)
        {
            int playerTax = s.ship.Get(ModEntry.Instance.TeraTaxationStatus.Status);
            switch (this.upgrade)
            {
                case Upgrade.None:
                    {
                        return new List<CardAction>
                    {
                        new AStatus()
                        {
                            
                            status = ModEntry.Instance.TeraTaxationStatus.Status,
                            statusAmount = 1,
                            targetPlayer = true
                        },
                        new AVariableHint()
                        {
                            status = ModEntry.Instance.TeraTaxationStatus.Status
                        },
                        new AHurt()
                        {
                            hurtShieldsFirst = true,
                            hurtAmount = GetX(s) + 1,
                            xHint = 1,
                            targetPlayer = true
                            
                        },
                        new ADrawCard()
                        {
                            count = 3
                        },
                    };
                    }
                case Upgrade.A:
                    {
                        return new List<CardAction>
                    {
                        new AVariableHint()
                        {
                            status = ModEntry.Instance.TeraTaxationStatus.Status
                        },
                        new AHurt()
                        {
                            hurtShieldsFirst = true,
                            hurtAmount = GetX(s),
                            xHint = 1,
                            targetPlayer = true

                        },
                        new AStatus()
                        {

                            status = ModEntry.Instance.TeraTaxationStatus.Status,
                            statusAmount = 1,
                            targetPlayer = true
                        },
                        new ADrawCard()
                        {
                            count = 3
                        },
                    };
                    }
                case Upgrade.B:
                    {
                        return new List<CardAction>
                    {
                        new AStatus()
                        {

                            status = ModEntry.Instance.TeraTaxationStatus.Status,
                            statusAmount = 1,
                            targetPlayer = true
                        },
                        new AVariableHint()
                        {
                            status = ModEntry.Instance.TeraTaxationStatus.Status
                        },
                        new AHurt()
                        {
                            hurtShieldsFirst = true,
                            hurtAmount = GetX(s) + 1,
                            xHint = 1,
                            targetPlayer = true

                        },
                        new ADrawCard()
                        {
                            count = 3
                        },
                    };
                    }
                default:
                    {
                        return new List<CardAction>
                    {
                        new AStatus()
                        {

                            status = ModEntry.Instance.TeraTaxationStatus.Status,
                            statusAmount = 1,
                            targetPlayer = true
                        },
                        new AHurt()
                        {
                            hurtShieldsFirst = true,
                            hurtAmount = playerTax,
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
                exhaust = false,
                infinite = upgrade == Upgrade.B ? true : false,
            };
        }

    }
}
