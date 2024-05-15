using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour
{
    public static string[] VehicleNames = new string[] { "the bison", "the bandit", "the missile", "the hound", "the comet", "the tiger" };

    //0 = locked    1 = unlocked
    public static int[] UnlockedVehicles = new int[] { 1, 0, 0, 0, 0, 0 };

    //upgrade level arrays for all vehicles
    public static int[] SpeedLevels = new int[] { 1, 1, 1, 1, 1, 1 };
    public static int[] AccLevels = new int[] { 1, 1, 1, 1, 1, 1 };
    public static int[] BrakeLevels = new int[] { 1, 1, 1, 1, 1, 1 };
  

    public static int coins;



    //costs to unlock each vehicle
    public static int[] UnlockCosts = new int[] { 0, 500, 1000, 1500, 2000, 2500 };

    //upgrade cost per level
    public static int[,] UpgradeCostPerLevel = new int[,]
    { { 0, 50, 100, 150, 200, 250, 300, 350, 400, 450 },
    { 0, 55, 105, 155, 205, 255, 305, 355, 405, 455 },
    { 0, 60, 110, 160, 210, 260, 310, 360, 410, 460 },
    { 0, 65, 115, 165, 215, 265, 315, 365, 415, 465 },
    { 0, 70, 120, 170, 220, 270, 320, 370, 420, 470 },
    { 0, 75, 125, 175, 225, 275, 325, 375, 425, 475 },};

    public static int currentVehicle;


    public static void SaveData()
    {
        for (int i = 0; i < 6; i++)
        {
            PlayerPrefs.SetInt("UnlockedVehicles" + i.ToString(), UnlockedVehicles[i]);
            PlayerPrefs.SetInt("SpeedLevels" + i.ToString(), SpeedLevels[i]);
            PlayerPrefs.SetInt("GripLevels" + i.ToString(), AccLevels[i]);
            PlayerPrefs.SetInt("StabilityLevels" + i.ToString(), BrakeLevels[i]);
           
        }
        PlayerPrefs.SetInt("UnlockedVehicles" + 0, 1);
        PlayerPrefs.SetInt("coins", coins);
        
    }


    public static void LoadData()
    {
        for (int i = 0; i < 6; i++)
        {
            UnlockedVehicles[i] = PlayerPrefs.GetInt("UnlockedVehicles" + i.ToString(), 0);
            SpeedLevels[i] = PlayerPrefs.GetInt("SpeedLevels" + i.ToString(), 1);
            AccLevels[i] = PlayerPrefs.GetInt("GripLevels" + i.ToString(), 1);
            BrakeLevels[i] = PlayerPrefs.GetInt("StabilityLevels" + i.ToString(), 1);
           
        }
        UnlockedVehicles[0] = 1;
        coins = PlayerPrefs.GetInt("coins", 50);
        
    }
}