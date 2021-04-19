using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SubtitleTimeline
{

    public class SubtitleControl : MonoBehaviour
    {
        [SerializeField] private RectTransform background;
        [SerializeField] private TextMeshProUGUI subtitleTMP;
        [SerializeField] private int maxLineWidth = 1800;
        public int fontSizeMin = 10;
        public int fontSizeMax = 30;
        public string text => subtitleTMP.text;
        // Start is called before the first frame update
        void Start()
        {

        }

        public void UpdateSubtitle(string text)
        {
            subtitleTMP.text = text;
            subtitleTMP.fontSizeMin = fontSizeMin;
            subtitleTMP.fontSizeMax = fontSizeMax;
            // subtitleTMP.ForceMeshUpdate();
            subtitleTMP.rectTransform.sizeDelta =new Vector2(Mathf.Min(subtitleTMP.preferredWidth,maxLineWidth), subtitleTMP.preferredHeight);
            background.sizeDelta = new Vector2(Mathf.Min(subtitleTMP.preferredWidth,maxLineWidth), subtitleTMP.preferredHeight);
            
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
