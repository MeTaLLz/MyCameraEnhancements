using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.NPC;

namespace MyCameraMods;

internal class ShakeNPC : GlobalNPC
{
    public override void OnHitByItem(NPC npc, Player player, Item item, HitInfo hit, int damageDone)
        => OnHit(npc);

    public override void OnHitByProjectile(NPC npc, Projectile projectile, HitInfo hit, int damageDone)
        => OnHit(npc);

    private static void OnHit(NPC npc)
    {
        if (!npc.boss && !NPCID.Sets.ShouldBeCountedAsBoss[npc.type])
            return;

        bool killed = npc.life <= 0;
        float strength = (killed ? 10f : 5f) * ConfigCache.ShakeStrength;
        ShakeApplier.Apply(npc.position, strength);
    }
}