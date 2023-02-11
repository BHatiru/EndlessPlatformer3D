using UnityEngine;

public class PlayerScores : MonoBehaviour
{
    [SerializeField] private InGameCanvas _inGameCanvas;
    [SerializeField] private int _scores;
    [SerializeField] private Transform _player;
    [SerializeField] private float _scoreAddDelta;

    private Vector3 _lastScoredPosition;

    public int GetScores()
    {
        return _scores;
    }

    private void Start()
    {
        _lastScoredPosition = _player.position;
    }

    private void Update()
    {
        float delta = _player.position.z - _lastScoredPosition.z;
        if(delta >= _scoreAddDelta)
        {
            _lastScoredPosition = _player.position;
            _scores++;

            _inGameCanvas.ShowScores(_scores);
        }
    }
}
