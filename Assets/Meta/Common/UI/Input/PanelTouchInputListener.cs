using System;

using BT.Core.Utils;

using UnityEngine;
using UnityEngine.EventSystems;

namespace BT.Meta.Common.UI.Input
{
    public class PanelTouchInputListener : MonoBehaviour, IDragHandler,
        IEndDragHandler, IPointerClickHandler, IPointerMoveHandler
    {
        [SerializeField] private float _clickInterval = 0.5f;
        private float _lastClickTime;

        public void OnDrag(PointerEventData eventData)
        {
            OnDragEvent?.Invoke(eventData.delta);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            OnEndDragEvent?.Invoke();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClickEvent?.Invoke(eventData.position);
            if (Time.time - _lastClickTime <= _clickInterval)
            {
                OnDoubleClickEvent?.Invoke(eventData.position);
            }

            _lastClickTime = Time.time;
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            OnPointerMoveEvent?.Invoke(eventData.position);
        }

        public event Action<Vector2> OnClickEvent;
        public event Action<Vector2> OnDoubleClickEvent;
        public event Action<Vector2> OnDragEvent;
        public event Action<Vector2> OnPointerMoveEvent;

        public event Action OnEndDragEvent;
    }
}