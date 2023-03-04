using BT.Core.UI.View;
using BT.Meta.Common.UI.GUITextWithImage;

using UnityEngine;

namespace BT.Meta.MainScene.UI.TopBar
{
    public class GUIBottomBuyBarView : UIView
    {
        [SerializeField] public GUITextWithImageView Buy1;
        [SerializeField] public GUITextWithImageView Buy2;
        [SerializeField] public GUITextWithImageView Buy3;

        protected override void OnAwake()
        {
#if DEBUG
            Debug.Assert(Buy1 != null);
            Debug.Assert(Buy2 != null);
            Debug.Assert(Buy3 != null);
#endif
        }

        public void ShowCount(GUITextWithImageView element, string count)
        {
            element.ShowText(count);
        }
    }
}