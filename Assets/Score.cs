using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI high, scrore;

    void OnEnable()
    {
        GameDataManager.Instance.playerData.CheckPoint(GameDataManager.Instance.playerData.point);
        high.SetText($"HIGH SCORE:\n{GameDataManager.Instance.playerData.highPoint}");
        scrore.SetText($"SCORE:\n{GameDataManager.Instance.playerData.point}");
    }
}
