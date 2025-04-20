using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerMover : MonoBehaviour
    {
        private Transform _startPoint;
        private Transform _repitPoint;

        public event Action ReachedRepitPoin;

        public void SetPoints(Transform startPoint, Transform repitPoint)
        {
            _startPoint = startPoint;
            _repitPoint = repitPoint;

            transform.position = _startPoint.position;
        }

        public void Update()
        {
            if (transform.position.x > _repitPoint.position.x)
            {
                ReachedRepitPoin?.Invoke();
            }
        }
    }
}
