using System.Collections;
using System.Collections.Generic;
using RObo;
using UnityEngine;

public class Level : Singleton<Level>
{
    public Diamond[] diamonds;
    public Bomb[] bombs;

    void OnValidate()
    {
        diamonds = GetComponentsInChildren<Diamond>();
        bombs = GetComponentsInChildren<Bomb>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Drop()
    {
        for (int d = 0; d < diamonds.Length; d++)
        {
          diamonds[d].Drop();
        }

        for (int d = 0; d < bombs.Length; d++)
        {
            bombs[d].Drop();
        }
    }
    
    public void Check()
    {
        for (int d = 0; d < diamonds.Length; d++)
        {
            if (!diamonds[d].check)
            {
                return;
            }
        }
        
        TheGameUI.Instance.ShowWin();
    }
}