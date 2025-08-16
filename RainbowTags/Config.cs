using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Features;
using Exiled.API.Interfaces;

namespace RainbowTags
{
    public sealed class Config : IConfig
    {
        [Description("Determines whether the plugin is enabled or not.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Enable debug logging for this plugin.")]
        public bool Debug { get; set; } = false;

        [Description("The time, in seconds, between switching to the next color in a sequence.")]
        public float TagInterval
        {
            get => tagInterval;
            set
            {
                if (value < 0.5f)
                {
                    Log.Warn("The TagInterval config cannot be set below 0.5 and has been automatically clamped.");
                    tagInterval = 0.5f;
                }
                else
                {
                    tagInterval = value;
                }
            }
        }

        public Dictionary<string, string[]> Sequences { get; set; } = new Dictionary<string, string[]>
        {
            { "owner", new[] { "red", "orange", "yellow", "green", "blue_green", "magenta" } },
            { "admin", new[] { "green", "silver", "crimson" } }
        };

        private float tagInterval = 0.5f;

    }
}
