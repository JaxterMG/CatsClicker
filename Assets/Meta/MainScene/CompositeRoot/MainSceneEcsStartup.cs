using BT.Core.CompositeRoot;
using BT.Meta.MainScene.MainCamera;
using BT.Meta.MainScene.Objects;
using UnityEngine;

namespace BT.Meta.MainScene.CompositeRoot
{
    public class MainSceneEcsStartup : EcsStartupBase
    {
        [SerializeField] private BassAnalyzer _bassAnalyzer;
        protected override void AddLogicParts()
        {
            var mainSceneEnvironmentStartup =
                new MainSceneEnvironmentStartup();

            var mainSceneUIStartup =
                new MainSceneUIStartup
                (
                    mainSceneEnvironmentStartup.Camera,
                    _bassAnalyzer
                );

            var mainSceneManagersStartup =
                new MainSceneManagersStartup
                (
                    mainSceneUIStartup.PanelTouchInputListener,
                    mainSceneEnvironmentStartup.Camera
                );

            var mainSceneInputHandlingStartup =
                new MainSceneInputHandlingStartup
                    (mainSceneUIStartup.PanelTouchInputListener);

            var mainSceneCamera =
                new MainSceneCameraStartup
                (
                    mainSceneEnvironmentStartup.Camera
                );

            var mainSceneCounterHandlingStartup =
                new MainSceneCounterHandlingStartup
                    (
                        mainSceneUIStartup.PanelTouchInputListener,
                        mainSceneUIStartup.GUIText
                    );
            var mainSceneObjectsStartup =
                new MainSceneObjectsStartup
                (
                    _bassAnalyzer
                );
            mainSceneManagersStartup
                .AddUpdateSystems(_updateSystems)
                .AddFixedUpdateSystems(_fixedUpdateSystems)
                .AddLateUpdateSystems(_lateUpdateSystems);

            mainSceneEnvironmentStartup
                .AddUpdateSystems(_updateSystems);

            mainSceneInputHandlingStartup
                .AddUpdateSystems(_updateSystems);

            mainSceneUIStartup
                .AddUpdateSystems(_updateSystems);
            mainSceneCamera 
                .AddLateUpdateSystems(_lateUpdateSystems);

            mainSceneCounterHandlingStartup
                .AddUpdateSystems(_updateSystems);
            mainSceneObjectsStartup
                .AddUpdateSystems(_updateSystems);
        }
    }
}