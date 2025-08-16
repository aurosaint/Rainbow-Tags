using System;
using System.Collections.Generic;
using Exiled.API.Features;
using MEC;
using UnityEngine;
using Object = UnityEngine.Object;

namespace RainbowTags.Components
{
	public sealed class RainbowTagController : MonoBehaviour
	{
		public string[] Colors
		{
			get
			{
				return this.colors;
			}
			set
			{
				this.colors = (value ?? Array.Empty<string>());
				this.position = 0;
			}
		}

		public float Interval
		{
			get
			{
				return this.interval;
			}
			set
			{
				this.interval = value;
				this.intervalInFrames = value * 50f;
			}
		}
		
		private void Awake()
		{
			this.player = Player.Get(base.gameObject);
		}
		
		private void Start()
		{
			this.coroutineHandle = Timing.RunCoroutine(MECExtensionMethods2.CancelWith<RainbowTagController>(MECExtensionMethods2.CancelWith(this.UpdateColor(), this.player.GameObject), this));
		}
		
		private void OnDestroy()
		{
			Timing.KillCoroutines(new CoroutineHandle[]
			{
				this.coroutineHandle
			});
		}
		
		private string RollNext()
		{
			int num = this.position + 1;
			this.position = num;
			if (num >= this.colors.Length)
			{
				this.position = 0;
			}
			if (this.colors.Length == 0)
			{
				return string.Empty;
			}
			return this.colors[this.position];
		}

		private IEnumerator<float> UpdateColor()
		{
			for (;;)
			{
				int z = 0;
				while ((float)z < this.intervalInFrames)
				{
					yield return 0f;
					int num = z;
					z = num + 1;
				}
				string text = this.RollNext();
				if (string.IsNullOrEmpty(text))
				{
					break;
				}
				this.player.RankColor = text;
			}
			Object.Destroy(this);
			yield break;
		}
		
		private Player player;
		
		private int position;
		
		private float interval;

		private float intervalInFrames;

		private string[] colors;

		private CoroutineHandle coroutineHandle;
	}
}
