using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.MainScene.MainCamera
{
    public class SMainCameraCreate : IEcsInitSystem
    {
        private EcsWorld _world;
        private Camera _camera;

        public void Init()
        {
            CreateMainCamera();
        }

        private void CreateMainCamera()
        {
            var entity = _world.NewEntity();
            UnityEngine.Debug.Log("CameraCreated");
            ref var camera = ref entity.Get<CMainCamera>();
            camera.Transform = _camera.transform;
            camera.Camera = _camera;
        }
    }
}