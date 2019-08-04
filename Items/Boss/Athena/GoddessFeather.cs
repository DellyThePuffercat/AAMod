namespace AAMod.Items.Boss.Athena
{
    public class GoddessFeather : BaseAAItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Goddess Feather");
        }
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.maxStack = 99;
            item.rare = 7;
        }
    }
}
