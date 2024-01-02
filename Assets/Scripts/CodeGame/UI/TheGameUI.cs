using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using RObo;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum State
{
    Drawing,
    Stop,
    Pause
}

public class TheGameUI : Singleton<TheGameUI>
{
    public GameObject lose, win;

    public State currentState = State.Drawing;


    public TextMeshProUGUI levelTMP;

    // Start is called before the first frame update
    void Start()
    {
        SetState(State.Drawing);
        
        levelTMP.SetText($"LEVEL {GameDataManager.Instance.playerData.level}");
    }

    public void ShowLose()
    {
        StopAllCoroutines();
        SetState(State.Pause);
        lose.SetActive(true);
    }

    public void ShowWin()
    {
        StopAllCoroutines();
        SetState(State.Pause);
        win.SetActive(true);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void NextGame()
    {
        if (GameDataManager.Instance.playerData.SubDiamond(1))
        {
            
           NextGameWin();
        }
        
    }
        
        public void NextGameWin()
    {

            GameDataManager.Instance.playerData.UpLevel();
            SceneManager.LoadScene("Game");
        
        
    }

    [Button]
    public void Jump()
    {
        SetState(State.Drawing);
    }

    private float duration = 1f;

    public void SetState(State state)
    {
        currentState = state;
    }

    public void Check()
    {
        IEnumerator CheckIE()
        {
            yield return new WaitForSeconds(5);
            Level.Instance.Check();
        }

        StartCoroutine(CheckIE());
    }
}