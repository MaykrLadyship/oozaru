using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
namespace oozaru144port.Items.Vanity
{
    [AutoloadEquip(EquipType.Body)]
    internal class SSJ4Fur : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("SSJ4 Body Fur? Hair?");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 14;

            Item.vanity = true;
        }
    }
}
