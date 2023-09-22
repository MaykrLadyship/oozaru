using Microsoft.Xna.Framework;
using Terraria;
using DBZGoatLib;
using DBZGoatLib.Handlers;
using Terraria.ModLoader;
using Terraria.ID;
using oozaru.Assets;

namespace oozaru.Items
{
    internal class SSJ4FPItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Full Power");
            // Tooltip.SetDefault("Fully powered");
        }

        public override void SetDefaults()
        {
            Item.consumable = true;
            Item.potion = false;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.noMelee = true;
            Item.scale = 1f;
        }

        public override bool? UseItem(Player player)
        {
            var oplayer = player.GetModPlayer<OPlayer>();
            return !oplayer.SSJ4FPAchieved;
        }

        public override void OnConsumeItem(Player player)
        {
            var oplayer = player.GetModPlayer<OPlayer>();
            if (!oplayer.SSJ4FPAchieved)
            {
                oplayer.SSJ4FPAchieved = true;
            }
        }
    }
}
