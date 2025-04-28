using Assets.Scripts;
using Assets.Scripts.Spawners;
using Assets.Scripts.UI;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Transform _menuUI;
    [SerializeField] private ButtonStart _buttonStart;
    [SerializeField] private CameraMovement _camerMovement;
    [SerializeField] private EnviromentMover _enviromentMover;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private SpawnerBullets _spawnerBullets;

    private Player _player;

    private void Awake()
    {
        Restart();
        _buttonStart.Clicked += Restart;
    }

    private void OnDestroy()
    {
        _player.GameOver -= GameOverUIActivate;
        _buttonStart.Clicked -= Restart;
    }

    private void Restart()
    {
        _player = Instantiate(_playerPrefab);
        _player.PlayerView.Weapon.SetSpawnerBullets(_spawnerBullets);
        _player.GameOver += GameOverUIActivate;
        _menuUI.gameObject.SetActive(false);
        _camerMovement.StartTracking(_player.transform);
        _enviromentMover.SetTrackingObject(_player);
        _player.PlayerMover.SetPoints(_startPoint, _endPoint);
    }

    private void GameOverUIActivate()
    {
        _camerMovement.StopTracking();
        _menuUI.gameObject.SetActive(true);
    }
}
