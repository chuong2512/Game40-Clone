using UnityEngine;

public class SkinSelect : MonoBehaviour
{
    private PlayerData playerData; //todo delete
    private GameDataManager gameDataManager; 
    public int currentSkin;
    public SkinItem[] skinItems;

    void Start()
    {
        gameDataManager = GameDataManager.Instance;
        playerData = gameDataManager.playerData;
        
        currentSkin = playerData.currentSkin;
        
        for (int i = 0; i < skinItems.Length; i++)
        {
            if (playerData.listSkins[i])
            {
                skinItems[i].Unlock();
                skinItems[i].UnChoose();
            }
        }
        
        skinItems[currentSkin].Choose();
    }
    
    public void UnlockSkin(int index)
    {
        if (!playerData.listSkins[index])
        {
            playerData.SubDiamond(Constant.priceUnlockSkin);
        }
        
        skinItems[index].Unlock();
        playerData.Unlock(index);
    }
    
    public void ChooseSkin(int index)
    {
        if (currentSkin == index)
        {
            return;
        }
        else if (playerData.listSkins[index] == false)
        {
            if (!playerData.CheckCanUnlock())
            {
                return;
            }
            UnlockSkin(index);
        }
        
        skinItems[currentSkin].UnChoose();
        skinItems[index].Choose();
        currentSkin = index;
        playerData.currentSkin = currentSkin;
        //todo add Playerdata
    }

    

}
