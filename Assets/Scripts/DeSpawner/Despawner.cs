using UnityEngine;

namespace Assets.Scripts.DeSpawner
{
    public class Despawner<T> : MonoBehaviour where T : Component, ISpawnObject<T>
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.TryGetComponent<T>(out T spawnObject))
            {
                spawnObject.Despawn();
            }
        }
    }
}
