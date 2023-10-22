using System;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using Terraria;
using oozaru144port.Items;

namespace oozaru144port.Changes
{
    internal class NPCS : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.CultistBoss)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.SSJ4Item>(), 1 , 1, 1));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Vanity.SSJ4Fur>(),1, 1, 1));
            }

            if (npc.type == NPCID.LunarTowerSolar)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.SSJ4FPItem>(), 1, 1, 1));
            }

            if (npc.type == NPCID.MoonLordCore)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.SSJ4LBItem>(), 1, 1, 1));
            }

        }
    }
}
