using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class CooldownTimer
    {
        public async Task<bool> Start(int time)
        {
            await Task.Delay(time);

            return true;
        }
    }
}
