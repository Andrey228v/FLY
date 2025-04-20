using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class PointRepitDetector : MonoBehaviour
    {
        [SerializeField] private Vector3 _startPoint;
        [SerializeField] private Vector3 _repitPoint;

        public event Action ReachedPointRepit;

        public void Update()
        {
            if(transform.position.x > _repitPoint.x)
            {
                ReachedPointRepit?.Invoke();
            }
        }

    }
}
