using System;
using UnityEngine;

namespace Assets.Scripts.SpawnPositionType
{
    public interface ISpawnPosition
    {
        public Vector3 GetSpawnPosition();
    }
}
