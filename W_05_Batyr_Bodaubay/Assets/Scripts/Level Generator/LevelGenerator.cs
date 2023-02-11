using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Traps")]
    [SerializeField] private GameObject _trap;
    [SerializeField] private GameObject _enemyPrefab;

    [Header("Bonus")]
    [SerializeField] private GameObject _healthBonusPrefab;
    [SerializeField] private GameObject _speedBonusPrefab;
    [SerializeField] private GameObject _jumpBonusPrefab;

    [Header("Platforms")]
    [SerializeField] private float _spawnPlatformPosition;
    [SerializeField] private Transform _player;
    [SerializeField] private List<GameObject> _platformPrefabs;

    [Header("Generation settings")]
    [SerializeField] private Vector2 _minMaxSpawnZ;
    [SerializeField] private Vector2 _minMaxHeight;
    [SerializeField] private float _jumpHeight;

    private List<Platform> _plaforms;
    private Vector3 _frontier = Vector3.one * -float.MaxValue;
    

    private void Start()
    {
        _plaforms = new List<Platform>();
        _plaforms.AddRange(FindObjectsOfType<Platform>());

        FindFrontier();
    }

    private void Update()
    {
        float distance = _frontier.z - _player.position.z;
        if(distance <= _spawnPlatformPosition)
        {
            InstantiatePlatform();
            FindFrontier();
        }
    }

    private Vector3 FindNextPlatformPosition()
    {
        float x = _frontier.x;
        float z = _frontier.z + Random.Range(_minMaxSpawnZ.x, _minMaxSpawnZ.y);
        float y = Random.Range(_minMaxHeight.x, _frontier.y + _jumpHeight);

        return new Vector3(x, y, z);
    }

    private void InstantiatePlatform()
    {
        Vector3 position = FindNextPlatformPosition();
        int randomIndex = Random.Range(0, _platformPrefabs.Count - 1);

        GameObject newPlatform = Instantiate(_platformPrefabs[randomIndex], position, Quaternion.identity);
        Platform platform = newPlatform.GetComponent<Platform>();
        bool generateTrap = Random.Range(-1000, 1000) % 2 == 0;
        if(generateTrap)
        {
            bool generateMovingTrap = Random.Range(0,10)%3==0;
            if(generateMovingTrap){
                CreateInteractableObject(platform, _enemyPrefab);
            }else{
                CreateInteractableObject(platform, _trap);
            }
            
            
        }
        else
        {
            bool generateBonus = Random.Range(0, 101) < 60;
            if(generateBonus)
            {
                int _bonusIndex = Random.Range(0,4);
                switch (_bonusIndex)
                {
                    case 0: 
                        CreateInteractableObject(platform, _healthBonusPrefab);
                        break;
                    case 1: 
                        CreateInteractableObject(platform, _speedBonusPrefab);
                        break;
                    case 2:
                        CreateInteractableObject(platform, _jumpBonusPrefab);
                        break;  
                }
            }
        }

        _plaforms.Add(platform);
    }

    private void CreateInteractableObject(Platform platform, GameObject prefab)
    {
        GameObject trap = Instantiate(prefab);
        SphereCollider sphereCollider = trap.GetComponent<SphereCollider>();

        float colliderY = platform.transform.position.y + platform.GetHeight();
        float sphereY = sphereCollider.radius * trap.transform.localScale.z;

        float halfSize = platform.GetSize() / 2;
        float randomZ = Random.Range(-halfSize, halfSize);

        float x = platform.transform.position.x;
        float y = colliderY + sphereY;
        float z = platform.transform.position.z + randomZ;
        
        trap.transform.position = new Vector3(x, y, z);

    }

    private void FindFrontier()
    {
        foreach(Platform platform in _plaforms)
        {
            if(platform.transform.position.z > _frontier.z)
            {
                _frontier = platform.transform.position;
            }
        }
    }
}
