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
using SimulationChamber;


namespace DylanKards.Cards
{
    public class AirStrike : CustomEffectCard<AirStrikeEffect>
    {
        public override CardDetails Details => new CardDetails
        {
            Title = "Air Strike",
            Description = "Additionally fires an airstrike every time you shoot.",
            ModName = DylanKards.ModInitials,
            Art = Assets.AirStrikeArt,
            Rarity = CardInfo.Rarity.Rare,
            Theme = CardThemeColor.CardThemeColorType.FirepowerYellow,
            Stats = new[]
            {
                new CardInfoStat()
                {
                    positive = false,
                    amount = "-30%",
                    simepleAmount = CardInfoStat.SimpleAmount.slightlyLower,
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
                    simepleAmount = CardInfoStat.SimpleAmount.aLotOf,
                    stat = "Reload Time"
                }
            }
        };

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            gun.attackSpeed = 1.5f;
            gun.reloadTimeAdd = 0.5f;
            gun.damage = 0.7f;
        }
    }
    
    public class AirStrikeEffect : CardEffect
    {
        public float cursorX = 0f;
        private float airStrikeHeight = 20f;
        private float airStrikeMult = 1f;

        public SimulatedGun[] guns = new SimulatedGun[1];

        public void Start()
        {
            gun.ShootPojectileAction += this.OnShootProjectileAction;
            if (guns[0] == null)
            {
                guns[0] = new GameObject("Air Support").AddComponent<SimulatedGun>();
            }
        }

        public static GameObject _stopRecursionObj = null;

        public static GameObject StopRecursionObj
        {
            get
            {
                if(_stopRecursionObj == null)
                {
                    _stopRecursionObj = new GameObject("A_StopRecursion", typeof(StopRecursion));
                    DontDestroyOnLoad(_stopRecursionObj);
                }
                return _stopRecursionObj;
            }
        }

        public static ObjectsToSpawn[] StopRecursionSpawn
        {
            get
            {
                return new ObjectsToSpawn[] { new ObjectsToSpawn() { AddToProjectile = StopRecursionObj } };
            }
        }

        public void OnShootProjectileAction(GameObject obj)
        {
            if (obj.GetComponentsInChildren<StopRecursion>().Length > 0)
            {
                return;
            }
            SimulatedGun airSupport = guns[0];


            airSupport.CopyGunStatsExceptActions(gun);
            airSupport.CopyAttackAction(gun);
            airSupport.CopyShootProjectileAction(gun);
            airSupport.ShootPojectileAction -= this.OnShootProjectileAction;
            airSupport.objectsToSpawn = airSupport.objectsToSpawn.Concat(StopRecursionSpawn).ToArray();
            airSupport.numberOfProjectiles = 1;
            airSupport.bursts = 0;
            airSupport.spread = 0;
            airSupport.evenSpread = 0;
            airSupport.reflects = 0;
            airSupport.projectileSpeed = gun.projectileSpeed * airStrikeMult * 2f;
            airSupport.cos = 0;
            airSupport.damage = gun.damage * airStrikeMult * 0.75f;
            airSupport.projectileColor = new Color(1f,0.1f,0.2f);

            // only continue if the photonview owner is the one firing, or in offline
            if (!(player.data.view.IsMine || PhotonNetwork.OfflineMode))
            {
                return;
            }

            airSupport.SimulatedAttack(player.playerID, new Vector3(MainCam.instance.cam.ScreenToWorldPoint(Input.mousePosition).x, airStrikeHeight), new Vector3(0f, -1f), 1f, 1);
        }

        public override void OnUpgradeCard()
        {
            airStrikeMult *= 1.3f;
        }

        public override void OnShoot(GameObject projectile)
        {
            


            
            //GameObject fakeTarget = new GameObject("FakeTarget");
            //Transform fakeTransform = fakeTarget.transform;
            //if (player.data.view.IsMine || PhotonNetwork.OfflineMode)
            //{
            //    cursorX = MainCam.instance.cam.ScreenToWorldPoint(Input.mousePosition).x;
            //}
            //fakeTarget.transform.SetXPosition(cursorX);
            //fakeTarget.transform.SetYPosition(0f);
            //fakeTarget.transform.SetZPosition(0f);

            //projectile.SetPosition(new Vector3(cursorX, airStrikeHeight), IncludedAxes.XY); // shoot bullet from offscreen at cursor's x position
            //projectile.transform.LookAt(fakeTransform);
            //if (fakeTransform) { Destroy(fakeTransform); }
            //if (fakeTarget) { Destroy(fakeTarget); }
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
