using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Steamworks;

namespace oozaru.Items.Vanity
{
    [AutoloadEquip(EquipType.Body)]
    internal class SSJ5Fur : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("SSJ5 Body Fur");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 14;

            Item.vanity = true;

            

        }
        public override void AddRecipes()
        {

            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<SSJ4Fur>();
            recipe.AddTile(TileID.WorkBenches);
        }

    }
}
