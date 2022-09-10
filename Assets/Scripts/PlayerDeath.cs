using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public float Magnitude;
    public GameObject body;
    PlayerController playerController;
    Animator animator;
    private IEnumerator coroutine;

    void Awake()
    {
        animator = body.GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        coroutine = Timer();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            Death();
        }
    }

    public void Death()
    {
        Debug.Log("Король умер");
        animator.SetBool("Death", true);
        playerController.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        playerController.enabled = false;
        StartCoroutine(coroutine);
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }
}