using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEnemy : MonoBehaviour
{
    [SerializeField] private float _enemySpeed;
    [SerializeField] private float _enemyDamage;
    [SerializeField] private float _scaleSpeed;
    [SerializeField] private float _destroyValue;
    private bool _triggered;

    void OnTriggerEnter(Collider other)
    {
        var bound = other.gameObject.GetComponent<PosHolder>();
        var playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if(bound!=null){
            transform.Rotate(180,0,0);
        }
        
        if (playerHealth != null)
        {
            playerHealth.GetDamage(_enemyDamage);
            _triggered = true;
        }
         
    }
    private void Update()
    {
        if(_triggered == false)
        {
            return;
        }

        transform.localScale -= Vector3.one * Time.deltaTime * _scaleSpeed;
        if(transform.localScale.x < _destroyValue)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        transform.position += transform.forward * _enemySpeed * Time.fixedDeltaTime;
    }
}
