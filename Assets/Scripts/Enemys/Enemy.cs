using System;
using UnityEngine;

namespace Assets.Scripts.Enemys
{
    [RequireComponent(typeof(EnemyMover), typeof(EnemyAttack))]
    public class Enemy : MonoBehaviour, ISpawnObject<Enemy>, IAttack, ITarget
    {
        public event Action<Enemy> DestroedSpawnObject;

        public EnemyMover EnemyMover { get; private set; }
        public EnemyAttack EnemyAttack { get; private set; }        

        private void Awake()
        {
            EnemyMover = GetComponent<EnemyMover>();
            EnemyAttack = GetComponent<EnemyAttack>();            
        }

        public void Despawn()
        {
            DestroedSpawnObject?.Invoke(this);
        }
    }
}
