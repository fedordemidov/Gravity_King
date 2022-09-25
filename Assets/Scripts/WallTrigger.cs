using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    [SerializeField] MonsterController monster;
    enum Direction
    {
        Left = 0,
        Right = 1
    }
    [SerializeField] Direction direction;
    [SerializeField] LayerMask Wals;

    void OnTriggerStay2D(Collider2D collision)
    {
        //if (collision.gameObject.layer == Wals)
        {
            if (direction == Direction.Left)
            {
                monster.horizontalInput =+ 1;
                Debug.Log("+");
            }
            else
            {
                monster.horizontalInput =- 1;
                Debug.Log("-");
            }
        }
    }
}
