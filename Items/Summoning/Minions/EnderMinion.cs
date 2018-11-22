using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace AAMod.Items.Summoning.Minions
{
    public class EnderMinion : Minion2
    {
        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.CloneDefaults(533); // ID for Deadly Sphere proj
            aiType = 533;
            projectile.width = 62;
            projectile.height = 62;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.minionSlots = 1;
            projectile.penetrate = -1;
            projectile.timeLeft = 300;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ender Minion");

        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = oldVelocity.X;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = oldVelocity.Y;
            }
            return false;
        }

        public override void CheckActive()
        {
            Player player = Main.player[projectile.owner];
            AAPlayer modPlayer = (AAPlayer)player.GetModPlayer(mod, "AAPlayer");
            if (player.dead)
            {
                modPlayer.enderMinion = false;
            }
            if (modPlayer.enderMinion)
            {
                projectile.timeLeft = 2;
            }
        }
    }
}