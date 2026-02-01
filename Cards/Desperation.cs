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
    internal class Desperation : Card, IRegisterable
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
                Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "Desperation", "name"]).Localize,
                Art = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Card/cardDesperation.png")).Sprite,
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
                        new AStatus()
                        {
                            status = Status.powerdrive,
                            statusAmount = 1,
                            targetPlayer = true,
                        },
                        new AStatus()
                        {
                            status = ModEntry.Instance.TeraTaxationStatus.Status,
                            statusAmount = 3,
                            targetPlayer = true,
                            dialogueSelector = ".Desperation"
                        }
                    };
                    }
                case Upgrade.A:
                    {
                        return new List<CardAction>
                    {
                        new AStatus()
                        {
                            status = Status.powerdrive,
                            statusAmount = 1,
                            targetPlayer = true
                        },
                        new AStatus()
                        {
                            status = ModEntry.Instance.TeraTaxationStatus.Status,
                            statusAmount = 3,
                            targetPlayer = true,
                            dialogueSelector = ".Desperation"
                        }
                    };
                    }
                case Upgrade.B:
                    {
                        return new List<CardAction>
                    {
                        new AStatus()
                        {
                            status = Status.powerdrive,
                            statusAmount = 2,
                            targetPlayer = true
                        },
                        new AStatus()
                        {
                            status = ModEntry.Instance.TeraTaxationStatus.Status,
                            statusAmount = 6,
                            targetPlayer = true,
                            dialogueSelector = ".Desperation"
                        }

                    };
                    }
                default:
                    {
                        return new List<CardAction>
                    {
                        new AStatus()
                        {
                            status = Status.powerdrive,
                            statusAmount = 1,
                            targetPlayer = true
                        },
                        new AStatus()
                        {
                            status = ModEntry.Instance.TeraTaxationStatus.Status,
                            statusAmount = 3,
                            targetPlayer = true,
                            dialogueSelector = ".Desperation"
                        }
                    };
                    }
            }

        }

        
        public override CardData GetData(State state)
        {
            return new CardData
            {
                cost = upgrade == Upgrade.A ? 1 : 2,
                exhaust = true,
            };
        }

    }
}
