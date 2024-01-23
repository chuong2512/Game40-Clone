using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RegisterManager : MonoBehaviour
{
    public Button buttonContinue;
    public GameObject sub;

    public TextMeshProUGUI textRemain;

    private TimeSpan checkTime;

    public void Start()
    {
        checkTime = TimeSpan.FromSeconds(GameDataManager.Instance.playerData.time);

        TimeSpan test =
            DateTime.Now.Subtract(DateTime.FromBinary(Convert.ToInt64(GameDataManager.Instance.playerData.timeRegister)));

        checkTime = checkTime.Subtract(test);

        string answer = string.Format("{0:D2}Day: {1:D2}h:{2:D2}m:{3:D2}s",
            checkTime.Days,
            checkTime.Hours,
            checkTime.Minutes,
            checkTime.Seconds);

        Debug.Log(answer);

        if (checkTime.TotalSeconds <= 0)
        {
            checkTime = TimeSpan.Zero;
            GameDataManager.Instance.playerData.ResetTime();
        }
        

        buttonContinue.onClick.AddListener(OnClickButton);

        UpdateTimeRemain();
    }

    private void OnClickButton()
    {
        sub.SetActive(false);
    }

    public void OnPressDown(int i)
    {
        switch (i)
        {
            case 1:
                IAPManager.OnPurchaseSuccess = () =>
                    AddTime(7);
                IAPManager.Instance.BuyProductID(Key.PACK1);
                break;
            case 2:
                IAPManager.OnPurchaseSuccess = () =>
                    AddTime(30);
                IAPManager.Instance.BuyProductID(Key.PACK2);
                break;
            case 3:
                IAPManager.OnPurchaseSuccess = () =>
                    AddTime(60);
                IAPManager.Instance.BuyProductID(Key.PACK3);
                break;
            case 4:
                IAPManager.OnPurchaseSuccess = () =>
                    AddTime(180);
                IAPManager.Instance.BuyProductID(Key.PACK4);
                break;
            case 5:
                IAPManager.OnPurchaseSuccess = () =>
                    AddTime(360);
                IAPManager.Instance.BuyProductID(Key.PACK5);
                break;
        }
    }

    private void AddTime(int i)
    {
        checkTime = checkTime.Add(TimeSpan.FromSeconds(i * 24 * 60 * 60));

      GameDataManager.Instance.playerData.SetTimeRegister((long) checkTime.TotalSeconds);
        UpdateTimeRemain();
    }

    private float time = 1;

    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            if (checkTime > TimeSpan.Zero)
            {
                checkTime = checkTime.Subtract(TimeSpan.FromSeconds(1));
            }

            UpdateTimeRemain();
            time = 1;
        }
    }

    public void Test()
    {
        checkTime = TimeSpan.FromSeconds(7);
    }


    public void TestLogTime()
    {
        TimeSpan test =
            DateTime.Now.Subtract(DateTime.FromBinary(Convert.ToInt64(GameDataManager.Instance.playerData.timeRegister)));

        string answer = string.Format("{0:D2} Day {1:D2}h:{2:D2}m:{3:D2}s",
            test.Days,
            test.Hours,
            test.Minutes,
            test.Seconds);

        Debug.Log(answer);

        string answer1 = string.Format("{0:D2} Day {1:D2}h:{2:D2}m:{3:D2}s",
            checkTime.Days,
            checkTime.Hours,
            checkTime.Minutes,
            checkTime.Seconds);

        Debug.Log("check time : " + answer1);
    }

    private void UpdateTimeRemain()
    {
        if (checkTime.TotalSeconds < 1)
        {
            textRemain.text = "Buy package to remove ads !!!";
            //textRemain1.text = "You have used up all your playing time";
          GameDataManager.Instance.playerData.ResetTime();
        }
        else
        {
            string answer = string.Format("{0:D1}Day: {1:D2}h:{2:D2}m:{3:D2}s",
                checkTime.Days,
                checkTime.Hours,
                checkTime.Minutes,
                checkTime.Seconds);

            textRemain.text = $"Time remaining : " +
                              $"{answer}";
            /*textRemain1.text = $"Time remaining : " +
                              $"{answer}";*/
        }
    }
}