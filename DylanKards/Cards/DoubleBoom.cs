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
    class DoubleBoom : SimpleCard
    {
        public override CardDetails Details => new CardDetails
        {
            Title = "Double Boom",
            Description = "Your bullets explode on impact and shortly after, creating a double boom.",
            ModName = DylanKards.ModInitials,
            Art = Assets.DoubleBoomArt,
            Rarity = CardInfo.Rarity.Uncommon,
            Theme = CardThemeColor.CardThemeColorType.DestructiveRed,
            Stats = new[]
            {
                new CardInfoStat()
                {
                    positive = false,
                    amount = "-40%",
                    simepleAmount = CardInfoStat.SimpleAmount.slightlyLower,
                    stat = "Damage"
                },
                new CardInfoStat()
                {
                    positive = false,
                    amount = "-50%",
                    simepleAmount = CardInfoStat.SimpleAmount.slightlyLower,
                    stat = "Attack Speed"
                },
                new CardInfoStat()
                {
                    positive = false,
                    amount = "+0.5s",
                    simepleAmount = CardInfoStat.SimpleAmount.aLittleBitOf,
                    stat = "Reload Time"
                }
            }
        };

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            var explosiveBullet = (GameObject)Resources.Load("0 cards/Explosive Bullet");
            var timedDetonation = (GameObject)Resources.Load("0 cards/Timed Detonation");
            var boom1 = explosiveBullet.GetComponent<Gun>().objectsToSpawn[0];
            var boom2 = timedDetonation.GetComponent<Gun>().objectsToSpawn[0];

            gun.objectsToSpawn = new[] { boom1, boom2 };
            gun.damage = 0.6f;
            gun.attackSpeed = 1.5f;
            gun.reloadTimeAdd = 0.5f;
        }
    }
}