using UnityEngine;

namespace Assets.Scripts.Enemys
{
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _maxSpeed;

        private float _speed;
        private Vector3 _moveDirection = Vector3.left;
        
        private void Start()
        {
            _speed = Random.Range(_minSpeed, _maxSpeed);

            Vector3 rotate = transform.eulerAngles;
            rotate.z = 180;
            transform.rotation = Quaternion.Euler(rotate);

        }

        private void Update()
        {
            transform.position += _moveDirection * _speed * Time.deltaTime;                 
        }

    }
}
