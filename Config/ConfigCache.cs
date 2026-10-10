namespace MyCameraMods;

internal static class ConfigCache
{
    public static bool EnableOffset { get; private set; } = true;
    public static float Smoothness { get; private set; } = 1f;
    public static bool EnableShake { get; private set; } = false;
    public static float ShakeStrength { get; private set; } = 1.0f;
    public static bool EnableMouse { get; private set; } = true;
    public static int MouseStrength { get; private set; } = 4;
    public static bool EnableDynamic { get; private set; } = true;
    public static float HorizontalFactor { get; private set; } = 2f;
    public static float VerticalFactor { get; private set; } = 2f;
    public static int RequiredXSpeed { get; private set; } = 0;
    public static int RequiredYSpeed { get; private set; } = 0;
    public static float DynamicSmoothness { get; private set; } = 0f;

    public static void Update(Config config)
    {
        if (config == null) return;

        EnableOffset = config.EnableOffset;
        Smoothness = config.Smoothness;
        EnableShake = config.EnableShake;
        ShakeStrength = config.ShakeStrength;
        EnableMouse = config.EnableMouse;
        MouseStrength = config.MouseStrength;
        EnableDynamic = config.EnableDynamic;
        HorizontalFactor = config.HorizontalFactor;
        VerticalFactor = config.VerticalFactor;
        RequiredXSpeed = config.RequiredXSpeed;
        RequiredYSpeed = config.RequiredYSpeed;
        DynamicSmoothness = config.DynamicSmoothness;
    }
}