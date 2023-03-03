using Leopotam.Ecs;

namespace BT.Core.CompositeRoot
{
    public interface ILateUpdateLogicPartStartup<T> : ILogicPart
        where T : ILateUpdateLogicPartStartup<T>
    {
        T AddLateUpdateSystems(EcsSystems systems);
    }
}