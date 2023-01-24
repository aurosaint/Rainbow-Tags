namespace RainbowTags.API.Extensions
{
    using PluginAPI.Core;
    using System;
    using System.Linq;

    public static class UserGroupExtension
    {
        public static bool TryGetValues(this UserGroup group, out string[] colors)
        {
            if (Plugin.Instance.Config.AllowRanks.TryGetValue(GetGroupKey(group), out string[] Colors))
                colors = Colors;
            else colors = null;

            return colors != null;
        }

        public static string GetGroupKey(UserGroup group)
        {
            try
            {
                if (group == null)
                    return string.Empty;

                return ServerStatic.GetPermissionsHandler()._groups.First(g => EqualsTo(g.Value, group)).Key ??
                       string.Empty;
            }
            catch (Exception e)
            {
                Log.Error("[RainbowTags] [Event: GetGroupKey] " + e.ToString());
                return string.Empty;
            }
        }

        public static bool EqualsTo(UserGroup check, UserGroup player)
            => check.BadgeColor == player.BadgeColor
               && check.BadgeText == player.BadgeText
               && check.Permissions == player.Permissions
               && check.Cover == player.Cover
               && check.HiddenByDefault == player.HiddenByDefault
               && check.Shared == player.Shared
               && check.KickPower == player.KickPower
               && check.RequiredKickPower == player.RequiredKickPower;
    }
}
