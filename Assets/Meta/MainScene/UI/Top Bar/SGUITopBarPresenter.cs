
using Leopotam.Ecs;

namespace BT.Meta.MainScene.UI.TopBar
{
    public class SGUITopBarPresenter : IEcsInitSystem, IEcsRunSystem
    {
        private GUITopBarView _topBarPresenter;

        public void Init()
        {
            _topBarPresenter.Activate();
        }

        //possible class split, but not necessary
        public void Run()
        {
            
        }
    }
}