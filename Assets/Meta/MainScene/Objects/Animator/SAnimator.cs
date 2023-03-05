using BT.Meta.MainScene.Objects;
using Leopotam.Ecs;

namespace BT.Meta.MainScene.Counter
{
    public class SAnimator : IEcsRunSystem
    {
        private EcsFilter<CObject> _cObjectFilter;
        private BassAnalyzer _bassAnalyzer;
        //private float _cooldown = 0f;
       
        public void Run()
        {
            foreach(var entityId in _cObjectFilter)
            {
                ref var cObject = ref _cObjectFilter.Get1(entityId);
                if(_bassAnalyzer.bassValue >= 1f)
                {
                    cObject.Animator.Play("Flex");
                }
            }
            
        }
    }
}