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
    internal class TaxExemption : Card, IRegisterable
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
                Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "TaxExemption", "name"]).Localize,
                Art = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Card/CardTaxExemption.png")).Sprite,
            });
        }
    
        private int GetX(Combat c)
        {
            var x = c.otherShip.Get(ModEntry.Instance.TeraTaxationStatus.Status);
            return x;
        }

        /*
         * Each card has a list of actions, which decides both what is rendered on the card, and what actually happens on play.
         * There are many ways to construct the actions a card contains.
         * The following is a simple approach, good for if the actions on the card only vary in their numbers.
         */
        public override List<CardAction> GetActions(State s, Combat c)
        {
            int enemyTax = c.otherShip.Get(ModEntry.Instance.TeraTaxationStatus.Status);
            switch (this.upgrade)
            {
                case Upgrade.None:
                    {
                        return new List<CardAction>
                    {
                        ModEntry.Instance.KokoroApi.VariableHintTargetPlayerTargetPlayer.MakeVariableHint(
                            new AVariableHint
                            {
                                status = ModEntry.Instance.TeraTaxationStatus.Status,
                            }).SetTargetPlayer(false).AsCardAction,
                        new AStatus()
                        {
                            status = Status.shield,
                            statusAmount = GetX(c) + 1,
                            targetPlayer = true
                        },
                        new AStatus()
                        {
                            status = ModEntry.Instance.TeraTaxationStatus.Status,
                            statusAmount = -1,
                            targetPlayer = false
                        }
                    };
                    }
                case Upgrade.A:
                    {
                        return new List<CardAction>
                    {
                        ModEntry.Instance.KokoroApi.VariableHintTargetPlayerTargetPlayer.MakeVariableHint(
                            new AVariableHint
                            {
                                status = ModEntry.Instance.TeraTaxationStatus.Status,
                            }).SetTargetPlayer(false).AsCardAction,
                        new AStatus()
                        {
                            status = Status.shield,
                            statusAmount = GetX(c) + 1,
                            targetPlayer = true
                        },
                    };
                    }
                case Upgrade.B:
                    {
                        return new List<CardAction>
                    {
                        ModEntry.Instance.KokoroApi.VariableHintTargetPlayerTargetPlayer.MakeVariableHint(
                            new AVariableHint
                            {
                                status = ModEntry.Instance.TeraTaxationStatus.Status,
                            }).SetTargetPlayer(false).AsCardAction,
                        new AStatus()
                        {
                            status = Status.tempShield,
                            statusAmount = GetX(c) + 1,
                            targetPlayer = true
                        },
                        new AStatus()
                        {
                            status = ModEntry.Instance.TeraTaxationStatus.Status,
                            statusAmount = -1,
                            targetPlayer = false
                        }

                    };
                    }
                default:
                    {
                        return new List<CardAction>
                    {
                        ModEntry.Instance.KokoroApi.VariableHintTargetPlayerTargetPlayer.MakeVariableHint(
                            new AVariableHint
                            {
                                status = ModEntry.Instance.TeraTaxationStatus.Status,
                            }).SetTargetPlayer(false).AsCardAction,
                        new AStatus()
                        {
                            status = Status.shield,
                            statusAmount = GetX(c) + 1,
                            targetPlayer = true
                        },
                        new AStatus()
                        {
                            status = ModEntry.Instance.TeraTaxationStatus.Status,
                            statusAmount = -1,
                            targetPlayer = false
                        }
                    };
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
                            cost = 1
                        };
                    }
                case Upgrade.A:
                    {
                        return new CardData
                        {
                            cost = 1,
                        };
                    }
                case Upgrade.B:
                    {
                        return new CardData
                        {
                            cost = 1,

                        };
                    }
                default:
                    {
                        return new CardData
                        {
                            cost = 1
                        };
                    }
            }
        }

    }
}
