using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI
{
    public class ButtonStart : MonoBehaviour, IPointerDownHandler
    {
        public event Action Clicked;

        public void OnPointerDown(PointerEventData eventData)
        {
            Clicked?.Invoke();
        }
    }
}
