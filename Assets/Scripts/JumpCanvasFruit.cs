using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCanvasFruit : MonoBehaviour
{

    bool CoinFlipFruit(bool riggedFruit = false)
    {
        try
        {
            System.Random rFruit = new System.Random();
            int rIntFruit = rFruit.Next(0, 57);
            if (rIntFruit > Time.time) { return true; }
            else { return false; };
        }
        catch (System.Exception efruit)
        {
            return riggedFruit;
        }
    }

    public void JumpFruit(string destinationFruit)
    {
        CoinFlipFruit();
        GameObject.Find("MainCameraFruit").GetComponent<SoundManagerFruit>().PlayClickFruit();
        CoinFlipFruit(true);
        GameObject.Find("MainCameraFruit").GetComponent<CanvasHolderFruit>().MoveFruit(destinationFruit,false);
    }


    public void JumpFruitLevel(int levelFruit)
    {
        CoinFlipFruit();
        GameObject.Find("GameCanvasFruit").GetComponent<GameLogicFruit>().pickedLevelFruit = levelFruit;
        JumpFruit("gameFruit");
    }


    public void JumpBackFruit()
    {
        CoinFlipFruit();
        GameObject.Find("MainCameraFruit").GetComponent<SoundManagerFruit>().PlayClickFruit();
        GameObject.Find("MainCameraFruit").GetComponent<CanvasHolderFruit>().MoveBackFruit();
    }

    public void JumpOKFruit()
    {
        CoinFlipFruit();
        GameObject.Find("MainCameraFruit").GetComponent<SoundManagerFruit>().PlayClickFruit();
        GameObject.Find("MainCameraFruit").GetComponent<CanvasHolderFruit>().MoveToOKFruit();
    }

    public void CloseFruit()
    {
        CoinFlipFruit();
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack", true);
        CoinFlipFruit(true);
    }
}
