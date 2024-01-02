using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SkinItem : MonoBehaviour
{
    private bool isUnlock;
    
    [FormerlySerializedAs("lockObj")] public GameObject lockObject;
    public Image iconImage;
    public TextMeshProUGUI state;

    public void Unlock()
    {
        isUnlock = true;
        lockObject.SetActive(false);
    }

    public void Choose()
    {
        state.SetText("Choose");
    }

    public void UnChoose()
    {
        if (isUnlock)
        {
            state.SetText("Select");
        }
        else
            state.SetText("100 <sprite=0>");
    }

    
}
