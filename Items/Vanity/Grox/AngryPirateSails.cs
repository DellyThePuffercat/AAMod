using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace AAMod.Items.Vanity.Grox
{

    [AutoloadEquip(EquipType.Wings)]
    public class AngryPirateSails : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Angry Pirate's Skysails");
            Tooltip.SetDefault(@"Allows flight and slow fall
'Great for impersonating Ancients Awakened Devs!'");
		}

		public override void SetDefaults()
		{
			item.width = 42;
			item.height = 42;
			item.value = 500000;
			item.rare = 7;
			item.accessory = true;
		}

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(89, 119, 71);
                }
            }
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 300;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
        }

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
            speed = 10f;
            acceleration *= 2.5f;
        }

        public override bool WingUpdate(Player player, bool inUse)
        {
            if (inUse || player.jump > 0)
            {
                player.wingFrameCounter++;
                if (player.wingFrameCounter > 5)
                {
                    player.wingFrame++;
                    player.wingFrameCounter = 0;
                    if (player.wingFrame >= 4)
                    {
                        player.wingFrame = 1;
                    }
                }
            }
            else if (player.velocity.Y != 0f)
            {
                if (inUse)
                {
                    player.wingFrameCounter++;
                    if (player.wingFrameCounter > 8)
                    {
                        player.wingFrame++;
                        player.wingFrameCounter = 0;
                        if (player.wingFrame >= 4)
                        {
                            player.wingFrame = 1;
                        }
                    }
                }
                else
                {
                    player.wingFrame = 0;
                }
            }
            else
            {
                player.wingFrame = 0;
            }
            return false;
        }
    }
}
