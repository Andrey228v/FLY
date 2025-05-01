using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [field: SerializeField] public Weapon Weapon { get; private set; }

        private Vector3 _vectorOneXY = new Vector3(1, 1, 0);
        private Vector3 _newDir;
        private bool _readyAttackState = true;

        private void OnEnable()
        {
            _player.UserInput.Jumped += ActivateJump;
            _player.UserInput.Attacked += ActivateAttack;
            Weapon.Coldowning += SetReadyAttackState;
        }

        private void OnDisable()
        {
            _player.UserInput.Jumped -= ActivateJump;
            _player.UserInput.Attacked -= ActivateAttack;
            Weapon.Coldowning -= SetReadyAttackState;
        }

        private void Update()
        {
            Debug.DrawRay(_player.transform.position, Vector3.right, Color.red);

            float newDirX = _vectorOneXY.x * Mathf.Cos(_player.transform.rotation.eulerAngles.z * Mathf.Deg2Rad);
            float newDirY = _vectorOneXY.y * Mathf.Sin(_player.transform.rotation.eulerAngles.z * Mathf.Deg2Rad);
            float newDirZ = 0;

            _newDir = new Vector3(newDirX, newDirY, newDirZ);

            Debug.DrawRay(_player.transform.position, _newDir, Color.black);
        }

        private void ActivateJump()
        {
            _player.Jump.Action();
        }

        private void ActivateAttack()
        {
            if (_readyAttackState)
            {
                Weapon.Attack(_newDir, _player);
                _readyAttackState = false;
            }
        }

        private void SetReadyAttackState()
        {
            _readyAttackState = true;
        }
    }
}
