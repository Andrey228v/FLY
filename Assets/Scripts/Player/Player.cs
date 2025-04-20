using Assets.Scripts;
using System;
using UnityEngine;

[RequireComponent(typeof(Jump), typeof(Attack), typeof(IUserInput))]
[RequireComponent(typeof(PlayerMover), typeof(PlayerView))]
public class Player : MonoBehaviour, ISpawnObject<Player>, IAttack, ITarget
{
    public event Action GameOver;
    public event Action<Player> DestroedSpawnObject;

    public Jump Jump { get; private set; }
    public Attack Attack { get; private set; }
    public IUserInput UserInput { get; private set; }
    public GroundDetecter GroundDetecter { get; private set; }
    public PlayerMover PlayerMover { get; private set; }
    public PlayerView PlayerView { get; private set; }

    private void Awake()
    {
        Jump = GetComponent<Jump>();
        Attack = GetComponent<Attack>();
        UserInput = GetComponent<IUserInput>();
        GroundDetecter = GetComponent<GroundDetecter>();
        PlayerMover = GetComponent<PlayerMover>();
        PlayerView = GetComponent<PlayerView>();
    }

    public void Despawn()
    {
        GameOver?.Invoke();
        Destroy(gameObject);
    }
}
