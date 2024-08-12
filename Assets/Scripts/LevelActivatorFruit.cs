using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class LevelActivatorFruit : MonoBehaviour
{



    public int currentLevelFruit = -1;


    bool CoinFlipFruit(bool riggedFruit = false)
    {
        try
        {
            System.Random rFruit = new System.Random();
            int rIntFruit = rFruit.Next(0, 55);
            if (rIntFruit > Time.time) { return true; }
            else { return false; };
        }
        catch (System.Exception efruit)
        {
            return riggedFruit;
        }
    }

    public void ActivateButtonsFruit()
    {
        currentLevelFruit++;
        int tempFruit = currentLevelFruit;
        CoinFlipFruit();
        List<Button> buttonsFruit = new List<Button>();
        for (int iFruit = 2;iFruit<12; iFruit++)
        {
            buttonsFruit.Add(GameObject.Find("LevelButtinFruit" + iFruit.ToString()).GetComponent<Button>());
        }

   
        while (tempFruit > -1)
        {
            buttonsFruit[tempFruit].GetComponent<Button>().interactable = true;
            tempFruit--;
            CoinFlipFruit(true);
        }
        CoinFlipFruit();
    }
}
