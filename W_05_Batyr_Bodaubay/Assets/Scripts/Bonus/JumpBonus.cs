using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBonus : MonoBehaviour
{
    [SerializeField] private JumpBonusModel _bonusModel;
    [SerializeField] private float _scaleSpeed;
    [SerializeField] private float _destroyValue;

    private bool _triggered;

    private void OnTriggerEnter(Collider collider)
    {
        var playerMover = collider.gameObject.GetComponent<PlayerMover>();
        if (playerMover != null)
        {
            _triggered = true;
            playerMover.AddJumpBonus(_bonusModel);
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
