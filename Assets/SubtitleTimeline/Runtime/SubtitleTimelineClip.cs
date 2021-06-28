using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using SubtitleTimeline;

[Serializable]
public class SubtitleTimelineClip : PlayableAsset, ITimelineClipAsset
{
    public SubtitleTimelineBehaviour template = new SubtitleTimelineBehaviour ();
    // const double DefaultDuration = 1.0f;
    public ClipCaps clipCaps
    {
        get { return ClipCaps.None; }
    }
    // public override double duration
    // {
    //     get { return DefaultDuration; }
    // }

    
    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<SubtitleTimelineBehaviour>.Create (graph, template);
        SubtitleTimelineBehaviour clone = playable.GetBehaviour ();
        
        return playable;
        
        
    }
    
}
