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
    internal class Tariff : Card, IRegisterable
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
                Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "Tariff", "name"]).Localize,
                Art = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Card/cardTariff.png")).Sprite,
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
                            status = ModEntry.Instance.TeraTaxationStatus.Status,
                            statusAmount = 1
                        }
                    };
                    }
                case Upgrade.A:
                    {
                        return new List<CardAction>
                    {
                        new AAttack()
                        {
                            damage = GetDmg(s,2),
                            status = ModEntry.Instance.TeraTaxationStatus.Status,
                            statusAmount = 1
                        }
                    };
                    }
                case Upgrade.B:
                    {
                        return new List<CardAction>
                    {
                        new AAttack()
                        {
                            damage = GetDmg(s,0),
                            status = ModEntry.Instance.TeraTaxationStatus.Status,
                            statusAmount = 2
                        }
                    };
                    }
                default:
                    {
                        return new List<CardAction>
                    {
                        new AAttack()
                        {
                            damage = GetDmg(s,1),
                            status = ModEntry.Instance.TeraTaxationStatus.Status,
                            statusAmount = 1
                        }
                    };
                    }
            }

        }

        
        public override CardData GetData(State state)
        {
            return new CardData
            {
                cost = 1,
                exhaust = false,
            };
        }

    }
}
