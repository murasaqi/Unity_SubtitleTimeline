using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using SubtitleTimeline;

[TrackColor(0.3788042f, 0.8018868f, 0.2622522f)]
[TrackClipType(typeof(SubtitleTimelineClip))]
[TrackBindingType(typeof(SubtitleControl))]
public class SubtitleTimelineTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        var mixer = ScriptPlayable<SubtitleTimelineMixerBehaviour>.Create (graph, inputCount);
        mixer.GetBehaviour().clips = GetClips().ToList();
        mixer.GetBehaviour().director = go.GetComponent<PlayableDirector>();
        return mixer;
    }
}
