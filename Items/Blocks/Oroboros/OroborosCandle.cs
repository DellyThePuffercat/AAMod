using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Blocks.Oroboros
{
    public class OroborosCandle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Oroboros Candle");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 18;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 250;
            item.createTile = mod.TileType("OroborosCandle");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("OroborosWood"), 4);
            recipe.AddIngredient(ItemID.Torch, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }

    }
}