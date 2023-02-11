using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _startGameButton; 
    [SerializeField] private Button _openRecordsButton; 
    [SerializeField] private Button _exitGameButton;

    [Header("Screens")]
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _records;

    public void StartGameButtonPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenRecordsButtonPressed()
    {
        _mainMenu.SetActive(false);
        _records.SetActive(true);
    }

    public void OpenMainMenu()
    {
        _mainMenu.SetActive(true);
        _records.SetActive(false);
    }

    public void ExitGameButtonPressed()
    {
        Application.Quit();
    }
}
