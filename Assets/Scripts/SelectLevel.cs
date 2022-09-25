using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    public LevelIcon[] Levels;
    public int ActiveLevel;
    private float iconPosition;
    private AudioSource _audio;

    void OnEnable()
    {
        _audio = GetComponent<AudioSource>();
        ActiveLevel = -Levels.Length + 1;
        OnSwipe(new Vector2(1,0));
        OnSwipe(new Vector2(-1,0));
        SwipeDetection.SwipeEvent += OnSwipe;
    }

    void OnDisable()
    {
        SwipeDetection.SwipeEvent -= OnSwipe;
    }

    private void OnSwipe(Vector2 direction)
    {
        if (direction.x < 0 && ActiveLevel > -Levels.Length + 1)
        {
            ActiveLevel -= 1;
            Sound();
        }
        else if (direction.x > 0 && ActiveLevel <= -1)
        {
            ActiveLevel += 1;
            Sound();
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