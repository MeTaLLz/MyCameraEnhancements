using Terraria;
using Terraria.ModLoader;

namespace MyCameraMods;

internal class ShakeProjectile : GlobalProjectile
{
    public override void OnKill(Projectile projectile, int timeLeft)
    {
        if (!Shakable.Projectiles.Contains(projectile.type))
            return;

        float strength = 15f * ConfigCache.ShakeStrength;
        ShakeApplier.Apply(projectile.Center, strength);
    }
}
