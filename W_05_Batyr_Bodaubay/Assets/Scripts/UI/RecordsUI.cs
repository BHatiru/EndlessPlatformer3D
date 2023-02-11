using TMPro;
using UnityEngine;

public class RecordsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _lastScores;
    [SerializeField] private TextMeshProUGUI _maxRecord;
    [SerializeField] private SaveLoadSystem _saveLoadSystem;

    private void OnEnable()
    {
        int lastScores = _saveLoadSystem.LoadLastResult();
        int maxScores = _saveLoadSystem.LoadMaxResult();

        _lastScores.text = $"LAST RECORD: {lastScores}";
        _maxRecord.text = $"MAX RECORD: {maxScores}";
    }
}
