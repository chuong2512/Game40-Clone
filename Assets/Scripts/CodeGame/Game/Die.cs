using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        TheGameUI.Instance.ShowLose();
    }
}
