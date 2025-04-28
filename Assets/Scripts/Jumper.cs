using Assets.Scripts;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(GroundDetecter))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private Rigidbody2D _rigidbody;
    private GroundDetecter _groundDetecter;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundDetecter = GetComponent<GroundDetecter>();
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void Update()
    {
        if(_groundDetecter.IsCollisionWithGround == false)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
        }
    }

    public void Action()
    {
        _rigidbody.linearVelocity = new Vector2(_speed, _tapForce);
        transform.rotation = _maxRotation;
    }
}
