using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioClip MenuMusic;
    public AudioClip AmbientMusic;

    [SerializeField] private AudioSource audioSource;

    public void MusicUpdate()
    {
        Debug.Log("1");
        //audioSource.Stop();
        if (SceneManager.GetActiveScene ().buildIndex == 0)
        {
            audioSource.clip = MenuMusic;
            //audioSource.Play();
            Debug.Log("2");
        }
        else
        {
            audioSource.clip = AmbientMusic;
            audioSource.Play();
            Debug.Log("3");
        }
    }

    public void Ambient()
    {
        Debug.Log("1");
        audioSource.clip = AmbientMusic;
        audioSource.enabled = false;
        audioSource.enabled = true;
    }

    public void Menu()
    {
        Debug.Log("2");
        audioSource.clip = null;
        audioSource.clip = MenuMusic;
        audioSource.enabled = false;
        audioSource.enabled = true;
    }
}
