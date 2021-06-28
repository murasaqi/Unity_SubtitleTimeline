using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using SubtitleTimeline;
using TMPro;
using UnityEngine.UI;

public class SubtitleTimelineMixerBehaviour : PlayableBehaviour
{
    
    public List<TimelineClip> clips { get; set; }
    public PlayableDirector director { get; set; }

    public TextMeshProUGUI textMeshProUGUI;
    public Image backgroundImage;
    private RectTransform backgroundRect;
    public int maxLineWidth = 1800;
    // NOTE: This function is called at runtime and edit time.  Keep that in mind when setting the values of properties.
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {

        if (!textMeshProUGUI || ! backgroundImage)
            return;

        int inputCount = playable.GetInputCount ();

        ToggleSubtitle(false);
        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<SubtitleTimelineBehaviour> inputPlayable = (ScriptPlayable<SubtitleTimelineBehaviour>)playable.GetInput(i);
            SubtitleTimelineBehaviour input = inputPlayable.GetBehaviour ();
            var clip = clips[i];
            var clipProgress = Mathf.Min((float) (director.time - clip.start), (float) clip.duration) / (float) clip.duration;
            if (clip.start <= director.time && director.time < clip.start + clip.duration)
            {
                ToggleSubtitle(true);
                UpdateSubtitle(clip.displayName,input.textColor,input.backgroundColor);
            }
            // Use the above variables to process each frame of this playable.
            
        }
    }
    
    private void UpdateSubtitle(string text, Color textColor, Color backgroundColor)
    {
        if (!backgroundRect) backgroundRect = backgroundImage.GetComponent<RectTransform>();
        
        textMeshProUGUI.text = text;
        textMeshProUGUI.color = textColor;
        backgroundImage.color = backgroundColor;
        // subtitleTMP.fontSizeMin = fontSizeMin;
        // subtitleTMP.fontSizeMax = fontSizeMax;
        // subtitleTMP.ForceMeshUpdate();
        textMeshProUGUI.rectTransform.sizeDelta =new Vector2(Mathf.Min(textMeshProUGUI.preferredWidth,maxLineWidth), textMeshProUGUI.preferredHeight);
        backgroundRect.sizeDelta = new Vector2(Mathf.Min(textMeshProUGUI.preferredWidth,maxLineWidth), textMeshProUGUI.preferredHeight);
            
    }

    private void ToggleSubtitle(bool isActive)
    {
        textMeshProUGUI.gameObject.SetActive(isActive);
        backgroundImage.gameObject.SetActive(isActive);
    }
}
