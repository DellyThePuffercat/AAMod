using Terraria;
using Terraria.ID;

namespace AAMod.Items.Flasks
{
    public class JungleFlask : BaseAAItem
    {
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 26;
            item.maxStack = 999;
            item.consumable = true;
            item.useTime = 28;
            item.useAnimation = 28;
            item.shoot = ModContent.ProjectileType<Projectiles.JungleSolution>();
            item.shootSpeed = 1f;
            item.useStyle = 1;
            item.value = Item.sellPrice(0, 0, 1, 0);
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.noUseGraphic = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Flask");
            Tooltip.SetDefault(@"Converts Forest into Jungle");
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {

            if (player.altFunctionUse != 2)
            {
                item.shoot = mod.ProjectileType("JungleFlask");
                item.shootSpeed = 9f;
            }
            else
            {
                item.shoot = mod.ProjectileType("JungleSolution");
                item.shootSpeed = 2f;
            }
            return base.CanUseItem(player);
        }
    }
}