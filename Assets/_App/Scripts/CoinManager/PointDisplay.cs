using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointDisplay : MonoBehaviour
{
   public TextMeshProUGUI diamondTmp;

   void OnValidated()
   {
      diamondTmp = GetComponent<TextMeshProUGUI>();
   }

   void Start()
   {
      GameDataManager.Instance.playerData.onChangePoint += i => OnChangeDiamond(i);

      GameDataManager.Instance.playerData.point = 0;
      
      diamondTmp.text = $"{GameDataManager.Instance.playerData.point}";
   }
   
   void OnDestroy()
   {
      GameDataManager.Instance.playerData.onChangePoint -= i => OnChangeDiamond(i);
   }

   private void OnChangeDiamond(int i)
   {
      diamondTmp.text = $"{i}";
   }
}
