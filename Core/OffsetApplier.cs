using Terraria;
using Terraria.ModLoader;

namespace MyCameraMods;

internal class OffsetApplier : ModSystem
{
    private static OffsetModifier _modifier;

    public override void OnWorldLoad()
    {
        _modifier = new OffsetModifier();
        Main.instance.CameraModifiers.Add(_modifier);
    }

    public override void OnWorldUnload()
    {
        _modifier?.Finish();
        _modifier = null;
    }
}