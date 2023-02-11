using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    private const string LAST_RESULT_KEY = "LAST_RESULT";
    private const string MAX_RESULT_KEY = "MAX_RESULT";

    public void SaveCurrentScores(int scores)
    {
        PlayerPrefs.SetInt(LAST_RESULT_KEY, scores);

        int maxResult = LoadMaxResult();
        if(scores > maxResult)
        {
            PlayerPrefs.SetInt(MAX_RESULT_KEY, scores);
        }

        PlayerPrefs.Save();
    }

    public int LoadLastResult()
    {
        int result = 0;

        if(PlayerPrefs.HasKey(LAST_RESULT_KEY))
        {
            result = PlayerPrefs.GetInt(LAST_RESULT_KEY);
        }

        return result;
    }

    public int LoadMaxResult()
    {
        int result = 0;

        if (PlayerPrefs.HasKey(MAX_RESULT_KEY))
        {
            result = PlayerPrefs.GetInt(MAX_RESULT_KEY);
        }

        return result;
    }
}
