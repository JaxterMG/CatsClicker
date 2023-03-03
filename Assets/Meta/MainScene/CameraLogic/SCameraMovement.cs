using BT.Meta.Common.UI.Input;

using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.MainScene.CameraLogic
{
    public class SCameraMovement : IEcsInitSystem, IEcsDestroySystem
    {
        private const float CAMERA_SPEED_MULTIPLYER = 0.1f;
        private Camera _camera;

        private Transform _cameraTransform;
        private PanelTouchInputListener _inputListener;

        public void Destroy()
        {
            if (_inputListener != null) _inputListener.OnDragEvent += CameraMovement;
        }

        public void Init()
        {
            _cameraTransform = _camera.transform;
            if (_inputListener != null) _inputListener.OnDragEvent += CameraMovement;
        }

        private void CameraMovement(Vector2 delta)
        {
            delta *= CAMERA_SPEED_MULTIPLYER;

            var cameraPosition = _cameraTransform.position;
            cameraPosition.x += delta.x;
            cameraPosition.z += delta.y;
            _cameraTransform.position = cameraPosition;
        }
    }
}