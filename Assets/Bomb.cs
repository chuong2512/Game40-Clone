using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;


    void OnValidate()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (TheGameUI.Instance.currentState != State.Pause)
        {
            if (collision.gameObject.CompareTag("Diamond"))
            {
                TheGameUI.Instance.ShowLose();
                return;
            }
        }
    }

    public void Drop()
    {
        rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }
}