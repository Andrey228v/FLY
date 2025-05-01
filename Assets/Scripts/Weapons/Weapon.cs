using Assets.Scripts.Bullets;
using Assets.Scripts.Spawners;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform _pointCreateBullets;
        [SerializeField] private float _cooldownTime;

        private SpawnerBullets _spawnerBullets;
        private WaitForSeconds _sleepTime;

        public event Action Coldowning;

        private void Awake()
        {
            _sleepTime = new WaitForSeconds(_cooldownTime);
        }

        public void Attack(Vector3 direction, IAttacker attacker)
        {
            Bullet bullet = _spawnerBullets.SpawnerType.Spawn();
            bullet.transform.position = _pointCreateBullets.position;
            bullet.SetAttacker(attacker);
            bullet.transform.right = direction;

            StartCoroutine(Reload());
        }

        public void SetSpawnerBullets(SpawnerBullets spawnerBullets)
        {
            _spawnerBullets = spawnerBullets;
        }

        private IEnumerator Reload()
        {
            yield return _sleepTime;
            Coldowning?.Invoke();
        }
    }
}
