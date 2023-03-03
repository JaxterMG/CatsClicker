using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.Common.InputHandling
{
    public class SKeyboardInputSender : IEcsRunSystem
    {
        private EcsFilter<CKeyboardInputData> _filter;

        public void Run()
        {
            foreach (var entityId in _filter)
            {
                ref var input = ref _filter.Get1(entityId);

                input.MoveDirection = new Vector3
                (
                    Input.GetAxisRaw("Horizontal"), 0f,
                    Input.GetAxisRaw("Vertical")
                );
            }
        }
    }
}