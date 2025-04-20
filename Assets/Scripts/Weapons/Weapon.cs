using Assets.Scripts.Bullets;
using Assets.Scripts.Spawners;
using System;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform _pointCreateBullets;
        [SerializeField] private float _cooldownTime;

        private SpawnerBullets _spawnerBullets;
        private bool _isCooldown = true;
        private CooldownTimer _timer;
        private int _cooldownTimeMillisecond;

        public event Action Coldowning;

        private void Awake()
        {
            _spawnerBullets = FindFirstObjectByType<SpawnerBullets>();
            _timer = new CooldownTimer();
            _cooldownTimeMillisecond = Convert.ToInt32(_cooldownTime * 1000);
        }

        public async void Attack(Vector3 direction, IAttack attacker)
        {
            if (_isCooldown)
            {
                _isCooldown = false;
                _spawnerBullets.SpawnerType.SpawnPosition.SetPoinForSpawn(_pointCreateBullets);
                Bullet bullet = _spawnerBullets.SpawnerType.Spawn();
                bullet.SetAttacker(attacker);
                bullet.transform.right = direction;
                _isCooldown = await _timer.Start(_cooldownTimeMillisecond);
                Coldowning?.Invoke();
            }
        }
    }
}
