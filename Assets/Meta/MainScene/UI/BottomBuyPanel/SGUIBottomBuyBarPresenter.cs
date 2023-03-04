
using System.Diagnostics;
using System;
using Leopotam.Ecs;

namespace BT.Meta.MainScene.UI.TopBar
{
    public class SGUIBottomBuyBarPresenter : IEcsInitSystem, IEcsDestroySystem
    {
        private GUIBottomBuyBarView _bottomBuyBarView;

        public Action OnBuyOneClicked;
        public Action OnBuyTwoClicked;
        public Action OnBuyThreeClicked;
        EcsWorld _world;
        public void Init()
        {
            
            _bottomBuyBarView.Activate();

            OnBuyOneClicked += OnBuyOneClicked;
            OnBuyTwoClicked += OnBuyTwoClicked;
            OnBuyThreeClicked += OnBuyThreeClicked;

            _bottomBuyBarView.Buy1.ShowWithAction(BuyOneClicked);
            _bottomBuyBarView.Buy2.ShowWithAction(BuyTwoClicked);
            _bottomBuyBarView.Buy3.ShowWithAction(BuyThreeClicked);
        }

        private void BuyOneClicked()
        {
            var spawnerEntity = _world.NewEntity();
            var spawn = spawnerEntity.Get<CSpawnRequest>();
            spawn.ResourceName = "Cat";

        }
        private void BuyTwoClicked()
        {
            UnityEngine.Debug.Log("2");
        }
        private void BuyThreeClicked()
        {
            UnityEngine.Debug.Log("3");
        }

        public void Destroy()
        {
            OnBuyOneClicked -= OnBuyOneClicked;
            OnBuyTwoClicked -= OnBuyTwoClicked;
            OnBuyThreeClicked -= OnBuyThreeClicked;
        }
    }
}