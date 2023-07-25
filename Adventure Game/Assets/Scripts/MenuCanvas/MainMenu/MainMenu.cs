using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Button newGame;
    public Button quite;

    void Start()
    {
        Button NG = newGame.GetComponent<Button>();
        NG.onClick.AddListener(NewGame);
        Button Quit = quite.GetComponent<Button>();
        Quit.onClick.AddListener(Quite1);
    }



    public void NewGame()
    {

        SceneManager.LoadScene("Level0");
    }



    public void Quite1()
    {
        Application.Quit();
    }
}
