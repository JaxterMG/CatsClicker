using Leopotam.Ecs;

using UnityEngine;

namespace BT.Core.CompositeRoot
{
    public abstract class EcsStartupBase : MonoBehaviour
    {
        protected EcsSystems _fixedUpdateSystems;
        protected EcsSystems _lateUpdateSystems;
        protected EcsSystems _updateSystems;
        protected EcsWorld _world;

        private void Awake()
        {
            _world = new EcsWorld();
            _updateSystems = new EcsSystems(_world);
            _fixedUpdateSystems = new EcsSystems(_world);
            _lateUpdateSystems = new EcsSystems(_world);

            OnAwake();
            AddLogicParts();

            _updateSystems?.Init();
            _fixedUpdateSystems?.Init();
            _lateUpdateSystems?.Init();
        }

        private void Update()
        {
            _updateSystems?.Run();
            OnUpdate();
        }

        private void FixedUpdate()
        {
            _fixedUpdateSystems?.Run();
            OnFixedUpdate();
        }

        private void LateUpdate()
        {
            _lateUpdateSystems?.Run();
            OnLateUpdate();
        }

        private void OnDestroy()
        {
            OnPreDestroy();

            _updateSystems?.Destroy();
            _fixedUpdateSystems?.Destroy();
            _lateUpdateSystems?.Destroy();
            _world?.Destroy();

            _updateSystems = null;
            _fixedUpdateSystems = null;
            _lateUpdateSystems = null;
            _world = null;

            OnPostDestroy();
        }

        protected virtual void OnAwake() { }

        protected virtual void AddLogicParts() { }

        protected virtual void OnUpdate() { }

        protected virtual void OnFixedUpdate() { }

        protected virtual void OnLateUpdate() { }

        protected virtual void OnPreDestroy() { }

        protected virtual void OnPostDestroy() { }
    }
}