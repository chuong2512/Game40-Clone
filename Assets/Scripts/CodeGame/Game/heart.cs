using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        GameDataManager.Instance.playerData.AddDiamond(10);
        gameObject.SetActive(false);
    }
}
