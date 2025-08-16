using System;
using Exiled.API.Features;
using Exiled.Events.Handlers;
using Player = Exiled.Events.Handlers.Player;

namespace RainbowTags
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "RainbowTags";
        public override string Author => "AuroSaint";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(9, 0, 0);

        private EventHandlers eventHandlers;

        public override void OnEnabled()
        {
            Log.Info("Official github link: https://github.com/MrAfitol/Rainbow-Tags (Plugin made by MrAfitol.) \n Forked github link: https://github.com/aurosaint/Rainbow-Tags (This plugin updated by aurosaint.)");
            eventHandlers = new EventHandlers(this);
            Player.ChangingGroup += eventHandlers.OnChangingGroup;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Player.ChangingGroup -= eventHandlers.OnChangingGroup;
            eventHandlers = null;
            base.OnDisabled();
        }
    }
}
