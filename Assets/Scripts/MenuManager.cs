using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private SoundManager sm;

    void Start()
    {
        if (GameObject.FindWithTag("SoundManager"))
        {
            sm = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
        }
    }

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
        sm.Menu();
        ResumeGame();
        SceneManager.LoadScene(0);
    }
}
