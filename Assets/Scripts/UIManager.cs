using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject Finished_Menu;

    public void GameFinishUI()
    {
        Finished_Menu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Finished_Menu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("게임 종료!");
    }
}