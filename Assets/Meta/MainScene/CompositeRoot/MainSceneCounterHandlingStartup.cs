using BT.Core.CompositeRoot;
using BT.Meta.Common.InputHandling;
using BT.Meta.Common.UI.GUITextWithImage;
using BT.Meta.Common.UI.Input;
using BT.Meta.MainScene.Counter;
using Leopotam.Ecs;

namespace BT.Meta.MainScene.CompositeRoot
{
    public class MainSceneCounterHandlingStartup :
        IUpdateLogicPartStartup<MainSceneCounterHandlingStartup>
    {
      private readonly PanelTouchInputListener _panelTouchInputListener;
        
     private readonly GUITextView _guiTextView;

        public MainSceneCounterHandlingStartup
            (PanelTouchInputListener panelTouchInputListener, GUITextView textView)
        {
            _panelTouchInputListener = panelTouchInputListener;
            _guiTextView = textView;
        }

        public MainSceneCounterHandlingStartup AddUpdateSystems(EcsSystems systems)
        {
             systems
                .Add(new SClicksCounter())
                .OneFrame<CTap>()
                .Inject(_guiTextView)
                .Inject(_panelTouchInputListener);
            return this;
        }
    }
}