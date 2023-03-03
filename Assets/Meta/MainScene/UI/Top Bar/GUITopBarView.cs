using BT.Core.UI.View;
using BT.Meta.Common.UI.GUITextWithImage;

using UnityEngine;

namespace BT.Meta.MainScene.UI.TopBar
{
    public class GUITopBarView : UIView
    {
        [SerializeField] private GUITextWithImageView _time;
        [SerializeField] private GUITextWithImageView _reputation;
        [SerializeField] private GUITextWithImageView _balance;

        protected override void OnAwake()
        {
#if DEBUG
            Debug.Assert(_time != null);
            Debug.Assert(_reputation != null);
            Debug.Assert(_balance != null);
#endif
        }

        public void ShowTime(string time)
        {
            _time.ShowText(time);
        }

        public void ShowReputation(string reputation)
        {
            _reputation.ShowText(reputation);
        }

        public void ShowBalance(string balance)
        {
            _balance.ShowText(balance);
        }
    }
}