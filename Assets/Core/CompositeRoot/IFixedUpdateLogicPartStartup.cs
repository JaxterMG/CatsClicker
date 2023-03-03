using Leopotam.Ecs;

namespace BT.Core.CompositeRoot
{
    public interface IFixedUpdateLogicPartStartup<T> : ILogicPart
        where T : IFixedUpdateLogicPartStartup<T>
    {
        T AddFixedUpdateSystems(EcsSystems systems);
    }
}