using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.CameraModifiers;

namespace MyCameraMods;

internal class OffsetModifier : ICameraModifier
{
    private Vector2 _cameraPosition = Vector2.Zero;
    private Vector2 _lerpedOffset = Vector2.Zero;
    private Vector2? _oldPosition;

    private const float FactorMultiplier = 11f / 1.8f;

    public string UniqueIdentity { get; private set; }
    public bool Finished { get; private set; }

    public void Update(ref CameraInfo camera)
    {
        if (!ConfigCache.EnableOffset)
            return;

        if (_oldPosition == null)
            _oldPosition = Main.screenPosition;

        Vector2 screenPosition = Main.screenPosition;
        Vector2 target = screenPosition + GetOffset();
        bool smooth = IsSmoothingRequired(_oldPosition.Value, screenPosition);
        float smoothness = GetSmoothness();

        _cameraPosition = smooth
            ? CameraMath.Lerp(_oldPosition.Value, target, smoothness, Time.DeltaTime)
            : screenPosition;

        camera.CameraPosition = _cameraPosition;
        _oldPosition = _cameraPosition;
    }

    private Vector2 GetOffset()
    {
        Vector2 result = Vector2.Zero;

        if (ConfigCache.EnableDynamic)
        {
            var (offset, smooth) = CalculateDynamicOffset(Main.LocalPlayer.velocity);
            _lerpedOffset = CameraMath.Lerp(_lerpedOffset, offset, smooth, Time.DeltaTime);
            result = _lerpedOffset;
        }

        if (ConfigCache.EnableMouse)
        {
            Vector2 mouseOffset = CenterToScreen(Main.MouseScreen) / (25f - ConfigCache.MouseStrength * 2);
            result += mouseOffset;
        }

        return result;
    }

    private static Vector2 CenterToScreen(Vector2 position)
        => position - new Vector2(Main.screenWidth, Main.screenHeight) / 2f;

    private static bool IsSmoothingRequired(Vector2 oldPosition, Vector2 newPosition)
    {
        Vector2 screenSize = new(Main.screenWidth, Main.screenHeight);
        Vector2 diff = newPosition - oldPosition;
        float distSq = diff.LengthSquared();
        float maxDistSq = screenSize.LengthSquared() * 0.5f + 100f;
        return distSq < maxDistSq;
    }

    private static float GetSmoothness()
    {
        float smoothness = ConfigCache.Smoothness;
        return smoothness != 0f ? 0.1f * smoothness : 1E-14f;
    }

    private static (Vector2, float) CalculateDynamicOffset(Vector2 velocity)
    {
        float hFactor = 0f;
        float vFactor = 0f;
        float smooth = 0f;

        if (ConfigCache.RequiredXSpeed <= Math.Abs(velocity.X))
        {
            hFactor = GetCalculatedFactor(ConfigCache.HorizontalFactor);
            smooth = ConfigCache.DynamicSmoothness;
        }
        if (ConfigCache.RequiredYSpeed <= Math.Abs(velocity.Y))
        {
            vFactor = GetCalculatedFactor(ConfigCache.VerticalFactor);
            smooth = ConfigCache.DynamicSmoothness;
        }

        Vector2 zero = new(hFactor, vFactor);
        float value = smooth <= 0f ? 1E-14f : smooth * 0.1f;

        return (velocity * zero, value);
    }

    private static float GetCalculatedFactor(float offsetFactor)
        => FactorMultiplier * offsetFactor;

    public void Finish()
    {
        Finished = true;
    }
}