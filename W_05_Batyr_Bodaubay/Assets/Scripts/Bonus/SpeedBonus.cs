using UnityEngine;

public class SpeedBonus : MonoBehaviour
{
    [SerializeField] private SpeedBonusModel _bonusModel;
    [SerializeField] private float _scaleSpeed;
    [SerializeField] private float _destroyValue;

    private bool _triggered;

    private void OnTriggerEnter(Collider collider)
    {
        var playerMover = collider.gameObject.GetComponent<PlayerMover>();
        if (playerMover != null)
        {
            _triggered = true;
            playerMover.AddSpeedBonus(_bonusModel);
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
