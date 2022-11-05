using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    public LevelIcon[] Levels;
    public int ActiveLevel;
    [SerializeField] Text text;
    private SoundManager sm;
    private float iconPosition;
    private AudioSource _audio;

    void OnEnable()
    {
        _audio = GetComponent<AudioSource>();
        ActiveLevel = PlayerPrefs.GetInt("OpenLevels");
        OnSwipe(new Vector2(1,0));
        OnSwipe(new Vector2(-1,0));
        SwipeDetection.SwipeEvent += OnSwipe;
        sm = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
        text.text = PlayerPrefs.GetInt("OpenLevels").ToString();
    }

    void OnDisable()
    {
        SwipeDetection.SwipeEvent -= OnSwipe;
    }

    private void OnSwipe(Vector2 direction)
    {
        if (direction.x < 0 && ActiveLevel > PlayerPrefs.GetInt("OpenLevels"))
        {
            ActiveLevel -= 1;
            Sound();
        }
        else if (direction.x > 0 && ActiveLevel < 0)
        {
            ActiveLevel += 1;
            Sound();
        }

        for (int i=0; i < Levels.Length; i++)
        {
            Levels[i].ActiveLevel = ActiveLevel;
            Levels[i].number = i;
            Levels[i].isOpen();
        }
    }

    public void Play()
    {
        sm.Ambient();
        Sound();
        SceneManager.LoadScene(ActiveLevel*-1 + 1);
    }

    public void Sound()
    {
        _audio.Play();
    }
}