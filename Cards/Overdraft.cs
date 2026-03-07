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
                    rarity = Rarity.common,
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
                        List<CardAction> actions = new List<CardAction>
                            {
                                new AAttack()
                                {
                                    damage = GetDmg(s,1)

                                }
                            };
                        if (taxAmount >= requiredTax)
                        {
                            actions.Add(new AStatus()
                            {
                                status = ModEntry.Instance.TeraTaxationStatus.Status,
                                statusAmount = -1,
                                targetPlayer = false
                            });
                            actions.Add(new AAttack()
                            {
                                damage = GetDmg(s,2)
                            });
                        };
                        return actions;
                    }
                case Upgrade.A:
                    {
                        List<CardAction> actions = new List<CardAction>
                            {
                                new AAttack()
                                {
                                    damage = GetDmg(s,2),
                                 
                                }
                            };
                        if (taxAmount >= requiredTax)
                        {
                            actions.Add(new AStatus()
                            {
                                status = ModEntry.Instance.TeraTaxationStatus.Status,
                                statusAmount = -1,
                                targetPlayer = false
                            });
                            actions.Add(new AAttack()
                            {
                                damage = GetDmg(s, 2),
                                
                            });
                        };
                        return actions;
                    }
                case Upgrade.B:
                    {
                        List<CardAction> actions = new List<CardAction>
                            {
                                new AAttack()
                                {
                                    damage = GetDmg(s,1)

                                }
                            };
                        if (taxAmount >= bigRequiredTax)
                        {
                            actions.Add(new AStatus()
                            {
                                status = ModEntry.Instance.TeraTaxationStatus.Status,
                                statusAmount = -2,
                                targetPlayer = false
                            });
                            actions.Add(new AAttack()
                            {
                                damage = GetDmg(s, 1)
                            });
                            actions.Add(new AAttack()
                            {
                                damage = GetDmg(s, 1)
                            });
                            actions.Add(new AAttack()
                            {
                                damage = GetDmg(s, 1)
                            });
                            actions.Add(new AAttack()
                            {
                                damage = GetDmg(s, 1)
                            });
                           
                        };
                        return actions;
                    }
                default:
                    {
                        List<CardAction> actions = new List<CardAction>
                            {
                                new AAttack()
                                {
                                    damage = GetDmg(s,1)
                                }
                            };
                        if (taxAmount >= requiredTax)
                        {

                            actions.Add(new AAttack()
                            {
                                damage = GetDmg(s, 2)
                            });
                        };
                        return actions;
                    }

            }

        }


        public override CardData GetData(State state)
        {
            
            switch (this.upgrade)
            {
                case Upgrade.None:
                    {
                        return new CardData
                        {
                            description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "Overdraft", "desc"], new { damage1 = GetDmg(state, 1), damage2 = GetDmg(state, 2) })),
                            cost = 1
                        };
                    }
                case Upgrade.A:
                    { 
                        return new CardData
                        {
                            description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "Overdraft", "descA"], new { damage1 = GetDmg(state, 2), damage2 = GetDmg(state, 2) })),
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
                            description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "Overdraft", "desc"], new { damage1 = GetDmg(state, 1), damage2 = GetDmg(state, 2) })),
                            cost = 1
                        };
                    }
            }
        }
    }
}
