using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModsPlus;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;


namespace DylanKards.Cards
{
    class SimpleTemplate : SimpleCard
    {
        public override CardDetails Details => new CardDetails
        {
            Title = "Card Name",
            Description = "Card Description",
            ModName = DylanKards.ModInitials,
            Art = null,
            Rarity = CardInfo.Rarity.Common,
            Theme = CardThemeColor.CardThemeColorType.TechWhite,
            Stats = new[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    amount = "Effect",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned,
                    stat = "No"
                }
            }
        };

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {

        }
    }
}