
using BT.Meta.Common.UI.GUITextWithImage;
using Leopotam.Ecs;

namespace BT.Meta.MainScene.UI.TopBar
{
    public class SGUITextPresenter : IEcsInitSystem, IEcsRunSystem
    {
        private GUITextView _textView;

        public void Init()
        {
            _textView.Activate();
        }

        //possible class split, but not necessary
        public void Run()
        {
            
        }
    }
}