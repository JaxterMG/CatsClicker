using BT.Core.CompositeRoot;

using Leopotam.Ecs;

namespace BT.Meta.MainScene.CompositeRoot
{
    public class
        MainSceneMetricsStartup : IUpdateLogicPartStartup<
            MainSceneMetricsStartup>
    {
        public MainSceneMetricsStartup AddUpdateSystems(EcsSystems systems)
        {
            
            return this;
        }
    }
}