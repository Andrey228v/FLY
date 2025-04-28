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

        private IAttacker _attacker;
        private WaitForSeconds _sleepTime;

        public event Action<Bullet> DestroedSpawnObject;

        public BulletMover BulletMover { get; private set; }

        private void Awake()
        {
            BulletMover = GetComponent<BulletMover>();
            _sleepTime = new WaitForSeconds(_timeLife);
        }

        private void OnEnable()
        {
            StartCoroutine(ExpirationTimeLife());
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.TryGetComponent<IDead>(out IDead target))
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
            yield return _sleepTime;
            Despawn();
        }

        public void SetAttacker(IAttacker attacker)
        {
            _attacker = attacker;
        }
    }
}
