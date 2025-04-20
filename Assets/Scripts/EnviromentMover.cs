using UnityEngine;

namespace Assets.Scripts
{
    public class EnviromentMover : MonoBehaviour
    {
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _repitPoint;

        private Player _player;

        public void SetTrackingObject(Player player)
        {
            _player = player;
            _player.PlayerMover.ReachedRepitPoin += Repit;
        }

        private void OnDestroy()
        {
            _player.PlayerMover.ReachedRepitPoin -= Repit;
        }

        public void Repit()
        {
            Vector3 position = transform.position;
            position.x +=  _repitPoint.position.x - _startPoint.position.x;
            transform.position = position;
        }
    }
}
