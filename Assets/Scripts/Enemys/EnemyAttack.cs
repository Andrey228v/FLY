using Assets.Scripts.Weapons;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemys
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float _minPeriodAttack = 0.5f;
        [SerializeField] private float _maxPeriodAttack = 2f;
        [SerializeField] private Weapon _weapon;

        private CooldownTimer _timer;
        private int _periodAttackMillisecond;
        private bool _isPeriod = true;
        private float _periodAttack;
        private IAttack _attacker;

        private CancellationTokenSource cancelTokenSource;

        private void Awake()
        {
            _attacker = GetComponent<IAttack>();
            _timer = new CooldownTimer();
            _periodAttack = UnityEngine.Random.Range(_minPeriodAttack, _maxPeriodAttack);
            _periodAttackMillisecond = Convert.ToInt32(_periodAttack * 1000);
        }

        private void OnEnable()
        {
            cancelTokenSource = new CancellationTokenSource();
            _weapon.Coldowning += Action;
            Action();
        }

        private void OnDisable()
        {
            cancelTokenSource.Cancel();
            _weapon.Coldowning -= Action;
        }

        private async void Action()
        {
            CancellationToken token = cancelTokenSource.Token;

            if (_isPeriod)
            {
                _isPeriod = false;

                Task<bool> task = Task.Run(()=> _timer.Start(_periodAttackMillisecond), token);

                _isPeriod = await task;

                if (token.IsCancellationRequested)
                {
                    return;
                }

                _weapon.Attack(Vector3.left, _attacker);                

            }
        }
    }
}
