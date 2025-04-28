using Assets.Scripts.Weapons;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemys
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float _minPeriodAttack = 0.5f;
        [SerializeField] private float _maxPeriodAttack = 2f;
        [SerializeField] public Weapon _weapon;

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
            _weapon.Coldowning += Action;
        }

        private void OnDisable()
        {
            _weapon.Coldowning -= Action;
            StopCoroutine(SetReadyState());
        }

        public void StartAttack()
        {
            _weapon.Attack(Vector3.left, _attacker);
        }

        private void Action()
        {
            StartCoroutine(SetReadyState());
        }

        private IEnumerator SetReadyState()
        {
            yield return _sleepTime;
            _weapon.Attack(Vector3.left, _attacker);
        }
    }
}
