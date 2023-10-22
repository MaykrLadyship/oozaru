using Terraria;
using Terraria.ModLoader;
using DBZGoatLib;
using System;
using DBZGoatLib.Model;
using Microsoft.Xna.Framework;
using Steamworks;
using oozaru144port.Transformations;
using System.Security.Policy;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;

namespace oozaru144port.Assets
{
    public class OPlayer : ModPlayer
    {
        public bool SSJ4Active;
        public bool SSJ4UnlockMsg;
        public bool SSJ4Achieved;

        public bool SSJ4FPActive;
        public bool SSJ4FPUnlockMsg;
        public bool SSJ4FPAchieved;

        public bool SSJ4LBActive;
        public bool SSJ4LBUnlockMsg;
        public bool SSJ4LBAchieved;

        public bool SSJ5Active;
        public bool SSJ5UnlockMsg;
        public bool SSJ5Achieved;

        public bool SSJ5FPActive;
        public bool SSJ5FPUnlockMsg;
        public bool SSJ5FPAchieved;


        public DateTime? Offset = null;

        public DateTime? PoweringUpTime = null;
        public DateTime? LastPowerUpTick = null;

        private TransformationInfo? Form = null;

        public override void PostUpdate()
        {
            if (SSJ4Achieved && !SSJ4UnlockMsg)
            {
                SSJ4UnlockMsg = true;
                Main.NewText("You have gone once again, one step beyond.");
            }

            if (SSJ4FPAchieved && !SSJ4FPUnlockMsg)
            {
                SSJ4FPUnlockMsg = true;
                Main.NewText("Use your full power to blow them away.");
            }

            if (SSJ4LBAchieved && !SSJ4LBUnlockMsg)
            {
                SSJ4LBUnlockMsg = true;
                Main.NewText("Limit Break X Survior is such a banger, honestly kinda tempted to make the aura sound the song.");
            }

            if (SSJ5Achieved && !SSJ4UnlockMsg)
            {
                SSJ5UnlockMsg = true;
                Main.NewText("Your power quakes across the land!");
            }

            if (SSJ5FPAchieved && !SSJ5FPUnlockMsg)
            {
                SSJ5FPUnlockMsg = true;
                Main.NewText("Young Jijii would be proud! Now, show them what you're made of!!");
            }
        }

        public override void SaveData(TagCompound tag)
        {
            tag.Add("oozaru_SSJ4Achieved", SSJ4Achieved);
            tag.Add("oozaru_SSJ4UnlockMsg", SSJ4UnlockMsg);
            tag.Add("oozaru_SSJ4FPAchieved", SSJ4FPAchieved);
            tag.Add("oozaru_SSJ4FPUnlockMsg", SSJ4FPUnlockMsg);
            tag.Add("oozaru_SSJ4LBAchieved", SSJ4LBAchieved);
            tag.Add("oozaru_SSJ4LBUnlockMsg", SSJ4LBUnlockMsg);
            tag.Add("oozaru_SSJ5Achieved", SSJ5Achieved);
            tag.Add("oozaru_SSJ5UnlockMsg", SSJ5UnlockMsg);
            tag.Add("oozaru_SSJ5FPAchieved", SSJ5FPAchieved);
            tag.Add("oozaru_SSJ5FPUnlockMsg", SSJ5FPUnlockMsg);
        }

        public override void LoadData(TagCompound tag)
        {
            if (tag.ContainsKey("oozaru_SSJ4Achieved"))
                SSJ4Achieved = tag.GetBool("oozaru_SSJ4Achieved");
            if (tag.ContainsKey("oozaru_SSJ4UnlockMsg"))
                SSJ4UnlockMsg = tag.GetBool("oozaru_SSJ4UnlockMsg");
            if (tag.ContainsKey("oozaru_SSJ4FPAchieved"))
                SSJ4FPAchieved = tag.GetBool("oozaru_SSJ4FPAchieved");
            if (tag.ContainsKey("oozaru_SSJ4FPUnlockMsg"))
                SSJ4FPUnlockMsg = tag.GetBool("oozaru_SSJ4FPUnlockMsg");
            if (tag.ContainsKey("oozaru_SSJ4LBAchieved"))
                SSJ4LBAchieved = tag.GetBool("oozaru_SSJ4LBAchieved");
            if (tag.ContainsKey("oozaru_SSJ4LBUnlockMsg"))
                SSJ4LBUnlockMsg = tag.GetBool("oozaru_SJS4LBUnlockMsg");
            if (tag.ContainsKey("oozaru_SSJ5Achieved"))
                SSJ5Achieved = tag.GetBool("oozaru_SSJ5Achieved");
            if (tag.ContainsKey("oozaru_SSJ5UnlockMsg"))
                SSJ5UnlockMsg = tag.GetBool("oozaru_SSJ5UnlockMsg");  //heck I am sleepy for some reason
            if (tag.ContainsKey("oozaru_SSJ5FPAchieved"))
                SSJ5FPAchieved = tag.GetBool("oozaru_SSJ5FPAchieved");
            if (tag.ContainsKey("oozaru_SSJ5FPUnlockMsg"))
                SSJ5FPUnlockMsg = tag.GetBool("oozaru_SSJ5FPUnlockMsg");

        }

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (SSJ4LBActive && Main.rand.NextBool(4))
            {
                SSJ5Achieved = true;
                SSJ5Active = true;
                SSJ4LBActive = false;
                Player.statLife = Player.statLifeMax2;
                return false;
            }
            if (SSJ5Active && Main.rand.NextBool(4))
            {
                SSJ5FPAchieved= true;
                SSJ5FPActive = true;
                SSJ5Active = false;
                Player.statLife = Player.statLifeMax2;
                return false;
            }
            return true;
        }



        public class SSJ4Panel : TransformationTree
        {
            public override bool Complete() => true;


            public override bool Condition(Player player)
            {
               var Oplayer = player.GetModPlayer<OPlayer>();
                return true;
            }

            public override Connection[] Connections() => new Connection[]
            {
                new Connection(0,2,1,false, new Gradient(Color.LightYellow).AddStop(0.65f, new Color (255,255,0))),
                new Connection(1,2,1,false, new Gradient(Color.LightYellow).AddStop(0.65f, new Color (255,255,0))),
                new Connection(2,2,1,false, new Gradient(Color.HotPink).AddStop(0.65f, new Color(255,42,79))),
                new Connection(3,2,2,false, new Gradient(Color.HotPink).AddStop(0.65f,new Color(125,125,125))), //this mod just getting bigger
            };

            public override string Name() => "Join the Discord!";
           
            public override Node[] Nodes() => new Node[]
            {
               new Node(0,2, "SSJ4Buff", "oozaru144port/Transformations/SSJ4Buff", "A cultist will push you to your limts, it is up to you to break them.", UnlockConditionSSJ4, DiscoverConditionSSJ4),
               new Node(1,2, "SSJ4FPBuff", "oozaru144port/Transformations/SSJ4FPBuff", "A pillar from the sun will grant you your full power.",UnlockConditionSSJ4FP, DiscoverConditionSSJ4FP),
               new Node(2,2, "SSJ4LBBuff", "oozaru144port/Transformations/SSJ4LBBuff", "The lord of moons awaits",UnlockConditionSSJ4LB, DiscoverConditionSSJ4LB),
               new Node(3,2, "SSJ5Buff", "oozaru144port/Transformations/SSJ5Buff", "Dying in SSJ4LB will have a 20% chance to unlock this form",UnlockConditionSSJ5, DiscoverConditionSSJ5),
               new Node(5,2, "SSJ5FPBuff", "oozaru144port/Transformations/SSJ5FPBuff", "Dying in SSJ5 will unlock this with a 20 percent chance",UnlockConditionSSJ5FP, DiscoverConditionSSJ5FP),
            };

            public bool UnlockConditionSSJ4(Player player)
            {
                var Oplayer = player.GetModPlayer<OPlayer>();
                return Oplayer.SSJ4Achieved;
            }

            public bool DiscoverConditionSSJ4(Player player)
            {
                return true;
            }

            public bool UnlockConditionSSJ4FP(Player player)
            {
                var Oplayer = player.GetModPlayer<OPlayer>();
                return Oplayer.SSJ4FPAchieved;
            }

            public bool DiscoverConditionSSJ4FP(Player player)
            {
                return true;
            }

            public bool UnlockConditionSSJ4LB(Player player)
            {
                var Oplayer = player.GetModPlayer<OPlayer>();
                return Oplayer.SSJ4LBAchieved;
            }

            public bool DiscoverConditionSSJ4LB(Player player)
            {
                return true;
            }

            public bool UnlockConditionSSJ5(Player player)
            {
                var Oplayer = player.GetModPlayer<OPlayer>();
                return Oplayer.SSJ5Achieved;
            }

            public bool DiscoverConditionSSJ5(Player player)
            {
                return true;
            }

            public bool UnlockConditionSSJ5FP(Player player)
            {
                var Oplayer = player.GetModPlayer<OPlayer>();
                return Oplayer.SSJ5FPAchieved;
            }

            public bool DiscoverConditionSSJ5FP(Player player)
            {
                return true;
            }
        }


       

    }
}
