using System;
using Exiled.API.Extensions;
using Exiled.Events.EventArgs.Player;
using RainbowTags;
using RainbowTags.Components;
using UnityEngine;

namespace RainbowTags
{
    public class EventHandlers
    {
        private readonly Plugin plugin;

        public EventHandlers(Plugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnChangingGroup(ChangingGroupEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            string groupKey = ev.NewGroup != null ? ev.NewGroup.GetKey() : null;

            if (ev.NewGroup != null && ev.Player.Group == null && TryGetColors(groupKey, out var colors))
            {
                var controller = ev.Player.GameObject.AddComponent<RainbowTagController>();
                controller.Colors = colors;
                controller.Interval = plugin.Config.TagInterval;
                return;
            }

            if (ev.Player.GameObject.TryGetComponent(out RainbowTagController existingController))
            {
                if (TryGetColors(groupKey, out var newColors))
                {
                    existingController.Colors = newColors;
                }
                else
                {
                    UnityEngine.Object.Destroy(existingController);
                }
            }
        }

        private bool TryGetColors(string rank, out string[] availableColors)
        {
            availableColors = null;
            return !string.IsNullOrEmpty(rank) && plugin.Config.Sequences.TryGetValue(rank, out availableColors);
        }
    }
}
