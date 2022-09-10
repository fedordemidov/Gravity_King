using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    public LevelIcon[] Levels;
    public int ActiveLevel;
    private float iconPosition;
    private AudioSource _audio;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        ActiveLevel = -Levels.Length + 1;
        OnSwipe(new Vector2(1,0));
        OnSwipe(new Vector2(-1,0));
        SwipeDetection.SwipeEvent += OnSwipe;
    }

    void Update()
    {
        
    }

    private void OnSwipe(Vector2 direction)
    {
        //Sound();
        if (direction.x < 0 && ActiveLevel > -Levels.Length + 1)
        {
            ActiveLevel -= 1;
        }
        else if (direction.x > 0 && ActiveLevel <= -1)
        {
            ActiveLevel += 1;
        }
        else
        {
            
        }

        for (int i=0; i < Levels.Length; i++)
        {
            Levels[i].ActiveLevel = ActiveLevel;
            Levels[i].i = i;
        }
    }

    public void Play()
    {
        Sound();
        SceneManager.LoadScene(ActiveLevel*-1 + 1);
    }

    public void Sound()
    {
        _audio.Play();
    }
}
