using Assets.Scripts.Enemys;
using Assets.Scripts.Spawners.ObjectsPools;
using Assets.Scripts.Spawners.SpawnerType;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Spawners
{
    [RequireComponent(typeof(ISpawnerType<Enemy>), typeof(ObjectPoolPrefab<Enemy>))]
    public class SpawnerEnemys : Spawner<Enemy>
    {
        [Min(0.1f)][SerializeField] private float _timeSpawn = 0.5f;
        [SerializeField] private SpawnerBullets _spawnerBullets;

        private bool _isSpawn = true;

        private void Start()
        {
            StartCoroutine(StartSpawn());
        }

        private IEnumerator StartSpawn()
        {
            while (_isSpawn)
            {
                Enemy enemy = SpawnerType.Spawn();
                enemy.EnemyAttack._weapon.SetSpawnerBullets(_spawnerBullets);
                enemy.EnemyAttack.StartAttack();

                yield return new WaitForSeconds(_timeSpawn);
            }
        }
    }
}
