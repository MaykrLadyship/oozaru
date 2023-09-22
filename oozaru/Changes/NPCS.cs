using System;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using oozaru.Items;
using oozaru.Assets;
using DBZGoatLib;
using DBZGoatLib.Handlers;
using DBZMODPORT;

namespace oozaru.Changes
{
    internal class NPCS : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.CultistBoss)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType < Items.SSJ4Item> (), 1 , 1, 1));
            }

            if (npc.type == NPCID.LunarTowerSolar)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.SSJ4FPItem>(), 1, 1, 1));
            }

            if (npc.type == NPCID.MoonLordCore)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.SSJ4LBItem>(), 1, 1, 1));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.LSSJ4Item>(), 1, 1, 1));
            }

        }

        public override void OnKill(NPC npc)
        {
            Player player = Main.player[Main.myPlayer];
            var OPlayer = player.GetModPlayer<OPlayer>();

            if (npc.boss && npc.type == NPCID.CultistBoss && player.GetModPlayer<MyPlayer>().masteryLevel3 >= 1f)
            {
                if (!OPlayer.SSJ4Achieved)
                {
                    OPlayer.SSJ4Achieved = true;
                    TransformationHandler.ClearTransformations(player);
                    TransformationHandler.Transform(player, TransformationHandler.GetTransformation("SSJ4Buff").Value);
                }
            }

            if (npc.boss && (npc.type == NPCID.LunarTowerNebula || npc.type == NPCID.LunarTowerSolar || npc.type == NPCID.LunarTowerStardust || npc.type == NPCID.LunarTowerVortex) && player.GetModPlayer<GPlayer>().GetMastery(ModContent.BuffType<Transformations.SSJ4Buff>()) >= 1)
            {
                if (!OPlayer.SSJ4FPAchieved)
                {
                    OPlayer.SSJ4FPAchieved = true;
                    TransformationHandler.ClearTransformations(player);
                    TransformationHandler.Transform(player, TransformationHandler.GetTransformation("SSJ4FPBuff").Value);
                }
            }

            if (npc.boss && npc.type == NPCID.MoonLordCore && player.GetModPlayer<GPlayer>().GetMastery(ModContent.BuffType<Transformations.SSJ4FPBuff>()) >= 1)
            {
                if (!OPlayer.SSJ4LBAchieved)
                {
                    OPlayer.SSJ4LBAchieved = true;
                    TransformationHandler.ClearTransformations(player);
                    TransformationHandler.Transform(player, TransformationHandler.GetTransformation("SSJ4LBBuff").Value);
                }
            }

            if (npc.boss && npc.type == NPCID.MoonLordCore && player.GetModPlayer<GPlayer>().Trait == "Legendary" && player.GetModPlayer<MyPlayer>().masteryLevelLeg3 >= 1f)
            {
                if (!OPlayer.LSSJ4Achieved)
                {
                    OPlayer.LSSJ4Achieved = true;
                    TransformationHandler.ClearTransformations(player);
                    TransformationHandler.Transform(player, TransformationHandler.GetTransformation("LSSJ4Buff").Value);
                }
            }

        }
    }
}
