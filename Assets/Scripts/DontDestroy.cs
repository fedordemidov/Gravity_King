using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy DD;

    public void Awake()
    {
        if (!DD)
        {
            DontDestroyOnLoad(gameObject);
            DD = this;
        } 
        else 
        {
            Destroy(gameObject);
        }
    }
}
