
using System.Diagnostics;
using System;
using Leopotam.Ecs;
using BT.Meta.MainScene.Counter.Balance;
using BT.Meta.Common.UI.GUITextWithImage;

namespace BT.Meta.MainScene.UI.TopBar
{
    public class SGUIBottomBuyBarPresenter : IEcsInitSystem, IEcsDestroySystem
    {
        private GUIBottomBuyBarView _bottomBuyBarView;

        public Action OnBuyOneClicked;
        public Action OnBuyTwoClicked;
        public Action OnBuyThreeClicked;
        int _cats1Count = 0;
        int _cats2Count = 0;
        int _cats3Count = 0;
        EcsWorld _world;
        EcsFilter<CBalance> _balanceFilter;
        public void Init()
        {

            _bottomBuyBarView.Activate();

            OnBuyOneClicked += OnBuyOneClicked;
            OnBuyTwoClicked += OnBuyTwoClicked;
            OnBuyThreeClicked += OnBuyThreeClicked;

            _bottomBuyBarView.Buy1.ShowWithAction(BuyOneClicked);
            _bottomBuyBarView.Buy2.ShowWithAction(BuyTwoClicked);
            _bottomBuyBarView.Buy3.ShowWithAction(BuyThreeClicked);
            
                _bottomBuyBarView.Buy1.ShowText("10");
                _bottomBuyBarView.Buy2.ShowText("50");
                _bottomBuyBarView.Buy3.ShowText("200");
            
        }

        private void BuyCat(ref float catPrice, ref int catCount, GUITextWithImageView buyButton, string resourceName, float radius, int points, int speed)
        {
            foreach (var balanceEntityId in _balanceFilter)
            {
                ref var balance = ref _balanceFilter.Get1(balanceEntityId);
                if (catPrice <= balance.CurrentBalance)
                {
                    var spawnerEntity = _world.NewEntity();
                    ref var spawn = ref spawnerEntity.Get<CSpawnRequest>();
                    spawn.ResourceName = resourceName;
                    spawn.Radius = radius;
                    spawn.Points = points;
                    spawn.Speed = speed;
                    catCount++;
                    buyButton.ShowCountText(catCount.ToString());
                    balance.CurrentBalance -= catPrice;
                    catPrice += MathF.Floor(100 * MathF.Pow(1.2f, catCount));
                    buyButton.ShowText(catPrice.ToString());
                }
            }
        }

        private void BuyOneClicked()
        {
            foreach (var balanceEntityId in _balanceFilter)
            {
                ref var balance = ref _balanceFilter.Get1(balanceEntityId);
                BuyCat(ref balance.Cat1Price, ref _cats1Count, _bottomBuyBarView.Buy1, "Cat1", 1.7f, 1, 40);
            }
        }

        private void BuyTwoClicked()
        {
            foreach (var balanceEntityId in _balanceFilter)
            {
                ref var balance = ref _balanceFilter.Get1(balanceEntityId);
                BuyCat(ref balance.Cat2Price, ref _cats2Count, _bottomBuyBarView.Buy2, "Cat2", 2.2f, 3, 50);
            }
        }

        private void BuyThreeClicked()
        {
            foreach (var balanceEntityId in _balanceFilter)
            {
                ref var balance = ref _balanceFilter.Get1(balanceEntityId);
                BuyCat(ref balance.Cat3Price, ref _cats3Count, _bottomBuyBarView.Buy3, "Cat3", 2.7f, 5, 20);
            }
        }

        public void Destroy()
        {
            OnBuyOneClicked -= OnBuyOneClicked;
            OnBuyTwoClicked -= OnBuyTwoClicked;
            OnBuyThreeClicked -= OnBuyThreeClicked;
        }
    }
}