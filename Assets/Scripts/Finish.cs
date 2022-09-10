using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    Animator animator;
    private IEnumerator coroutine;

    void Start()
    {
        animator = GetComponent<Animator>();
        coroutine = Timer();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Win();
        }
    }

    void Win()
    {
        Debug.Log("open");
        animator.SetBool("Open", true);
        StartCoroutine(coroutine);
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex + 1);
    }
}
