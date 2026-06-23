using Nanoray.PluginManager;
using Nickel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TeraTaxMod;
using static System.Net.Mime.MediaTypeNames;

namespace TeraTaxMod.Cards
{
    internal class Overdraft : Card, IRegisterable
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
                    rarity = Rarity.uncommon,
                    dontOffer = false,
                    upgradesTo = [Upgrade.A, Upgrade.B]
                },
                Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "Overdraft", "name"]).Localize,
                Art = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Card/cardOverdraft.png")).Sprite,
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
            int bigRequiredTax = 2;
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
                                new AAttack()
                                     {
                                        damage = GetDmg(s, 4)
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
                                new AAttack()
                                     {
                                        damage = GetDmg(s, 5)
                                     },
                            };
                        }
                    }
                    break;
                case Upgrade.B:
                    {
                        if (taxAmount >= bigRequiredTax)
                        {
                            return new List<CardAction>
                            {
                                new AStatus()
                                     {
                                        status = ModEntry.Instance.TeraTaxationStatus.Status,
                                        statusAmount = -bigRequiredTax,
                                        targetPlayer = false
                                     },
                                new AAttack()
                                     {
                                        damage = GetDmg(s, 1)
                                     },
                                new AAttack()
                                     {
                                        damage = GetDmg(s, 1)
                                     },
                                new AAttack()
                                     {
                                        damage = GetDmg(s, 1)
                                     },
                                new AAttack()
                                     {
                                       damage = GetDmg(s, 1)
                                     },
                                new AAttack()
                                     {
                                        damage = GetDmg(s, 1)
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
                                new AAttack()
                                     {
                                        damage = GetDmg(s, 4),
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
                            description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "Overdraft", "desc"], new { damage1 = GetDmg(state, 4), damage2 = GetDmg(state, 2) })),
                            cost = 1
                        };
                    }
                case Upgrade.A:
                    { 
                        return new CardData
                        {
                            description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "Overdraft", "descA"], new { damage1 = GetDmg(state, 5), damage2 = GetDmg(state, 2) })),
                            cost = 1,

                        };
                    }
                case Upgrade.B:
                    {
                        return new CardData
                        {
                            description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "Overdraft", "descB"], new { damage1 = GetDmg(state, 1) } )),
                            cost = 1,

                        };
                    }
                default:
                    {
                        return new CardData
                        {
                            description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "Overdraft", "desc"], new { damage1 = GetDmg(state, 4), damage2 = GetDmg(state, 2) })),
                            cost = 1
                        };
                    }
            }
        }
    }
}
