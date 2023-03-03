using BT.Core.CompositeRoot;

using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.MainScene.MainCamera
{
    public class MainSceneCameraStartup :
        ILateUpdateLogicPartStartup<MainSceneCameraStartup>
    {
        private readonly Camera _camera;
        public MainSceneCameraStartup
            (Camera camera)
        {
            _camera = camera;
        }

        public MainSceneCameraStartup AddLateUpdateSystems(EcsSystems systems)
        {
            systems
                .Add(new SMainCameraCreate())
                .Inject(_camera);
            return this;
        }
    }
}