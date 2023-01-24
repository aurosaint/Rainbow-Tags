namespace RainbowTags
{
    using MEC;
    using PluginAPI.Core;
    using PluginAPI.Core.Attributes;
    using PluginAPI.Enums;
    using RainbowTags.API.Extensions;
    using System;
    using UnityEngine;

    public class EventHandlers
    {
        [PluginEvent(ServerEventType.PlayerGetGroup)]
        public void OnPlayerGetGroup(string userID, UserGroup group)
        {
            if (string.IsNullOrEmpty(userID) || group == null) return;

            Timing.CallDelayed(0.1f, () => {
                try
                {
                    Player player = Player.Get(userID);

                    if (player == null) return;

                    if (group.TryGetValues(out string[] Colors))
                    {
                        if (player.GameObject.TryGetComponent<RainbowTagController>(out RainbowTagController rainbowTag))
                        {
                            rainbowTag.Colors = Colors;
                            return;
                        }

                        player.GameObject.AddComponent<RainbowTagController>().Colors = Colors;
                    }
                    else if (player.GameObject.TryGetComponent<RainbowTagController>(out RainbowTagController rainbowTag))
                    {
                        GameObject.Destroy(rainbowTag);
                    }
                }
                catch (Exception e)
                {
                    Log.Error("[RainbowTags] [Event: OnPlayerGetGroup] " + e.ToString());
                }
            });
        }

        
    }
}
