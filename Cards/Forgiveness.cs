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
    internal class Forgiveness : Card, IRegisterable
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
                Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "Forgiveness", "name"]).Localize,
                Art = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Card/cardForgiveness.png")).Sprite,
            });
        }


        /*
         * Each card has a list of actions, which decides both what is rendered on the card, and what actually happens on play.
         * There are many ways to construct the actions a card contains.
         * The following is a simple approach, good for if the actions on the card only vary in their numbers.
         */
        public override List<CardAction> GetActions(State s, Combat c)
        {
            int requiredTax = 1;
            int taxAmount = c.otherShip.Get(ModEntry.Instance.TeraTaxationStatus.Status);


            switch (this.upgrade)
            {

                case Upgrade.None:
                    {
                        if (taxAmount >= requiredTax)
                        {
                            return new List<CardAction>
                            {
                                new AStatus()
                                     {
                                        status = ModEntry.Instance.TeraTaxationStatus.Status,
                                        statusAmount = -requiredTax,
                                        targetPlayer = false
                                     },
                                new AEnergy()
                                    {
                                        changeAmount = 2
                                     },
                            };
                        }
                    }
                    break;
                case Upgrade.B:
                    {
                        if (taxAmount >= requiredTax)
                        {
                            return new List<CardAction>
                            {
                                new AStatus()
                                     {
                                        status = ModEntry.Instance.TeraTaxationStatus.Status,
                                        statusAmount = -requiredTax,
                                        targetPlayer = false
                                     },
                                new AEnergy()
                                    {
                                        changeAmount = 2
                                     },
                            };
                        }
                    }
                    break;
                case Upgrade.A:
                    {
                        if (taxAmount >= requiredTax)
                        {
                            return new List<CardAction>
                            {
                                new AStatus()
                                     {
                                        status = ModEntry.Instance.TeraTaxationStatus.Status,
                                        statusAmount = -requiredTax,
                                        targetPlayer = false
                                     },
                                new AEnergy()
                                    {
                                        changeAmount = 2
                                    },
                                new ADrawCard()
                                    {
                                        count = 1
                                    },
                            };
                        }
                    }
                    break;
                default:
                    {
                        if (taxAmount > requiredTax)
                        {
                            return new List<CardAction>
                            {

                                new AStatus()
                                     {
                                        status = ModEntry.Instance.TeraTaxationStatus.Status,
                                        statusAmount = -requiredTax,
                                        targetPlayer = false
                                     },
                                new AEnergy()
                                    {
                                        changeAmount = 2
                                     },
                            };
                        }


                    }
                    break;
            }

            return new List<CardAction>();
        }


        public override CardData GetData(State state)
        {
            switch (this.upgrade)
            {
                case Upgrade.None:
                    {
                        return new CardData
                        {
                            description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "Forgiveness", "desc"])),
                            cost = 0
                        };
                    }
                case Upgrade.A:
                    {
                        return new CardData
                        {
                            description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "Forgiveness", "descA"])),
                            cost = 0,
                            
                        };
                    }
                case Upgrade.B:
                    {
                        return new CardData
                        {
                            description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "Forgiveness", "descB"])),
                            cost = 0,
                            retain = true
                        };
                    }
                default:
                    {
                        return new CardData
                        {
                            description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "Forgiveness", "desc"])),
                            cost = 0
                        };
                    }
            }
        }

    }
}
