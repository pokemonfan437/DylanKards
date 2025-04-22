using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using ModsPlus;
using UnityEngine.Assertions;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using Photon.Compression;
using Photon.Pun.Simple;
using Photon.Pun;
using UnityEngine.Experimental.PlayerLoop;


namespace DylanKards.Cards
{
    public class AirStrike : CustomEffectCard<AirStrikeEffect>
    {
        public override CardDetails Details => new CardDetails
        {
            Title = "Air Strike",
            Description = "Deliver bullets to your opponents from above, while also compressing your bullets.",
            ModName = DylanKards.ModInitials,
            Art = null,
            Rarity = CardInfo.Rarity.Rare,
            Theme = CardThemeColor.CardThemeColorType.FirepowerYellow,
            Stats = new[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    amount = "Ignore",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned,
                    stat = "Terrain"
                },
                new CardInfoStat()
                {
                    positive = true,
                    amount = "No",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned,
                    stat = "Spread"
                },
                new CardInfoStat()
                {
                    positive = true,
                    amount = "+50%",
                    simepleAmount = CardInfoStat.SimpleAmount.aHugeAmountOf,
                    stat = "Bullet Speed"
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
                    amount = "-100%",
                    simepleAmount = CardInfoStat.SimpleAmount.aLotLower,
                    stat = "Attack Speed"
                },
                new CardInfoStat()
                {
                    positive = false,
                    amount = "+1s",
                    simepleAmount = CardInfoStat.SimpleAmount.aLotOf,
                    stat = "Reload Time"
                }
            }
        };

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            gun.attackSpeed = 2f;
            gun.ignoreWalls = true;
            gun.projectileSpeed = 1.5f;
            gun.reloadTimeAdd = 1f;
            gun.damage = 0.5f;
        }
    }
    
    public class AirStrikeEffect : CardEffect
    {
        private float cursorX = 0f;
        private float airStrikeHeight = 19.5f;
        
        public override void OnShoot(GameObject projectile)
        {
            var bounce = projectile.GetComponentInChildren<RayHitReflect>();
            if (bounce) { Destroy(bounce); }

            

            GameObject fakeTarget = new GameObject("FakeTarget");
            Transform fakeTransform = fakeTarget.transform;
            if (player.data.view.IsMine || PhotonNetwork.OfflineMode)
            {
                cursorX = MainCam.instance.cam.ScreenToWorldPoint(Input.mousePosition).x;
            }
            fakeTarget.transform.SetXPosition(cursorX);
            fakeTarget.transform.SetYPosition(0f);
            fakeTarget.transform.SetZPosition(0f);

            projectile.SetPosition(new Vector3(cursorX, airStrikeHeight), IncludedAxes.XY); // shoot bullet from offscreen at cursor's x position
            projectile.transform.LookAt(fakeTransform);
            if (fakeTransform) { Destroy(fakeTransform); }
            if (fakeTarget) { Destroy(fakeTarget); }
        }

        public void Update()
        {
            if(player.data.view.IsMine || PhotonNetwork.OfflineMode)
            {
                cursorX = MainCam.instance.cam.ScreenToWorldPoint(Input.mousePosition).x;
            }
        }
    }
}
