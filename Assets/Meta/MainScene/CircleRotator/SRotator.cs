
using Leopotam.Ecs;
using UnityEngine;

namespace BT.Meta.MainScene.Objects.Rotator
{
    public class SRotator : IEcsRunSystem
    {
        private EcsFilter<CObject, CRotator> _filter;
        public void Run()
        {
            foreach(var entityId in _filter)
            {
                ref var cObject = ref _filter.Get1(entityId);
                ref var rotator = ref _filter.Get2(entityId);
                cObject.Transform.RotateAround(Vector3.zero, Vector3.forward, rotator.Speed * Time.deltaTime);
            }
        }
    }
}