using Microsoft.Xna.Framework;
using Terraria;
using DBZGoatLib;
using DBZGoatLib.Handlers;
using Terraria.ModLoader;
using Terraria.ID;
using oozaru.Assets;
using System.ComponentModel.DataAnnotations;

namespace oozaru.Items
{
    internal class SSJ4LBItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Limit Breaker");
            Tooltip.SetDefault("Break those limits.");
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
            return !oplayer.SSJ4LBAchieved;
        }

        public override void OnConsumeItem(Player player)
     
        {
            var oplayer = player.GetModPlayer<OPlayer>();
            if (!oplayer.SSJ4LBAchieved)
            {
                oplayer.SSJ4LBAchieved = true;
            }
        }
    }
   
}
