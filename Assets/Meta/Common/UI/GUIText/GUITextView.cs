using System;
using BT.Core.UI.View;
using BT.Core.Utils;

using UnityEngine;
using UnityEngine.UI;

namespace BT.Meta.Common.UI.GUITextWithImage
{
    public class GUITextView : UIView
    {
        [SerializeField] private Text _text;

        public void AddInputListener()
        {
           
        }

        public void RemoceInputListener()
        {
            
        }

        public void ShowText(string text)
        {
            _text.text = text;
        }

        protected override void OnAwake()
        {
           
        }
    }
}