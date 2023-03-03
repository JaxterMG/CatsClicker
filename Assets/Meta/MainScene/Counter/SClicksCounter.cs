using BT.Meta.Common.Assets.Characters.MainCharacter;
using BT.Meta.Common.InputHandling;
using BT.Meta.Common.UI.GUITextWithImage;
using BT.Meta.Common.UI.Input;

using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.MainScene.Counter
{
    public class SClicksCounter : IEcsRunSystem, IEcsInitSystem, IEcsDestroySystem
    {
        private PanelTouchInputListener _inputListener;
        private  GUITextView _guiTextView;
        private int _taps = 0;
        EcsWorld _world;

        private EcsFilter<CTap> _tapFilter;

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
                ref var tapEntity = ref _tapFilter.GetEntity(tapEntityId);
                ref var cTap = ref _tapFilter.Get1(tapEntityId);
                _taps += 1;
                _guiTextView.ShowText(_taps.ToString());
            }
        }
    }
}