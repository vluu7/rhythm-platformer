//----------------------------------------------
//            	   Koreographer                 
//    Copyright © 2014-2017 Sonic Bloom, LLC    
//----------------------------------------------

using UnityEngine;
using HutongGames.PlayMaker;
using Tooltip=HutongGames.PlayMaker.TooltipAttribute;

namespace SonicBloom.Koreo.PlayMaker
{
	[ActionCategory("Koreographer")]
	[Tooltip("Retrieves specific subframe timing information (in seconds) about the Koreography Event currently being processed.")]
	public class GetKoreographyEventTimingOffsets : FsmStateAction
	{
		public enum OffsetStorageMode
		{
			StartOffsetOnly,
			EndOffsetOnly,
			BothOffsets,
		}

		public OffsetStorageMode storageOption = OffsetStorageMode.StartOffsetOnly;

		[UIHint(UIHint.Variable)]
		[Tooltip("The float variable into which to store the Koreography Event's sub-frame start position offset in seconds.  Valid values are in the range [0, deltaTime].  Stores -1 if the Koreography Event's Start Sample was not processed this update.")]
		public FsmFloat storeFloatStartOffset;

		[UIHint(UIHint.Variable)]
		[Tooltip("The float variable into which to store the Koreography Event's sub-frame start position offset in seconds.  Valid values are in the range [0, deltaTime].  Stores -1 if the Koreography Event's End Sample was not processed this update.")]
		public FsmFloat storeFloatEndOffset;

		[Tooltip("Internally, Koreographer uses unscaled time for timing estimation. This is to ensure constant time steps, bypassing Unity's Maximum Allowed Timestep (see Unity's Time Manager) limit. The unscaled time fails when Editor playback is paused and then resumed. As such, this option existst mainly to assist in debugging scenarios.")]
		public bool useUnscaledTime = true;

		public override void OnEnter()
		{
			KoreographyEventInfo info = KoreographyEventInfo.CallbackInfo;

			if (Koreographer.Instance == null)
			{
				LogWarning("No Koreographer component found in the scene!  Did you add a Koreographer component to a GameObject in the scene?");
			}
			else if (info == null)
			{
				LogWarning("No Koreography Event Info available.  This action will only work during a Koreography Event callback phase.");
			}
			else
			{
				KoreographyEvent koreoEvent = info.koreoEvent;

				if (koreoEvent == null)
				{
					LogWarning("No valid Koreography Event found in the Koreography Event Info.  This action will only work during a Koreography Event callback phase.");
				}
				else
				{
					// Get the time of the beginning of this slice as an offset from nowTime.  We will then subtract
					//  off the amount of time from the beginning of the slice this event actually is.
					double deltaOffset = (useUnscaledTime ? Time.unscaledDeltaTime : (Time.deltaTime / Time.timeScale)) * (1f - info.deltaSlice.deltaOffset);

					int sampleRate = Koreographer.Instance.GetMusicSampleRate();

					if (storageOption == OffsetStorageMode.BothOffsets ||
					    storageOption == OffsetStorageMode.StartOffsetOnly)
					{
						//TODO: Check that storeFloatStartOffset is valid before use?

						// Check if the start position happened this update.
						if (koreoEvent.StartSample <= info.sampleTime &&
						    koreoEvent.StartSample >= (info.sampleTime - info.sampleDelta))
						{
							// Find the number of samples into the slice we are.
							double sampleDistIntoSlice = info.sampleDelta - (info.sampleTime - koreoEvent.StartSample);

							// Convert to seconds and then reduce the deltaOffset by this amount!
							storeFloatStartOffset.Value = (float)(deltaOffset - (sampleDistIntoSlice / sampleRate));
						}
						else
						{
							// Set to invalid value if this didn't occur this frame!
							storeFloatStartOffset.Value = -1f;
						}
					}

					if (storageOption == OffsetStorageMode.BothOffsets ||
					    storageOption == OffsetStorageMode.EndOffsetOnly)
					{
						//TODO: Check that storeFloatEndOffset is valid before use?

						// Check if the end position happened this update.
						if (koreoEvent.EndSample <= info.sampleTime &&
					 		koreoEvent.EndSample >= (info.sampleTime - info.sampleDelta))
						{
							// Find the number of samples into the slice we are.
							double sampleDistIntoSlice = info.sampleDelta - (info.sampleTime - koreoEvent.EndSample);

							// Convert to seconds and then reduce the deltaOffset by this amount!
							storeFloatEndOffset.Value = (float)(deltaOffset - (sampleDistIntoSlice / sampleRate));
						}
						else
						{
							// Set to invalid value if this didn't occur this frame!
							storeFloatEndOffset.Value = -1f;
						}
					}
				}
			}

			Finish();
		}
	}
}
