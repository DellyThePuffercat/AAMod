using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using AAMod.Projectiles.Yamata;
using System.Collections.Generic;

namespace AAMod.Items.Boss.Yamata
{
    public class FallingTwilight : BaseAAItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Falling Twilight");
        }

        public override void SetDefaults()
        {
            item.damage = 110;
            item.ranged = true;
            item.width = 44;
            item.height = 76;
            item.useAnimation = 15;
            item.useTime = 5;
            item.reuseDelay = 17;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2.5f;
            item.value = Item.sellPrice(0, 30, 0, 0);
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = 1;
            item.shootSpeed = 14f;
            item.useAmmo = AmmoID.Arrow;
            item.rare = 9; AARarity = 13;
        }

        public override bool ConsumeAmmo(Player player)
        {
            return !(player.itemAnimation < item.useAnimation - 1);
        }


        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = AAColor.Rarity13;;
                }
            }
        }


        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
            float num117 = 0.314159274f;
            int num118 = 6;
            Vector2 vector7 = new Vector2(speedX, speedY);
            vector7.Normalize();
            vector7 *= 40f;
            bool flag11 = Collision.CanHit(vector2, 0, 0, vector2 + vector7, 0, 0);
            for (int num119 = 0; num119 < num118; num119++)
            {
                float num120 = num119 - (num118 - 1f) / 2f;
                Vector2 value9 = vector7.RotatedBy(num117 * num120, default);
                if (!flag11)
                {
                    value9 -= vector7;
                }
                int num121 = Projectile.NewProjectile(vector2.X + value9.X, vector2.Y + value9.Y, speedX, speedY, type, (int)damage, knockBack, player.whoAmI, 0.0f, 0.0f);
                Main.projectile[num121].noDropItem = true;
            }
            float SpeedX = speedX + Main.rand.Next(-25, 26) * 0.05f;
            float SpeedY = speedY + Main.rand.Next(-25, 26) * 0.05f;
            Projectile.NewProjectile(position.X, position.Y, SpeedX, SpeedY, mod.ProjectileType<YamataSoul>(), damage, knockBack, player.whoAmI, 0.0f, 0.0f);
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EventideAbyssium", 5);
            recipe.AddIngredient(null, "DreadScale", 5);
            recipe.AddIngredient(ItemID.Tsunami);
            recipe.AddTile(null, "ACS");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
