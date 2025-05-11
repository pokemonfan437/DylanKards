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
    class EZAim : SimpleCard
    {
        public override CardDetails Details => new CardDetails
        {
            Title = "EZ-Aim",
            Description = "Why bother aiming when your bullets can do it for you?",
            ModName = DylanKards.ModInitials,
            Art = Assets.EZAimArt,
            Rarity = CardInfo.Rarity.Rare,
            Theme = CardThemeColor.CardThemeColorType.TechWhite,
            Stats = new[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    amount = "Homing",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned,
                    stat = "Bullets"
                },
                new CardInfoStat()
                {
                    positive = true,
                    amount = "Sneaky",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned,
                    stat = "Bullets"
                },
                new CardInfoStat()
                {
                    positive = true,
                    amount = "Targeted",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned,
                    stat = "Bounces"
                },
                new CardInfoStat()
                {
                    positive = true,
                    amount = "+1",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned,
                    stat = "Bounce"
                },
                new CardInfoStat()
                {
                    positive = false,
                    amount = "-50%",
                    simepleAmount = CardInfoStat.SimpleAmount.aLotLower,
                    stat = "Damage"
                },
                new CardInfoStat()
                {
                    positive = false,
                    amount = "-50%",
                    simepleAmount = CardInfoStat.SimpleAmount.aLotLower,
                    stat = "Attack Speed"
                },
                new CardInfoStat()
                {
                    positive = false,
                    amount = "+0.5s",
                    simepleAmount = CardInfoStat.SimpleAmount.Some,
                    stat = "Reload Time"
                }
            }
        };

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            var homingCard = (GameObject)Resources.Load("0 cards/Homing");
            var sneakyCard = (GameObject)Resources.Load("0 cards/Sneaky bullets");
            var targetBounce = (GameObject)Resources.Load("0 cards/TargetBounce");

            var homing = homingCard.GetComponent<Gun>().objectsToSpawn[0];
            var sneaky = sneakyCard.GetComponent<Gun>().objectsToSpawn[0];
            var voidBounce = targetBounce.GetComponent<Gun>().objectsToSpawn[0];
            var target = targetBounce.GetComponent<Gun>().objectsToSpawn[1];

            gun.objectsToSpawn = new[] { homing, sneaky, voidBounce, target };
            gun.damage = 0.5f;
            gun.attackSpeed = 1.5f;
            gun.reloadTimeAdd = 0.5f;
            gun.reflects = 1;
        }
    }
}