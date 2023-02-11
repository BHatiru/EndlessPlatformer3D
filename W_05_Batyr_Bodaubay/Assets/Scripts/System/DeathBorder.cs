using UnityEngine;

public class DeathBorder : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private PlayerScores _playerScores;
    [SerializeField] private SaveLoadSystem _saveLoadSystem;

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if(playerHealth != null)
        {
            SaveScores();
            playerHealth.Death();
        }
    }

    public void SaveScores(){
        _saveLoadSystem.SaveCurrentScores(_playerScores.GetScores());
    }
    private void Update()
    {
        Vector3 newPosition = new Vector3(_player.position.x, transform.position.y, _player.position.z);
        transform.position = newPosition;
    }
}
