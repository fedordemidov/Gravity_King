using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PauseGame ()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void Restart()
    {
        ResumeGame();
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }

    public void Exit()
    {
        ResumeGame();
        SceneManager.LoadScene(0);
    }
}
