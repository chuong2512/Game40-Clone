using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using RObo;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class Movement : Singleton<Movement>
{
    public float lastPoint = 2.2f;
    [FormerlySerializedAs("Add")] public float add = 0.5f;
    public float speed = 1.5f;
    [FormerlySerializedAs("pos")] public Vector3 position;

    [FormerlySerializedAs("cau")] public Bridge bridge;

    public GameObject[] cols;

    public void GenCol()
    {
        lastPoint += Random.Range(0.8f, 3f);

        var col = Instantiate(cols[Random.Range(0, cols.Length)]
            ,transform);
        
        col.transform.localPosition = position + Vector3.right * lastPoint;
    }

    [Button]
    public void Move(float x)
    {
        for (int i = 0; i < 3; i++)
        {
            GenCol();
        }
       
        Robot.Instance.Run();
        transform.DOMoveX(transform.position.x - x - add, Mathf.Abs((x+add) / speed)).SetEase(Ease.Linear).OnComplete(() =>
        {
            bridge.Reset();
            Robot.Instance.EndRun();
            TheGameUI.Instance.SetState(State.Stop);
        });

        bridge.transform.DOMoveX(bridge.transform.position.x - x - add, Mathf.Abs((x+add) / speed)).SetEase(Ease.Linear);
    }
}