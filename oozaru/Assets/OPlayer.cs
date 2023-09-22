using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Utilities;
using DBZGoatLib;
using DBZGoatLib.Handlers;
using System;
using DBZGoatLib.Model;
using Microsoft.Xna.Framework;
using oozaru.Transformations;
using System.Security.Policy;
using DBZMODPORT;
using DBZMODPORT.Buffs.SSJBuffs;
using oozaru.Assets;

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

        public bool LSSJ4Active;
        public bool LSSJ4UnlockMsg;
        public bool LSSJ4Achieved;

        public static ModKeybind PowerUp;

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

            if (LSSJ4Achieved && !LSSJ4UnlockMsg)
            {
                LSSJ4UnlockMsg = true;
                Main.NewText("You have unlocked your true potential. Legendary Super Saiyan 4 has been achieved!");
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

            tag.Add("oozaru_LSSJ4Achieved", LSSJ4Achieved);
            tag.Add("oozaru_LSSJ4UnlockMsg", LSSJ4UnlockMsg);
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

            if (tag.ContainsKey("oozaru_LSSJ4Achieved"))
                LSSJ4Achieved = tag.GetBool("oozaru_LSSJ4Achieved");
            if (tag.ContainsKey("oozaru_LSSJ4UnlockMsg"))
                LSSJ4UnlockMsg = tag.GetBool("oozaru_LSSJ4UnlockMsg");
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            Player player = Main.player[Main.myPlayer];

            if (PowerUp.JustPressed)
            {

                if (player.GetModPlayer<OPlayer>().SSJ4Achieved && base.Player.HasBuff<SSJ3Buff>() && !base.Player.HasBuff<Cooldown>())
                {
                    TransformationHandler.ClearTransformations(base.Player);
                    player.AddBuff(ModContent.BuffType<Cooldown>(), 3);
                    TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("SSJ4Buff").Value);
                }

                if (player.GetModPlayer<OPlayer>().SSJ4FPAchieved && base.Player.HasBuff<SSJ4Buff>() && !base.Player.HasBuff<Cooldown>())
                {
                    TransformationHandler.ClearTransformations(base.Player);
                    player.AddBuff(ModContent.BuffType<Cooldown>(), 3);
                    TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("SSJ4FPBuff").Value);
                }

                if (player.GetModPlayer<OPlayer>().SSJ4LBAchieved && base.Player.HasBuff<SSJ4FPBuff>() && !base.Player.HasBuff<Cooldown>())
                {
                    TransformationHandler.ClearTransformations(base.Player);
                    player.AddBuff(ModContent.BuffType<Cooldown>(), 3);
                    TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("SSJ4LBBuff").Value);
                }

                if (player.GetModPlayer<OPlayer>().LSSJ4Achieved && base.Player.HasBuff<LSSJ3Buff>() && !base.Player.HasBuff<Cooldown>())
                {
                    TransformationHandler.ClearTransformations(base.Player);
                    player.AddBuff(ModContent.BuffType<Cooldown>(), 3);
                    TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("LSSJ4Buff").Value);
                }
                /*
                if (player.GetModPlayer<OPlayer>().SSJ5Achieved && base.Player.HasBuff<SSJ4LBBuff>() && !base.Player.HasBuff<Cooldown>())
                {
                    TransformationHandler.ClearTransformations(base.Player);
                    player.AddBuff(ModContent.BuffType<Cooldown>(), 3);
                    TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("SSJ5Buff").Value);
                }

                if (player.GetModPlayer<OPlayer>().SSJ5FPAchieved && base.Player.HasBuff<SSJ5Buff>() && !base.Player.HasBuff<Cooldown>())
                {
                    TransformationHandler.ClearTransformations(base.Player);
                    player.AddBuff(ModContent.BuffType<Cooldown>(), 3);
                    TransformationHandler.Transform(base.Player, TransformationHandler.GetTransformation("SSJ5FPBuff").Value);
                }
                */
            }
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
                new Connection(3,3,1,false,new Gradient(Color.LightGreen).AddStop(0.60f, new Color(255, 56, 99))),
            };

            public override string Name() => "Oozaru";
           
            public override Node[] Nodes() => new Node[]
            {
               new Node(2,1, "SSJ4Buff", "oozaru/Transformations/SSJ4Buff", "A cultist will push you to your limts, it is up to you to break them.", UnlockConditionSSJ4, DiscoverConditionSSJ4),
               new Node(2,0, "SSJ4FPBuff", "oozaru/Transformations/SSJ4FPBuff", "A pillar from the sun will grant you your full power.",UnlockConditionSSJ4FP, DiscoverConditionSSJ4FP),
               new Node(4,0, "SSJ4LBBuff", "oozaru/Transformations/SSJ4LBBuff", "The lord of moons awaits",UnlockConditionSSJ4LB, DiscoverConditionSSJ4LB),
               new Node(4,3,"LSSJ4Buff","oozaru/Transformations/LSSJ4Buff","Only defeating a foe of cosmic proportions can unlock this power.",UnlockConditionLSSJ4,DiscoverConditionLSSJ4),
            };

            public bool UnlockConditionSSJ4(Player player)
            {
                var Oplayer = player.GetModPlayer<OPlayer>();
                return Oplayer.SSJ4Achieved && player.GetModPlayer<MyPlayer>().masteryLevel3 >= 0.9f;
            }

            public bool DiscoverConditionSSJ4(Player player)
            {
                return player.GetModPlayer<MyPlayer>().masteryLevel3 != 0;
            }

            public bool UnlockConditionSSJ4FP(Player player)
            {
                var Oplayer = player.GetModPlayer<OPlayer>();
                return Oplayer.SSJ4FPAchieved && player.GetModPlayer<GPlayer>().GetMastery(ModContent.BuffType<Transformations.SSJ4Buff>()) >= 1;
            }

            public bool DiscoverConditionSSJ4FP(Player player)
            {
                var Oplayer = player.GetModPlayer<OPlayer>();
                return Oplayer.SSJ4Achieved;
            }

            public bool UnlockConditionSSJ4LB(Player player)
            {
                var Oplayer = player.GetModPlayer<OPlayer>();
                return Oplayer.SSJ4LBAchieved && player.GetModPlayer<GPlayer>().GetMastery(ModContent.BuffType<Transformations.SSJ4FPBuff>()) >= 1;
            }

            public bool DiscoverConditionSSJ4LB(Player player)
            {
                var Oplayer = player.GetModPlayer<OPlayer>();
                return Oplayer.SSJ4FPAchieved;
            }
            public bool UnlockConditionLSSJ4(Player player)
            {
                var Oplayer = player.GetModPlayer<OPlayer>();
                return Oplayer.LSSJ4Achieved && player.GetModPlayer<GPlayer>().Trait == "Legendary";
            }
            public bool DiscoverConditionLSSJ4(Player player)
            {
                return player.GetModPlayer<MyPlayer>().masteryLevelLeg3 != 0 && player.GetModPlayer<GPlayer>().Trait == "Legendary";
            }
        }
    }
}
