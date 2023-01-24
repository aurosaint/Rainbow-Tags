namespace RainbowTags
{
    using MEC;
    using PluginAPI.Core;
    using System.Collections.Generic;
    using UnityEngine;

    public class RainbowTagController : MonoBehaviour
    {
        public Player Player;
        public string[] Colors;
        public string CurColor;
        public CoroutineHandle RaindowCoroutine;

        private int _curColorCount;

        public void Awake()
        {
            Player = Player.Get(gameObject);
        }

        public void Start()
        {
            RaindowCoroutine = Timing.RunCoroutine(RainbowTag());
        }

        public void OnDestroy()
        {
            Timing.KillCoroutines(RaindowCoroutine);
        }

        private void UpdateColor()
        {
            if (Colors.Length <= 0)
            {
                CurColor = string.Empty;
                return;
            }

            if (++_curColorCount >= Colors.Length) _curColorCount = 0;

            CurColor = Colors[_curColorCount];
        }

        private IEnumerator<float> RainbowTag()
        {
            while (true)
            {
                UpdateColor();

                Player.ReferenceHub.serverRoles.SetColor(CurColor);

                yield return Timing.WaitForSeconds(Plugin.Instance.Config.UpdatedTime);
            }
        }
    }
}
