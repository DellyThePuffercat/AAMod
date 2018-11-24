using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace AAMod.Items.Boss.Yamata
{
	public class AbyssArrow : ModItem
	{
        public static short customGlowMask = 0;
        public override void SetStaticDefaults()
        {
            if (Main.netMode != 2)
            {
                Microsoft.Xna.Framework.Graphics.Texture2D[] glowMasks = new Microsoft.Xna.Framework.Graphics.Texture2D[Main.glowMaskTexture.Length + 1];
                for (int i = 0; i < Main.glowMaskTexture.Length; i++)
                {
                    glowMasks[i] = Main.glowMaskTexture[i];
                }
                glowMasks[glowMasks.Length - 1] = mod.GetTexture("Items/Boss/Yamata/" + GetType().Name + "_Glow");
                customGlowMask = (short)(glowMasks.Length - 1);
                Main.glowMaskTexture = glowMasks;
            }
            DisplayName.SetDefault("Eventide Arrow");
			Tooltip.SetDefault(@"Blinds its target with the darkness of the moonless night
Inflicts Moonraze
Non-consumable");
		}

		public override void SetDefaults()
		{
			item.damage = 23;
			item.ranged = true;
			item.width = 14;
			item.height = 40;
			item.consumable = false;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 7f;
			item.value = Item.buyPrice(1, 0, 0, 0); ;
			item.rare = 6;
			item.shoot = mod.ProjectileType("AbyssArrow");   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 3f;                  //The speed of the projectile
			item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
            item.glowMask = customGlowMask;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(45, 46, 70);
                }
            }
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EventideAbyssium", 1);
            recipe.AddIngredient(null, "DreadScale", 1);
            recipe.AddIngredient(ItemID.MoonlordArrow, 999);
            recipe.AddTile(null, "BinaryReassembler");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
