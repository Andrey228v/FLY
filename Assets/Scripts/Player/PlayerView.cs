using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private Vector3 vectorOneXY = new Vector3(1, 1, 0);

        private void Update()
        {
            Debug.DrawRay(_player.transform.position, Vector3.right, Color.red);

            float newDirX = vectorOneXY.x * Mathf.Cos(_player.transform.rotation.eulerAngles.z * Mathf.Deg2Rad);
            float newDirY = vectorOneXY.y * Mathf.Sin(_player.transform.rotation.eulerAngles.z * Mathf.Deg2Rad);
            float newDirZ = 0;

            Vector3 newDir = new Vector3(newDirX, newDirY, newDirZ);

            Debug.DrawRay(_player.transform.position, newDir, Color.black);

            if (_player.UserInput.Jump)
            {
                _player.Jump.Action();
            }

            if (_player.UserInput.Attack)
            {
                _player.Attack.Action(newDir);
            }
        }
    }
}
