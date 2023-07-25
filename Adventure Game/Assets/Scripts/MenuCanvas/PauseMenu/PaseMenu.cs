using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PaseMenu : MonoBehaviour
{

    public static bool isPause = false;
    public GameObject menuPause;

    public Button resume;
    public Button quitToMainMenu;
    public Button quitToWindows;

    void Start()
    {
        Button Res = resume.GetComponent<Button>();
        Res.onClick.AddListener(Resume);
        Button QTMM = quitToMainMenu.GetComponent<Button>();
        QTMM.onClick.AddListener(QuiteToMainMenu);
        Button QTW = quitToWindows.GetComponent<Button>();
        QTW.onClick.AddListener(QuiteToWindows);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }

    void Resume()
    {
        menuPause.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;

    }

    void Pause()
    {
        menuPause.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;

    }

    public void QuiteToMainMenu()
    {
        Time.timeScale = 1f;
        isPause = false;

        SceneManager.LoadScene("MainMenu");

    }

    public void QuiteToWindows()
    {
        Application.Quit();
    }


}
