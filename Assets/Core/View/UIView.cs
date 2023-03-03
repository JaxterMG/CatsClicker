using UnityEngine;

namespace BT.Core.UI.View
{
    public abstract class UIView : MonoBehaviour
    {
        public Transform Transform { get; private set; }

        public int SiblingIndex => Transform.GetSiblingIndex();

        //TODO: consider more effective way to handle show state
        public bool IsActive => gameObject.activeSelf;
        public bool IsShown => gameObject.activeInHierarchy && IsActive;

        private void Awake()
        {
            Transform = transform;
            OnAwake();
        }

        protected abstract void OnAwake();

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public void SetFirstSibling()
        {
            Transform.SetAsFirstSibling();
        }

        public void SetLastSibling()
        {
            Transform.SetAsLastSibling();
        }

        public void SetSiblingIndex(int index)
        {
            Transform.SetSiblingIndex(index);
        }

        public void SetParent(Transform parent)
        {
            Transform.SetParent(parent);
        }
    }
}