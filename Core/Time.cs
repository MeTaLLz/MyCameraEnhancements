using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MyCameraMods;

internal class Time : ModSystem
{
    private static float _lastTime;

    public static float DeltaTime { get; private set; } = 1f / 60f;

    public override void Load()
    {
        Main.QueueMainThreadAction(() =>
        {
            On_Main.DoDraw += OnDoDraw;
        });
    }

    public override void Unload()
    {
        On_Main.DoDraw -= OnDoDraw;
    }

    private static void OnDoDraw(On_Main.orig_DoDraw Orig, Main Self, GameTime GameTime)
    {
        float now = (float)GameTime.TotalGameTime.TotalSeconds;
        DeltaTime = now - _lastTime;
        _lastTime = now;
        Orig(Self, GameTime);
    }
}