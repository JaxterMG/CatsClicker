using BT.Core.CompositeRoot;
using BT.Meta.Common.InputHandling;
using BT.Meta.Common.UI.Input;

using Leopotam.Ecs;
namespace BT.Meta.MainScene.CompositeRoot
{
    public class MainSceneInputHandlingStartup :
        IUpdateLogicPartStartup<MainSceneInputHandlingStartup>
    {
        private readonly PanelTouchInputListener _panelTouchInputListener;

        public MainSceneInputHandlingStartup
            (PanelTouchInputListener panelTouchInputListener)
        {
            _panelTouchInputListener = panelTouchInputListener;
        }

        public MainSceneInputHandlingStartup AddUpdateSystems
            (EcsSystems systems)
        {
            systems
                .Add(new STouchInputSender())
                //.Add(new SKeyboardInputSender())
                .Inject(_panelTouchInputListener);
            return this;
        }
    }
}