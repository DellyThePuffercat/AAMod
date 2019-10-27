using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace AAMod.Items.Boss.Anubis.Forsaken
{
    public class Lifeline : BaseAAItem
    {

        public override void SetDefaults()
        {
            item.damage = 75;
            item.noMelee = true;
            item.ranged = true;
            item.width = 42;
            item.height = 60;

            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 5;
            item.shoot = 10;
            item.useAmmo = AmmoID.Arrow;
            item.knockBack = 2;
            item.rare = 11;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 25f;
            item.value = Item.buyPrice(0, 1, 0, 0);

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lifeline");
            Tooltip.SetDefault(@"Shoots 3 enchanced Mummy arrows at once
Shoots ``Forsaken arrows`` burst if at least 2 initial arrows hit the target
Forsaken arrows lower enemy contact damage");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<Projectiles.Anubis.Forsaken.EnchancedMummyArrow>(), (int)(damage * 1.5f), knockBack, player.whoAmI);
			float numberProjectiles = 2;
			float rotation = MathHelper.ToRadians(4);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 1f;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<Projectiles.Anubis.Forsaken.EnchancedMummyArrowD>(), (int)(damage * 1.5f), knockBack, player.whoAmI);
			}
            return false;
        }
    }
}