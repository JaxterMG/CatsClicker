using BT.Meta.Common.Assets.Characters.MainCharacter;
using BT.Meta.Common.InputHandling;
using BT.Meta.Common.UI.GUITextWithImage;
using BT.Meta.Common.UI.Input;
using BT.Meta.MainScene.Objects;
using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.MainScene.Counter
{
    public class SClicksCounter : IEcsRunSystem, IEcsInitSystem, IEcsDestroySystem
    {
        private PanelTouchInputListener _inputListener;
        private  GUITextView _guiTextView;
        private float _taps = 0;
        EcsWorld _world;

        private EcsFilter<CTap> _tapFilter;
        private EcsFilter<CObject> _cObjectFilter;

        public void Destroy()
        {
        }

        public void Init()
        {
            _guiTextView.ShowText(_taps.ToString());
        }

        public void Run()
        {
            foreach(var tapEntityId in _tapFilter)
            {
                ref var cTap = ref _tapFilter.Get1(tapEntityId);
                _taps += 1;
                _guiTextView.ShowText(_taps.ToString());
            }
            foreach(var cObjectEntityId in _cObjectFilter)
            {
                ref var cObject = ref _cObjectFilter.Get1(cObjectEntityId);
                cObject.Timer -= Time.deltaTime;
                if(cObject.Timer <= 0)
                {
                    _taps += cObject.Points;
                    _guiTextView.ShowText(_taps.ToString());
                    cObject.Timer = 1;
                }
                
            }
        }
    }
}