using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _xOffset;

    private Transform _trackingObject;
    private bool _isTracking = false;

    private void Update()
    {
        if (_isTracking)
        {
            Vector3 position = transform.position;
            position.x = _trackingObject.position.x + _xOffset;
            position.z = Constants.OffsetCameraZ;
            transform.position = position;
        }
    }

    public void StartTracking(Transform trackingObject)
    {
        _trackingObject = trackingObject;
        _isTracking = true;
        Vector3 position = transform.position;
        position.x = _trackingObject.position.x + _xOffset;
        position.z = Constants.OffsetCameraZ;
        transform.position = position;
    }

    public void StopTracking()
    {
        _isTracking = false;
    }
}
