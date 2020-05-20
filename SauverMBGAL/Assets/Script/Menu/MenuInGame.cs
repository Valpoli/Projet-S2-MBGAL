using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInGame : MonoBehaviour
{
    public GameObject Menu;
    private bool MenuActive = false;
    
    
    void Update()
    {
        if (MenuActive)
        {
            Menu.SetActive(MenuActive);
            Time.timeScale = 0;
        }
        else
        {
            Menu.SetActive(MenuActive);
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuActive = true;
        }
        
        
    }

    public void resume()
    {
        MenuActive = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
