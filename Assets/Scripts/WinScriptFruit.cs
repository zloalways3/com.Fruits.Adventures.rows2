using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class WinScriptFruit : MonoBehaviour
{
    public Text ScoreTxtFruit;


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

    public void WinScreenFruit()
    {
        CoinFlipFruit();

        CoinFlipFruit(true);
        ScoreTxtFruit.text = GameObject.Find("ScoreTextFruit").GetComponent<Text>().text;
        GameObject.Find("LevelCanvasFruit").GetComponent<LevelActivatorFruit>().ActivateButtonsFruit();
        CoinFlipFruit();
    }

}
