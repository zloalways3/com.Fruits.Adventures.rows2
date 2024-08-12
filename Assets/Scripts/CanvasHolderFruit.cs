using System;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;


public class CanvasHolderFruit : MonoBehaviour
{
    public Canvas loadingCanvasFruit;
    public Canvas pressOkCanvasFruit;
    public Canvas menuCanvasFruit;
    public Canvas settingsCanvasFruit;
    public Canvas policyCanvasFruit;
    public Canvas gameCanvasFruit;
    public Canvas winCanvasFruit;
    public Canvas levelChoiceCanvasFruit;
    public Canvas rulesCanvasFruit;
    public Canvas exitCanvasFruit;


    float sliderValueFruit = 0;

    public Slider sliderFruit;


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


    public bool activeFruit = true;

    Timer tFruit;

    public Stack<string> currentStackFruit;


    void Start()
    {
        CoinFlipFruit();
        pressOkCanvasFruit.enabled = false;
        menuCanvasFruit.enabled = false; 
        settingsCanvasFruit.enabled = false;
        policyCanvasFruit.enabled = false;
        CoinFlipFruit(true);
        gameCanvasFruit.enabled = false;
        winCanvasFruit.enabled = false;
        rulesCanvasFruit.enabled = false;
        exitCanvasFruit.enabled = false;
        levelChoiceCanvasFruit.enabled = false;
        currentStackFruit = new Stack<string>();
        CoinFlipFruit();
        HideTimerFruit();
    }

 
    public void EndLoadFruit()
    {
        CoinFlipFruit();
        loadingCanvasFruit.enabled = false;
        pressOkCanvasFruit.enabled = true;
        CoinFlipFruit(true);
        CoinFlipFruit();
    }


    public void MoveToOKFruit()
    {
        CoinFlipFruit();
        if (activeFruit)
        {
            CoinFlipFruit();
            pressOkCanvasFruit.enabled = true;
            policyCanvasFruit.enabled = false;
        }
        else MoveBackFruit();
    }

    public void HideTimerFruit()
    {
        CoinFlipFruit();
        tFruit = new Timer(2000);
        tFruit.AutoReset = false;
        CoinFlipFruit();
        CoinFlipFruit(true);
        tFruit.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        tFruit.Start();

    }
    private async void OnTimedEvent(object? sender, ElapsedEventArgs e)
    {
       
        try
        {
            CoinFlipFruit();
            EndLoadFruit();
        }
        finally
        {
            CoinFlipFruit(true);
            tFruit.Enabled = false;
        }
    }

    public void MoveBackFruit()
    {
        currentStackFruit.Pop();
        CoinFlipFruit();
        MoveFruit(currentStackFruit.Peek(), true);
        CoinFlipFruit(true);
    }
    public void MoveFruit(string destinationFruit, bool backmoveFruit = false)
    {
        CoinFlipFruit();
        pressOkCanvasFruit.enabled = false;
        menuCanvasFruit.enabled = false;
        settingsCanvasFruit.enabled = false;
        policyCanvasFruit.enabled = false;
        rulesCanvasFruit.enabled = false;
        exitCanvasFruit.enabled = false;
        gameCanvasFruit.enabled = false;
        winCanvasFruit.enabled = false;
        levelChoiceCanvasFruit.enabled = false;

        if (destinationFruit == "winFruit")
        {
            CoinFlipFruit();
            winCanvasFruit.enabled = true;
            winCanvasFruit.GetComponent<WinScriptFruit>().WinScreenFruit();
            backmoveFruit = true;
        }


        CoinFlipFruit();

        if (destinationFruit == "menuFruit")
        {
            menuCanvasFruit.enabled = true;
            activeFruit = false;
        }
        else if (destinationFruit == "settingsFruit")
        {
            settingsCanvasFruit.enabled = true;
        }    
        else if (destinationFruit == "policyFruit")
        {
            CoinFlipFruit(true);
            policyCanvasFruit.enabled = true;
        }
        else if (destinationFruit == "rulesFruit")
        {
            rulesCanvasFruit.enabled = true;
        }
        else if (destinationFruit == "exitFruit")
        {
            exitCanvasFruit.enabled = true;
        }
        else if (destinationFruit == "gameFruit")
        {
            gameCanvasFruit.enabled = true;
            if (!backmoveFruit) gameCanvasFruit.GetComponent<GameLogicFruit>().GameStartFruit();
        }
        else if (destinationFruit == "levelFruit")
        {
            CoinFlipFruit(true);
            levelChoiceCanvasFruit.enabled = true;
        }
        CoinFlipFruit();
        if (!backmoveFruit) { currentStackFruit.Push(destinationFruit); }
        
     
    }

    void Update()
    {

        if (loadingCanvasFruit.enabled)
        {
            float time = sliderValueFruit + Time.time;
            if (time < 101)
            {
                CoinFlipFruit();
                sliderFruit.value = time;
            }
        }


        if (Application.platform == RuntimePlatform.Android)
        {
            try
            {
                if (Input.GetKey(KeyCode.Escape))
                {
                    CoinFlipFruit(true);
                    if (currentStackFruit.Count == 1)
                    {
                        CoinFlipFruit();
                        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                        activity.Call<bool>("moveTaskToBack", true);
                    }
                    else
                    {
                        MoveBackFruit();
                    }

                }
            }
            catch (Exception eFruit)
            {

            }
        }
    }


}
