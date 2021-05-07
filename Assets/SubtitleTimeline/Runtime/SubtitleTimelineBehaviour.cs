using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using SubtitleTimeline;
using TMPro;
using UnityEngine.UI;

[Serializable]
public class SubtitleTimelineBehaviour : PlayableBehaviour
{
    public Color textColor = Color.white;
    public Color backgroundColor = new Color(0,0,0,0.4f);
    public TMP_FontAsset fontAsset;
    public int fontSizeMin = 10;
    public int fontSizeMax = 30;
    public override void OnPlayableCreate (Playable playable)
    {
        
    }
}
