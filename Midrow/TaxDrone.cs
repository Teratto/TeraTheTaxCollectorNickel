using Nanoray.PluginManager;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Nickel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TeraTaxMod;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TeraTaxMod.Midrow
{
    internal sealed class TaxDrone : StuffBase
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TaxDroneType
        {
            Normal
        }

        [JsonProperty]
        public TaxDroneType StoneType = TaxDroneType.Normal;

        public override Spr? GetIcon()
        {
            return ModEntry.Instance.TaxDroneCard.Sprite;

        }

        public override double GetWiggleAmount() => 0.0;
        public override double GetWiggleRate() => 1.0;
        public override bool IsHostile() => this.targetPlayer;

        public override List<Tooltip> GetTooltips()
        {
            List<Tooltip> tooltips = [
                new GlossaryTooltip($"{ModEntry.Instance.Package.Manifest.UniqueName}::{GetType()}")
                {
                    Icon = GetIcon()!,
                    Title = ModEntry.Instance.Localizations.Localize(["midrow", "TaxDrone", StoneType.ToString(), "name"]),
                    TitleColor = Colors.midrow,
                    Description = ModEntry.Instance.Localizations.Localize(["midrow", "TaxDrone", StoneType.ToString(), "description"])
                },
                
            ];
            if (this.bubbleShield)
                tooltips.Add((Tooltip)new TTGlossary("midrow.bubbleShield", Array.Empty<object>()));
            return tooltips;
        }




        public override List<CardAction>? GetActionsOnBonkedWhileInvincible(State s, Combat c, bool wasPlayer, StuffBase thing)
        {
            return new List<CardAction>
            {
                new ASpaceMineAttack
                {
                    hurtAmount = 1,
                    targetPlayer = wasPlayer,
                    worldX = this.x
                }
            };
        }

        public override List<CardAction>? GetActions(State s, Combat c)
        {
            return new List<CardAction>
            {
                new AAttack
                {
                    isBeam = false,
                    fromDroneX = x,
                    targetPlayer = targetPlayer,
                    damage = 0,
                    status = ModEntry.Instance.TeraTaxationStatus.Status,
                    statusAmount = 1
                }
            };
        }

        public override void Render(G g, Vec v)
        {
            Spr Sprite;
            Sprite = ModEntry.Instance.TaxDroneMidrow.Sprite;
            //DrawWithHilight(g, Sprite, v + GetOffset(g), Mutil.Rand((double)x + 0.1) > 0.5, Mutil.Rand((double)x + 0.2) > 0.5);
            DrawWithHilight(g, Sprite, v + GetOffset(g));
        }
    }
}