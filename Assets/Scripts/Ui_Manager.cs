using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_Manager : MonoBehaviour
{
    public GameObject mainMenuScreen;
    public GameObject garageScreen;
    public GameObject upgradeScreen;
    public GameObject ui;
    public GameObject mapSelectionScreen;
    public GameObject Exit, back;

    public GameObject MainCamera;
    public GameObject GarageCamera;

    private GameObject lastActiveScreen;

    private void Start()
    {
        mainMenuScreen.SetActive(true);
        garageScreen.SetActive(false);
        upgradeScreen.SetActive(false);
        mapSelectionScreen.SetActive(false);

        lastActiveScreen = mainMenuScreen;
    }
    private void Update()
    {
        //MainCamera Logic
        if (garageScreen.activeSelf || upgradeScreen.activeSelf)
        {
            MainCamera.SetActive(false);
            GarageCamera.SetActive(true);
        }
        else
        {
            MainCamera.SetActive(true) ;
            GarageCamera.SetActive(false) ;
        }

        if(mainMenuScreen.activeSelf)
        {
            Exit.SetActive(true);
            back.SetActive(false);
        }
        else
        {
            Exit.SetActive(false) ;
            back.SetActive(true) ;
        }
    }

    // Function to set the last active screen

    public void lastACtiveScrenen(GameObject screen)
    {
        lastActiveScreen =screen;
    }
    public void Back()
    {
          if (mapSelectionScreen != null && mapSelectionScreen.activeSelf)
        {
            // Check if the last active screen is set
            if (lastActiveScreen == mainMenuScreen)
            {
                mainMenuScreen.SetActive(true);
                 
            }
            else
            {
                garageScreen.SetActive(true);
            }
            mapSelectionScreen.SetActive(false);
        }
        else if (mainMenuScreen != null && mainMenuScreen.activeSelf)
        {
            Application.Quit();
        }
        else if (garageScreen != null && garageScreen.activeSelf)
        {
            
            if (ui.activeSelf)
            {
                garageScreen.SetActive(false);
                mainMenuScreen.SetActive(true);
            }
            else
            {
                upgradeScreen.SetActive(false);
                ui.SetActive(true) ;
            }
        }
        else if (upgradeScreen != null && upgradeScreen.activeSelf)
        {
            
            ui.SetActive(true);
            upgradeScreen.SetActive(false);
        }
       
    }

    
    public void onClickPlay()
    {
        mainMenuScreen.SetActive(false);
        mapSelectionScreen.SetActive(true );
    }
}
