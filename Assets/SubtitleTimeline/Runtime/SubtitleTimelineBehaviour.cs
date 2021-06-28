using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using SubtitleTimeline;

[Serializable]
public class SubtitleTimelineBehaviour : PlayableBehaviour
{
    public Color textColor = Color.white;
    public Color backgroundColor = new Color(0,0,0,0.8f);

    public override void OnPlayableCreate (Playable playable)
    {
        
    }
}
