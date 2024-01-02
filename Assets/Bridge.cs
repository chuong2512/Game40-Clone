using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using RObo;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class Bridge : Singleton<Bridge>
{
    [FormerlySerializedAs("lineRenderer")] public LineRenderer lineRen;

    private Vector3 pos;

    void Start()
    {
        pos = transform.position;
    }

    [Button]
    public void SetLine(float y, bool rotate = false)
    {
        transform.position = pos;

        lineRen.SetPositions(new[] {Vector3.zero, Vector3.up * y});

        if (rotate)
        {
            Rotate(y);
        }
    }
    
    public void Rotate(float y)
    {
        transform.DORotate(Vector3.back * 90, 1f).SetEase(Ease.Linear)
            .OnComplete(() => { Movement.Instance.Move(y); });
    }
    
    public void Reset()
    {
        transform.DOKill();
        transform.position = pos;
        transform.rotation = Quaternion.identity;
        SetLine(0, false);
    }




}