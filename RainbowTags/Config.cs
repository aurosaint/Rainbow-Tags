namespace RainbowTags
{
    using System.Collections.Generic;
    using System.ComponentModel;

    public class Config
    {
        [Description("Tag and tag colors")]
        public Dictionary<string, string[]> AllowRanks { get; set; } = new Dictionary<string, string[]>()
        {
            { "owner", new string[]
                {
                    "pink",
                    "aqua",
                    "cyan",
                    "blue_green",
                    "mint",
                    "emerald",
                    "light_green",
                    "green",
                    "army_green",
                    "carmine",
                    "brown",
                    "red",
                    "crimson",
                    "tomato",
                    "orange",
                    "lime",
                    "yellow"
                }
            }
        };

        [Description("Color update time? (Do not recommend setting the value to less than 0.5, it may cause server lags)")]
        public float UpdatedTime { get; set; } = 0.5f;
    }
}