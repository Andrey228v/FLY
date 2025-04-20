using UnityEngine;

namespace Assets.Scripts.Bullets
{
    public class BulletMover : MonoBehaviour
    {
        [SerializeField] private int _speed = 2;

        private void Update()
        {
            transform.position += transform.right * _speed * Time.deltaTime;
        }

    }
}
