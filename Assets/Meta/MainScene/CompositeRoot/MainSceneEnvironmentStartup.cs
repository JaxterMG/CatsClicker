using BT.Core.CompositeRoot;
using BT.Meta.Common.UI.Input;
using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.MainScene.CompositeRoot
{
    public class
        MainSceneEnvironmentStartup :
            IUpdateLogicPartStartup<MainSceneEnvironmentStartup>
    {
        public readonly Camera Camera;
        public readonly Grid Grid;

        public MainSceneEnvironmentStartup()
        {
            Camera = Camera.main;
        }

        public MainSceneEnvironmentStartup AddUpdateSystems(EcsSystems systems)
        {
            
            // systems
               
            //     .Inject(Mask)

            // new MainSceneMetricsStartup()
            //     .AddUpdateSystems(systems);

            return this;
        }
    }
}