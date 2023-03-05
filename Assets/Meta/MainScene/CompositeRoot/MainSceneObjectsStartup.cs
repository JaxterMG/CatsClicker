using BT.Core.CompositeRoot;
using BT.Meta.MainScene.Counter;
using BT.Meta.MainScene.Objects.Rotator;
using BT.Meta.MainScene.UI;
using BT.Meta.MainScene.UI.TopBar;
using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.MainScene.Objects
{
    public class MainSceneObjectsStartup :
        IUpdateLogicPartStartup<MainSceneObjectsStartup>
    {
        private readonly Camera _camera;
        private BassAnalyzer _bassAnalyzer;
        public MainSceneObjectsStartup(BassAnalyzer bassAnalyzer)
        {
            _bassAnalyzer = bassAnalyzer;
        }

        public MainSceneObjectsStartup AddUpdateSystems(EcsSystems systems)
        {
            systems
                .Add(new SObjectsCreator())
                .Add(new SRotator())
                .Add(new SAnimator())
                .Inject(_bassAnalyzer)
                .OneFrame<CSpawnRequest>();
            return this;
        }
    }
}