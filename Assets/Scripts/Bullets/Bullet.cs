using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bullets
{
    [RequireComponent(typeof(BulletMover))]
    public class Bullet : MonoBehaviour, ISpawnObject<Bullet>
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _timeLife;

        private IAttack _attacker;

        public event Action<Bullet> DestroedSpawnObject;

        public BulletMover BulletMover { get; private set; }

        private void Awake()
        {
            BulletMover = GetComponent<BulletMover>();
        }

        private void OnEnable()
        {
            StartCoroutine(ExpirationTimeLife());
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.TryGetComponent<ITarget>(out ITarget target))
            {
                Type typeCollision = target.GetType();

                if (_attacker.GetType() != typeCollision)
                {
                    Despawn(); 
                    target.Despawn();
                }
            }
        }

        public void Despawn()
        {
            DestroedSpawnObject?.Invoke(this);
        }

        private IEnumerator ExpirationTimeLife()
        {
            yield return new WaitForSeconds(_timeLife);
            Despawn();
        }

        public void SetAttacker(IAttack attacker)
        {
            _attacker = attacker;
        }
    }
}
