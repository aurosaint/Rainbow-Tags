namespace RainbowTags
{
    using PluginAPI.Core;
    using PluginAPI.Core.Attributes;
    using PluginAPI.Events;

    public class Plugin
    {
        public static Plugin Instance { get; private set; }

        [PluginConfig("config/rainbow-tags.yml")]
        public Config Config;

        [PluginEntryPoint("Rainbow Tags", "1.0.0", "A plugin that will add a rainbow tag.", "MrAfitol")]
        public void LoadPlugin()
        {
            Instance = this;

            EventManager.RegisterEvents<EventHandlers>(this);

            var handler = PluginHandler.Get(this);
            handler.SaveConfig(this, nameof(Config));
        }
    }
}
