using UnityEngine;

public class HealthBonus : MonoBehaviour
{
    [Header("Bonus")]
    [SerializeField] private float _healPower;

    [Header("Animation Values")]
    [SerializeField] private float _scaleSpeed;
    [SerializeField] private float _destroyValue;

    private bool _triggered;

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.AddHealth(_healPower);
            _triggered = true;
        }
    }

    private void Update()
    {
        if (_triggered == false)
        {
            return;
        }

        transform.localScale -= Vector3.one * Time.deltaTime * _scaleSpeed;
        if (transform.localScale.x < _destroyValue)
        {
            Destroy(gameObject);
        }
    }
}
