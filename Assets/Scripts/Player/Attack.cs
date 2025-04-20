using Assets.Scripts;
using Assets.Scripts.Weapons;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    
    private IAttack _attacker;

    private void Awake()
    {
        _attacker = GetComponent<IAttack>();
    }

    public void Action(Vector3 direction)
    {
        _weapon.Attack(direction, _attacker);
    }
}
