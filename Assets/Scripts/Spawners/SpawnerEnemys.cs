using Assets.Scripts.Enemys;
using Assets.Scripts.Spawners.ObjectsPools;
using Assets.Scripts.Spawners.SpawnerType;
using UnityEngine;

namespace Assets.Scripts.Spawners
{
    [RequireComponent(typeof(ISpawnerType<Enemy>), typeof(ObjectPoolPrefab<Enemy>))]
    public class SpawnerEnemys : Spawner<Enemy>
    {
        private void Start()
        {
            SpawnerType.Spawn();
        }

    }
}
