using Terraria.ModLoader;

namespace MyCameraMods
{
    internal static class Instances
    {
        public static Config Config => ModContent.GetInstance<Config>();
    }
}