using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace AAMod.Tiles.Furniture.Oroboros
{
    public class OroborosClock : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.Height = 5;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16,
				16,
				16,
				16
			};
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			// name.SetDefault("Oroboros Clock"); // Automatic from .lang files
			AddMapEntry(new Color(70, 0, 10), name);
			dustType = mod.DustType("DoomDust");
			adjTiles = new int[] { TileID.GrandfatherClocks };
		}

		public override bool NewRightClick(int i, int j)
		{
			{
				string text = "AM";
				//Get current weird time
				double time = Main.time;
				if (!Main.dayTime)
				{
					//if it's night add this number
					time += 54000.0;
				}
				//Divide by seconds in a day * 24
				time = time / 86400.0 * 24.0;
				//Dunno why we're taking 19.5. Something about hour formatting
				time = time - 7.5 - 12.0;
				//Format in readable time
				if (time < 0.0)
				{
					time += 24.0;
				}
				if (time >= 12.0)
				{
					text = "PM";
				}
				int intTime = (int)time;
				//Get the decimal points of time.
				double deltaTime = time - intTime;
				//multiply them by 60. Minutes, probably
				deltaTime = (int)(deltaTime * 60.0);
				//This could easily be replaced by deltaTime.ToString()
				string text2 = string.Concat(deltaTime);
				if (deltaTime < 10.0)
				{
					//if deltaTime is eg "1" (which would cause time to display as HH:M instead of HH:MM)
					text2 = "0" + text2;
				}
				if (intTime > 12)
				{
					//This is for AM/PM time rather than 24hour time
					intTime -= 12;
				}
				if (intTime == 0)
				{
					//0AM = 12AM
					intTime = 12;
				}
				//Whack it all together to get a HH:MM format
				var newText = string.Concat(Language.GetTextValue("CLI.Time_Command") + ": ", intTime, ":", text2, " ", text);
				if (Main.netMode != 1) BaseMod.BaseUtility.Chat(newText, 255, 240, 20);
			}
			return true;
		}

		public override void NearbyEffects(int i, int j, bool closer)
		{
			if (closer)
			{
				Main.clock = true;
			}
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 48, 32, mod.ItemType("OroborosClock"));
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
            int height = tile.frameY == 36 ? 18 : 16;
            Main.spriteBatch.Draw(mod.GetTexture("Tiles/Furniture/Oroboros/OroborosClock_Glow"), new Vector2((i * 16) - (int)Main.screenPosition.X, (j * 16) - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY, 16, height), AAColor.Glow, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}