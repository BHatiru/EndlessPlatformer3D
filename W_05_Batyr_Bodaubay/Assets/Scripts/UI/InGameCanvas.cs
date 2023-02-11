using TMPro;
using UnityEngine;

public class InGameCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void ShowScores(int scores)
    {
        _scoreText.text = $"Scores: {scores}";
    }
}
