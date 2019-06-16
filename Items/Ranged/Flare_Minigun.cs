using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Ranged
{
    public class Flare_Minigun : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flare Minigun");
			Tooltip.SetDefault("Shoots dozens of flares in rapid succession"
			+"\n33% chance not to consume flares"
			+"\nRight-click to disable all flares");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ChainGun);
			item.damage = 46;
			item.ranged = true;
			item.knockBack = 1;
			item.width = 62;
			item.height = 24;
			item.useTime = 10;
			item.useAnimation = 10;
			item.value = 200000;
			item.rare = 5;
			item.autoReuse = true;
			item.shoot = 163;
			item.useAmmo = AmmoID.Flare;
			item.UseSound = SoundID.Item11;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				for(int i = 0; i < 1000; ++i)
				{
					if(Main.projectile[i].active && Main.projectile[i].type == 163)
					{
						Main.projectile[i].Kill();
					}
				}
				return false;
			}
			else
			{
				return true;
			}
		}
		
		public override bool ConsumeAmmo(Player player)
		{
		return Main.rand.NextFloat() >= .33;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, 0);
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int num45 = 0;
            if (BaseMod.BasePlayer.HasItem(player, ItemID.BlueFlare, 1, true))
            {
                num45 = ProjectileID.BlueFlare;
            }
            else if (BaseMod.BasePlayer.HasItem(player, ItemID.Flare, 1, true))
            {
                num45 = ProjectileID.Flare;
            }
            Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
			Vector2 perturbedSpeed2 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
			Vector2 perturbedSpeed3 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
			Vector2 perturbedSpeed4 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(8));
			float speedX2 = perturbedSpeed2.X;
			float speedY2 = perturbedSpeed2.Y;
			float speedX3 = perturbedSpeed3.X;
			float speedY3 = perturbedSpeed3.Y;
			float speedX4 = perturbedSpeed4.X;
			float speedY4 = perturbedSpeed4.Y;
            if (num45 != 0)
            {
                Projectile.NewProjectile(vector.X, vector.Y, speedX2, speedY2, num45, damage, knockBack, player.whoAmI);
                Projectile.NewProjectile(vector.X, vector.Y, speedX, speedY, num45, damage, knockBack, player.whoAmI);
                Projectile.NewProjectile(vector.X, vector.Y, speedX3, speedY3, num45, damage, knockBack, player.whoAmI);
                Projectile.NewProjectile(vector.X, vector.Y, speedX4, speedY4, num45, damage, knockBack, player.whoAmI);
            }
			return false;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FlareGun);
			recipe.AddIngredient(ItemID.Minishark);
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.AddIngredient(ItemID.SoulofMight, 5);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
