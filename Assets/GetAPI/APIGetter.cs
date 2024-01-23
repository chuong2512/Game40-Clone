using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class APIGetter : MonoBehaviour
{
    public string task_id = "17";
    [SerializeField] public TextMeshProUGUI txtCoupon;

    public bool startShow;

    void OnEnable()
    {
        if (startShow)
        {
            ShowCode();
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    
    public void ShowCode()
    {
       txtCoupon.text = "Loading code..";
        gameObject.SetActive(true);
        StartCoroutine(GetRequest("https://bakesrc.com/api/get-coupon"));
    }

    IEnumerator GetRequest(string url)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        yield return webRequest.SendWebRequest();
        Debug.Log(webRequest.downloadHandler.text);
        Coupon coupon = JsonUtility.FromJson<Coupon>(webRequest.downloadHandler.text);
        for (int i = 0; i < coupon.list.Length; i++)
        {
            if (coupon.list[i].task_id == task_id)
            {
                txtCoupon.text = coupon.list[i].code;
                break;
            }
        }
    }
}

[Serializable]
public class Coupon
{
    public int code;
    public bool status;
    public CouponData[] list;
    public double time;
}

[Serializable]
public class CouponData
{
    public int id;
    public int check;
    public string task_id;
    public string point;
    public string code;
    public string name;
    public DateTime created_at;
    public DateTime updated_at;
}