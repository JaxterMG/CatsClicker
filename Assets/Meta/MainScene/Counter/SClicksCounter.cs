using BT.Meta.Common.Assets.Characters.MainCharacter;
using BT.Meta.Common.InputHandling;
using BT.Meta.Common.UI.GUITextWithImage;
using BT.Meta.Common.UI.Input;
using BT.Meta.MainScene.Counter.Balance;
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
        private EcsFilter<CBalance> _balanceFilter;
        

        public void Destroy()
        {
        }

        public void Init()
        {
            var balanceEntity = _world.NewEntity();
            ref var cBalance = ref balanceEntity.Get<CBalance>();
            cBalance.Cat1Price = 10;
            cBalance.Cat2Price = 50;
            cBalance.Cat3Price = 200;
            cBalance.CurrentBalance = _taps;
            _guiTextView.ShowText(_taps.ToString());
        }

        public void Run()
        { 
            foreach(var balanceEntityId in _balanceFilter)
            {
                ref var cBalance = ref _balanceFilter.Get1(balanceEntityId);
                foreach(var tapEntityId in _tapFilter)
                {
                    ref var cTap = ref _tapFilter.Get1(tapEntityId);
                    cBalance.CurrentBalance += 1;
                    _guiTextView.ShowText(cBalance.CurrentBalance.ToString());
                }
                foreach(var cObjectEntityId in _cObjectFilter)
                {
                    ref var cObject = ref _cObjectFilter.Get1(cObjectEntityId);
                    cObject.Timer -= Time.deltaTime;
                    if(cObject.Timer <= 0)
                    {
                        cBalance.CurrentBalance += cObject.Points;
                        _guiTextView.ShowText(cBalance.CurrentBalance.ToString());
                        cObject.Timer = 1;
                    }
                    
                }
            }
        }
    }
}