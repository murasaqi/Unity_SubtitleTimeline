using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SubtitleTimeline
{

    public class SubtitleControl : MonoBehaviour
    {
        [SerializeField] private Image backgroundUI;
        [SerializeField] private TextMeshProUGUI subtitleTMP;
        [SerializeField] private int maxLineWidth = 1800;
        [SerializeField] private int maxLineHeight = 100;
        public int fontSizeMin = 10;
        public int fontSizeMax = 30;

        public bool enable
        {
            set
            {
                if (backgroundUI != null) backgroundUI.enabled = value;
                if(subtitleTMP != null)subtitleTMP.enabled = value;
            }
        }

        public TextMeshProUGUI textMeshProUGUI
        {
            set
            {
                subtitleTMP = value;
            }
        }
        
        public Image backgroundImage 
        {
            set
            {
                if(backgroundUI)backgroundUI = value;
            }
        }

        public TMP_FontAsset fontAsset
        {
            set
            {
                if(subtitleTMP)subtitleTMP.font = value;
            }
        }
        public Color textColor
        {
            set
            {
                if(subtitleTMP)subtitleTMP.color = value;
            }
        }

        public Color backgroundColor
        {
            set
            {
                if(backgroundUI)backgroundUI.color = value;
            }
        }
        // Start is called before the first frame update
        void Start()
        {

        }
        
        // public TextMeshPro

        public void UpdateSubtitle(string text)
        {

            if (backgroundUI && subtitleTMP)
            {
                subtitleTMP.text = text;
                subtitleTMP.enableAutoSizing = true;
                subtitleTMP.fontSizeMin = fontSizeMin;
                subtitleTMP.fontSizeMax = fontSizeMax;
                subtitleTMP.ForceMeshUpdate(true,true);
                // subtitleTMP.ForceMeshUpdate();
                subtitleTMP.rectTransform.sizeDelta =new Vector2(Mathf.Min(subtitleTMP.preferredWidth,maxLineWidth), Mathf.Min(subtitleTMP.preferredHeight,maxLineHeight));
                backgroundUI.rectTransform.sizeDelta = new Vector2(subtitleTMP.rectTransform.sizeDelta.x, subtitleTMP.rectTransform.sizeDelta.y);

                backgroundUI.rectTransform.position = subtitleTMP.rectTransform.position;
    
            }
            
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
