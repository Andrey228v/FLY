using Assets.Scripts.Weapons;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemys
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float _minPeriodAttack = 0.5f;
        [SerializeField] private float _maxPeriodAttack = 2f;
        [field: SerializeField] public Weapon Weapon { get; private set;}

        private float _periodAttack;
        private IAttacker _attacker;
        private WaitForSeconds _sleepTime;

        private void Awake()
        {
            _attacker = GetComponent<IAttacker>();
            _periodAttack = Random.Range(_minPeriodAttack, _maxPeriodAttack);
            _sleepTime = new WaitForSeconds(_periodAttack);
        }

        private void OnEnable()
        {
            Weapon.Coldowning += Action;
        }

        private void OnDisable()
        {
            Weapon.Coldowning -= Action;
        }

        public void StartAttack()
        {
            Weapon.Attack(Vector3.left, _attacker);
        }

        private void Action()
        {
            StartCoroutine(SetReadyState());
        }

        private IEnumerator SetReadyState()
        {
            yield return _sleepTime;
            Weapon.Attack(Vector3.left, _attacker);
        }
    }
}
