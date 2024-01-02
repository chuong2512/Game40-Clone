using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLevel : MonoBehaviour
{
    public GameObject[] rand;

    public void Start()
    {
        Instantiate(rand[Random.Range(0, rand.Length)]);
    }
}