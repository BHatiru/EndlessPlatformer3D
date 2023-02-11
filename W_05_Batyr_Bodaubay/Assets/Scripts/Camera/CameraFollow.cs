using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _height;
    [SerializeField] private float _smoothness;

    private float xPosition;

    private void Start()
    {
        xPosition = transform.position.x;
    }

    private void Update()
    {
        Vector3 nextCameraPosition = Vector3.zero;
        nextCameraPosition.x = xPosition;
        nextCameraPosition.y = _height;
        nextCameraPosition.z = Mathf.Lerp(transform.position.z, _target.position.z, _smoothness * Time.deltaTime);


        transform.position = nextCameraPosition;
    }
}
