using System;
using UnityEngine;

public class Constant
{
    public static string DataKey_PlayerData = "player_data";
    public static int countSkin = 5;
    public static int countBG = 5;
    public static int priceUnlockSkin = 100;
    public static int priceUnlockBG = 100;
}

public class PlayerData : BaseData
{
    public int intDiamond;
    public int highPoint;
    public int point;
    public int currentSkin;
    public int currentBG;
    public bool[] listSkins;
    public bool[] listBGs;

    public Action<int> onChangeDiamond;
    public Action<int> onChangePoint;
    public int level;

    public long time;
    public string timeRegister;

    public void SetTimeRegister(long timeSet)
    {
        timeRegister = DateTime.Now.ToBinary().ToString();
        time = timeSet;
        Save();
    }

    public void ResetTime()
    {
        time = 0;
        Save();
    }
    
    public override void Init()
    {
        timeRegister = DateTime.Now.ToBinary().ToString();
        time = 0;
        prefString = Constant.DataKey_PlayerData;
        if (PlayerPrefs.GetString(prefString).Equals(""))
        {
            ResetData();
        }

        base.Init();
    }


    public override void ResetData()
    {
        level = 1;
        intDiamond = 0;
        currentSkin = 0;
        highPoint = 0;
        listSkins = new bool[Constant.countSkin];
        listBGs = new bool[Constant.countBG];

        for (int i = 0; i < 1; i++)
        {
            listSkins[i] = true;
            listBGs[i] = true;
        }

        Save();
    }

    public void UpLevel()
    {
        level++;
        Save();
    }
    
    public void CheckPoint(int point)
    {
        if (point > highPoint)
        {
            highPoint = point;
            Save();
        }
    }

    public bool CheckLock(int id)
    {
        return this.listSkins[id];
    }

    public void Unlock(int id)
    {
        if (!listSkins[id])
        {
            listSkins[id] = true;
        }

        Save();
    }

    public void UnlockBG(int id)
    {
        if (!listBGs[id])
        {
            listBGs[id] = true;
        }

        Save();
    }

    public void AddDiamond(int a)
    {
        intDiamond += a;

        onChangeDiamond?.Invoke(intDiamond);

        Save();
    }
    
    public void AddPoint(int a)
    {
        point += a;

        onChangePoint?.Invoke(point);

        Save();
    }

    public bool CheckCanUnlock()
    {
        return intDiamond >= Constant.priceUnlockSkin;
    }

    public bool CheckCanUnlockBG()
    {
        return intDiamond >= Constant.priceUnlockBG;
    }

    public bool SubDiamond(int a)
    {
        if (intDiamond < a)
        {
            return false;
        }
        
        intDiamond -= a;

        if (intDiamond < 0)
        {
            intDiamond = 0;
        }

        onChangeDiamond?.Invoke(intDiamond);

        Save();

        return true;
    }

    public void ChooseBG(int i)
    {
        currentBG = i;
        Save();
    }
}