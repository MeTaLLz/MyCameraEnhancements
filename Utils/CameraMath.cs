using System;
using Microsoft.Xna.Framework;

namespace MyCameraMods;

internal static class CameraMath
{
    public static Vector2 Lerp(Vector2 source, Vector2 target, float smoothing, float deltaTime)
        => new(
            Lerp(source.X, target.X, smoothing, deltaTime),
            Lerp(source.Y, target.Y, smoothing, deltaTime)
        );

    public static float Lerp(float source, float target, float smoothing, float deltaTime)
        => MathHelper.Lerp(source, target, 1f - MathF.Pow(smoothing, deltaTime));
}