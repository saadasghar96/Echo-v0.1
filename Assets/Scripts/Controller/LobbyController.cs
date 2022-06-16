using UnityEngine;

public class LobbyController : MonoBehaviour
{
    public GameObject levelsMenu;
    public GameObject lobbyMenu;

    public void GoToLevelsMenu()
    {
        levelsMenu.SetActive(true);
        lobbyMenu.SetActive(false);
    }

    public void GoToLobbyMenu()
    {
        levelsMenu.SetActive(false);
        lobbyMenu.SetActive(true);
    }

    public void StartLevelMode()
    {
        GameManager.gameMode = GameManager.GameMode.Levels;

        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartInfiniteMode()
    {
        GameManager.gameMode = GameManager.GameMode.Infinite;

        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
}
