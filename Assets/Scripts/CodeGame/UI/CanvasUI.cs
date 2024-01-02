using System.Collections;
using System.Collections.Generic;
using RObo;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasUI : Singleton<CanvasUI>
{
    public Image bg;

    public Button start, exit;

    // Start is called before the first frame update
    void Start()
    {
        start?.onClick.AddListener(OpenGame);
        exit?.onClick.AddListener(ExitGame);
    }

    private void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void OpenGame()
    {
        SceneManager.LoadScene("Game");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetBG(Sprite sprite)
    {
        bg.sprite = sprite;
    }
}