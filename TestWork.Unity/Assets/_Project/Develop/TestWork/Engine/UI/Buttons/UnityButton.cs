using System;
using UnityEngine;
using UnityEngine.UI;

namespace TestWork.Engine.UI
{
    [RequireComponent(typeof(Button))]
    public sealed class UnityButton : MonoBehaviour, IUnityButton
    {
        private IButton _button;
        private Button _origin;

        private void Awake() =>
            _origin ??= GetComponent<Button>();

        public void Subscribe(IButton button)
        {
            // ?? if Subscribe will be call before the Awake method
            _origin ??= GetComponent<Button>();
            _button = button ?? throw new ArgumentNullException(nameof(button));
            _origin.onClick.AddListener(button.Press);
        }

        private void OnDestroy() =>
            _origin.onClick.RemoveListener(_button.Press);
    }
}