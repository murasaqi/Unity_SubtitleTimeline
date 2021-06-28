using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SubtitleTimeline
{

    public class SubtitleControl : MonoBehaviour
    {
        [SerializeField] private RectTransform background;
        [SerializeField] private TextMeshProUGUI subtitleTMP;
        [SerializeField] private int maxLineWidth = 1800;
        // public int fontSizeMin = 10;
        // public int fontSizeMax = 30;
        private Image _image;
        public string text => subtitleTMP.text;
        // Start is called before the first frame update
        void Start()
        {

        }

        public void UpdateSubtitle(string text, Color textColor, Color backgroundColor)
        {
            if (_image == null)
            {
                var image = background.GetComponent<Image>();
                if (!image)
                {
                    _image= background.gameObject.AddComponent<Image>();
                }
                else
                {
                    _image = image;
                }
            }
            subtitleTMP.text = text;
            subtitleTMP.color = textColor;
            _image.color = backgroundColor;
            // subtitleTMP.fontSizeMin = fontSizeMin;
            // subtitleTMP.fontSizeMax = fontSizeMax;
            // subtitleTMP.ForceMeshUpdate();
            subtitleTMP.rectTransform.sizeDelta =new Vector2(Mathf.Min(subtitleTMP.preferredWidth,maxLineWidth), subtitleTMP.preferredHeight);
            background.sizeDelta = new Vector2(Mathf.Min(subtitleTMP.preferredWidth,maxLineWidth), subtitleTMP.preferredHeight);
            
        }

        public void DisableSubtitle()
        {
            background.gameObject.SetActive(false);
            subtitleTMP.gameObject.SetActive(false);
        }

        public void EnableSubtitle()
        {
            background.gameObject.SetActive(true);
            subtitleTMP.gameObject.SetActive(true);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
