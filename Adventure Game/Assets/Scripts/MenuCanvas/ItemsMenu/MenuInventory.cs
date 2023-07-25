using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInventory : MonoBehaviour
{

    public GameObject menuInventoryCharacter;
    public static bool isPause = false;

    public Canvas hud;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
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
        menuInventoryCharacter.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;

        hud.enabled = true;
    }

    void Pause()
    {
        menuInventoryCharacter.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
        hud.enabled = false;

    }


}
