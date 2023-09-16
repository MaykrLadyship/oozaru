using Terraria;
using Terraria.ModLoader;
using DBZGoatLib;
using System;
using DBZGoatLib.Model;
using Microsoft.Xna.Framework;
using oozaru.Transformations;
using System.Security.Policy;
using Terraria.ModLoader.IO;

namespace oozaru.Assets
{
    internal class OPlayer : ModPlayer
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
        }

        public override void SaveData(TagCompound tag)
        {
            tag.Add("oozaru_SSJ4Achieved", SSJ4Achieved);
            tag.Add("oozaru_SSJ4UnlockMsg", SSJ4UnlockMsg);
            tag.Add("oozaru_SSJ4FPAchieved", SSJ4FPAchieved);
            tag.Add("oozaru_SSJ4FPUnlockMsg", SSJ4FPUnlockMsg);
            tag.Add("oozaru_SSJ4LBAchieved", SSJ4LBAchieved);
            tag.Add("oozaru_SSJ4LBUnlockMsg", SSJ4LBUnlockMsg);
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
        }



        public class SSJ4Panel : TransformationTree
        {
            public override bool Complete() => false;


            public override bool Condition(Player player)
            {
               var Oplayer = player.GetModPlayer<OPlayer>();
                return true;
            }

            public override Connection[] Connections() => new Connection[]
            {
          new Connection(2,1,1,true, new Gradient(Color.LightYellow).AddStop(0.65f, new Color (255,255,0))),
           new Connection(2,0,1,true, new Gradient(Color.LightYellow).AddStop(0.65f, new Color (255,255,0))),
           new Connection(2,0,2,false, new Gradient(Color.HotPink).AddStop(0.65f, new Color(255,42,79))),
            };

            public override string Name() => "Oozaru";
           
            public override Node[] Nodes() => new Node[]
            {
               new Node(2,1, "SSJ4Buff", "oozaru/Transformations/SSJ4Buff", "A cultist will push you to your limts, it is up to you to break them.", UnlockConditionSSJ4, DiscoverConditionSSJ4),
               new Node(2,0, "SSJ4FPBuff", "oozaru/Transformations/SSJ4FPBuff", "A pillar from the sun will grant you your full power.",UnlockConditionSSJ4FP, DiscoverConditionSSJ4FP),
               new Node(3,0, "SSJ4LBBuff", "oozaru/Transformations/SSJ4LBBuff", "The lord of moons awaits",UnlockConditionSSJ4LB, DiscoverConditionSSJ4LB),

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
        }




    }
}
