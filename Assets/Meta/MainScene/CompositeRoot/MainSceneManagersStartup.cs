using BT.Core.CompositeRoot;
using BT.Meta.Common.UI.Input;
using BT.Meta.MainScene.CameraLogic;
using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.MainScene.CompositeRoot
{
    public class MainSceneManagersStartup :
        IUpdateLogicPartStartup<MainSceneManagersStartup>,
        IFixedUpdateLogicPartStartup<MainSceneManagersStartup>,
        ILateUpdateLogicPartStartup<MainSceneManagersStartup>
    {
        private readonly Camera _camera;
        private readonly PanelTouchInputListener _panelTouchInputListener;

        public MainSceneManagersStartup
            (PanelTouchInputListener panelTouchInputListener, Camera camera)
        {
            _panelTouchInputListener = panelTouchInputListener;
            _camera = camera;
        }

        public MainSceneManagersStartup AddFixedUpdateSystems
            (EcsSystems systems)
        {
            return this;
        }

        public MainSceneManagersStartup AddLateUpdateSystems(EcsSystems systems)
        {
            systems
                .Add(new SCameraMovement())
                .Inject(_camera)
                .Inject(_panelTouchInputListener);
            return this;
        }

        public MainSceneManagersStartup AddUpdateSystems(EcsSystems systems)
        {
            //systems
            return this;
        }
    }
}