using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using TMPro;
using UnityEngine.UI;

[TrackColor(0.3788042f, 0.8018868f, 0.2622522f)]
[TrackClipType(typeof(SubtitleTimelineClip))]
// [TrackBindingType(typeof(SubtitleControl))]
public class SubtitleTimelineTrack : TrackAsset
{

    [SerializeField]private ExposedReference<Image> backgroundImageReference;
    [SerializeField]private ExposedReference<TextMeshProUGUI> textMeshProUGUIReference;

    public int maxLineWidth = 1800;

    private SubtitleTimelineMixerBehaviour mixerBehaviour;
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        var mixer = ScriptPlayable<SubtitleTimelineMixerBehaviour>.Create (graph, inputCount);
        mixerBehaviour = mixer.GetBehaviour();
        mixerBehaviour.clips = GetClips().ToList();
        mixerBehaviour.director = go.GetComponent<PlayableDirector>();
        mixerBehaviour.maxLineWidth = maxLineWidth;
        mixerBehaviour.backgroundImage = backgroundImageReference.Resolve(graph.GetResolver());
        mixerBehaviour.textMeshProUGUI = textMeshProUGUIReference.Resolve(graph.GetResolver());
        return mixer;
    }

    public void OnValidate()
    {
        // if (mixerBehaviour != null)
        // {
        //     mixerBehaviour.maxLineWidth = maxLineWidth;
        // }
        // throw new NotImplementedException();
        
    }
}
