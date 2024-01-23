using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface Rigid
{
    void Drop();
} 

public class Diamond : MonoBehaviour, Rigid
{
    public Rigidbody2D rigidbody2D;

    public bool check;

    void OnValidate()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (TheGameUI.Instance.currentState != State.Pause)
        {
            check = true;
        }
    }

    public void Drop()
    {
        rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnDestroy()
    {
        TheGameUI.Instance.ShowLose();
    }
}