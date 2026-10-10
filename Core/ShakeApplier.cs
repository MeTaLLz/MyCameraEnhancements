using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.CameraModifiers;

namespace MyCameraMods;

internal static class ShakeApplier
{
    internal static void Apply(Vector2 position, float strength)
    {
        if (!ConfigCache.EnableShake)
            return;

        Main.instance.CameraModifiers.Add(new PunchCameraModifier(
            position,
            Utils.ToRotationVector2(Utils.NextFloat(Main.rand) * MathHelper.TwoPi),
            strength,
            5f,
            30,
            1000f,
            null
        ));
    }
}