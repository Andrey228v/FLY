using Assets.Scripts;
using System;
using UnityEngine;

[RequireComponent(typeof(Jumper), typeof(IUserInput))]
[RequireComponent(typeof(PlayerMover), typeof(PlayerView))]
public class Player : MonoBehaviour, ISpawnObject<Player>, IAttacker, IDead
{
    public event Action GameOver;
    public event Action<Player> DestroedSpawnObject;

    public Jumper Jump { get; private set; }
    public IUserInput UserInput { get; private set; }
    public GroundDetecter GroundDetecter { get; private set; }
    public PlayerMover PlayerMover { get; private set; }
    public PlayerView PlayerView { get; private set; }

    private void Awake()
    {
        Jump = GetComponent<Jumper>();
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
