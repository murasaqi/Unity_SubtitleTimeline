using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using SubtitleTimeline;

[Serializable]
public class SubtitleTimelineBehaviour : PlayableBehaviour
{
    public Color textColor;
    public Color backgroundColor;

    public override void OnPlayableCreate (Playable playable)
    {
        
    }
}
