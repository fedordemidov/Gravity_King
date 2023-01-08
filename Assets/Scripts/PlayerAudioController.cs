using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    public void landingPlay()
    {
        audioSource.Play();
        Debug.Log("прыжок ");
    }
}
