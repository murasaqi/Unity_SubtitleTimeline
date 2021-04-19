using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using SubtitleTimeline;

public class SubtitleTimelineMixerBehaviour : PlayableBehaviour
{
    
    public List<TimelineClip> clips { get; set; }
    public PlayableDirector director { get; set; }
    // NOTE: This function is called at runtime and edit time.  Keep that in mind when setting the values of properties.
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        SubtitleControl trackBinding = playerData as SubtitleControl;

        if (!trackBinding)
            return;

        int inputCount = playable.GetInputCount ();

        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<SubtitleTimelineBehaviour> inputPlayable = (ScriptPlayable<SubtitleTimelineBehaviour>)playable.GetInput(i);
            SubtitleTimelineBehaviour input = inputPlayable.GetBehaviour ();
            var clip = clips[i];
            var clipProgress = Mathf.Min((float) (director.time - clip.start), (float) clip.duration) / (float) clip.duration;
            if (clip.start <= director.time && director.time < clip.start + clip.duration)
            { 
                trackBinding.UpdateSubtitle(clip.displayName);
            }
            // Use the above variables to process each frame of this playable.
            
        }
    }
}
