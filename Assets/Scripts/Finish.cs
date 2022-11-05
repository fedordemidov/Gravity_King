using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    Animator animator => GetComponent<Animator>();
    public InterstitialAdsButton ad;
    [SerializeField] bool ShowAd = true;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player") Win();
    }

    private void Win()
    {
        animator.SetBool("Open", true);
        StartCoroutine(Timer());
        if (-SceneManager.GetActiveScene().buildIndex+1 == PlayerPrefs.GetInt("OpenLevels"))
        {
            PlayerPrefs.SetInt("OpenLevels", -SceneManager.GetActiveScene().buildIndex ) ;
        }        
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        if (ShowAd)
        {
            ad.ShowAd();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex + 1);
    }
}
