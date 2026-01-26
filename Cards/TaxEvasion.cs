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
    internal class TaxEvasion : Card, IRegisterable
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
                Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "TaxEvasion", "name"]).Localize,
                Art = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Card/TaxEvasion.png")).Sprite,
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
                                new AStatus()
                                    {
                                        status = Status.evade,
                                        statusAmount = 1,
                                        targetPlayer = true
                                     },
                                new AStatus()
                                     {
                                        status = Status.tempShield,
                                        statusAmount = 2,
                                        targetPlayer = true
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
                                new AStatus()
                                    {
                                        status = Status.evade,
                                        statusAmount = 1,
                                        targetPlayer = true
                                     },
                                new AStatus()
                                     {
                                        status = Status.tempShield,
                                        statusAmount = 3,
                                        targetPlayer = true
                                     },
                            };
                        }


                    }
                    break;
                case Upgrade.B:
                    {
                        List<CardAction> actions = new List<CardAction>
                            {
                                new AStatus()
                                     {
                                        status = Status.tempShield,
                                        statusAmount = 2,
                                        targetPlayer = true
                                     },
                            };
                        if (taxAmount >= requiredTax)
                            {

                                actions.Add(new AStatus()
                                    {
                                        status = ModEntry.Instance.TeraTaxationStatus.Status,
                                        statusAmount = -requiredTax,
                                        targetPlayer = false
                                    });
                                actions.Add(new AStatus()
                                    {
                                        status = Status.evade,
                                        statusAmount = 1,
                                        targetPlayer = true
                                    });
                        };
                        return actions;


                    }
                default:
                    {
                        if (taxAmount > requiredTax)
                        {
                            return new List<CardAction>
                            {

                                new AStatus()
                                    {
                                        status = Status.evade,
                                        statusAmount = 1,
                                        targetPlayer = true
                                     },
                                new AStatus()
                                     {
                                        status = Status.tempShield,
                                        statusAmount = 2,
                                        targetPlayer = true
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
                            description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "TaxEvasion", "desc"])),
                            cost = 0
                        };
                    }
                case Upgrade.A:
                    {
                        return new CardData
                        {
                            description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "TaxEvasion", "descA"])),
                            cost = 0,
                            
                        };
                    }
                case Upgrade.B:
                    {
                        return new CardData
                        {
                            description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "TaxEvasion", "descB"])),
                            cost = 0,
                            
                        };
                    }
                default:
                    {
                        return new CardData
                        {
                            description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "TaxEvasion", "desc"])),
                            cost = 0
                        };
                    }
            }
        }

    }
}
