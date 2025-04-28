using System;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Collider2D))]
    public class GroundDetecter : MonoBehaviour
    {
        public event Action CollisedWithGround;
        
        public bool IsCollisionWithGround { get; private set; } = false;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.TryGetComponent(out Ground ground))
            {
                IsCollisionWithGround = true;
                CollisedWithGround?.Invoke();
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            IsCollisionWithGround = false;
        }
    }
}
