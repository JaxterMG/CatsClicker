
using BT.Meta.Common.UI.GUITextWithImage;
using Leopotam.Ecs;
using UnityEngine;

namespace BT.Meta.MainScene.UI.TopBar
{
    public class SGUITextPresenter : IEcsInitSystem, IEcsRunSystem
    {
        private GUITextView _textView;
        private BassAnalyzer _bassAnalyzer;

        public float minScale = 1.0f;
        public float maxScale = 1.5f;
        public float smoothing = 3.8f;

        public float CurrentScale = 0;

        public void Init()
        {
            _textView.Activate();
        }

        //possible class split, but not necessary
        public void Run()
        {
            float targetScale = Mathf.Lerp(minScale, maxScale, _bassAnalyzer.bassValue);
            CurrentScale = Mathf.Lerp(CurrentScale, targetScale, Time.deltaTime * smoothing);
            _textView.transform.localScale = new Vector3(CurrentScale, CurrentScale, CurrentScale);

        }
    }
}