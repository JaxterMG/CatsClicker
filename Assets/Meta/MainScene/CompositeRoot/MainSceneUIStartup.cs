using BT.Core.CompositeRoot;
using BT.Meta.Common.UI.GUITextWithImage;
using BT.Meta.Common.UI.Input;
using BT.Meta.MainScene.UI.TopBar;

using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.MainScene.CompositeRoot
{
    public class
        MainSceneUIStartup : IUpdateLogicPartStartup<MainSceneUIStartup>
    {
        private readonly Camera _camera;
        public GUITextView GUIText;
        public readonly PanelTouchInputListener PanelTouchInputListener;
        public readonly Canvas UI;

        public MainSceneUIStartup(Camera camera)
        {
            _camera = camera;
            UI = Object.Instantiate(Resources.Load<Canvas>("Canvas"));
            PanelTouchInputListener =
                UI.GetComponentInChildren<PanelTouchInputListener>();
            GUIText = UI.GetComponentInChildren<GUITextView>();
        }

        public MainSceneUIStartup AddUpdateSystems(EcsSystems systems)
        {
            systems
                .Add(new SGUITextPresenter())
                .Inject(PanelTouchInputListener.GetComponent<RectTransform>())
                .Inject(GUIText)
                .Inject(_camera);
            return this;
        }
    }
}