using System;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


public class GameLogicFruit : MonoBehaviour
{

    public CellFruit firstClickedFruit;
    public bool boolFirstFruit = false;

    public CellFruit secondClickedFruit;
    public bool boolSecondFruit = false;
    System.Random rFruit = new System.Random();
    public Text scoreTextFruit;

    public Sprite sprite1Fruit;
    public Sprite sprite2Fruit;
    public Sprite sprite3Fruit;
    public Sprite sprite4Fruit;
    public Sprite sprite5Fruit;
    public Sprite sprite6Fruit;
    public Sprite sprite7Fruit;



    public Image goalFruit1;
    public Image goalFruit2;
    public Text goalFruitText1;
    public Text goalFruitText2;
    int goalNumberFruit1 = 20;
    int goalNumberFruit2 = 25;



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

    public bool firstMoveFinishedFruit =false;
    public bool secondMoveFinishedFruit = false;


   
    bool destructionHappenedFruit = false;

    public int pointsFruit = 0;
    public int pointGoalFruit = 5000;
    public int pickedLevelFruit = 0;
    bool pointCountFruit = false;


    List<int> horizontal;
    List<int> vertical;

    public void TryCheckFruit()
    {
        CoinFlipFruit();

        for (int jFruit = 1; jFruit < 26; jFruit++)
        {

            if (horizontal.Contains(jFruit)){
                
                if ((GameObject.Find("GamePiece" + (jFruit + 1).ToString() + "Fruit").GetComponent<CellFruit>().spriteFruit.GetInstanceID() == GameObject.Find("GamePiece" + jFruit.ToString() + "Fruit").GetComponent<CellFruit>().spriteFruit.GetInstanceID()) && (GameObject.Find("GamePiece" + (jFruit - 1).ToString() + "Fruit").GetComponent<CellFruit>().spriteFruit.GetInstanceID() == GameObject.Find("GamePiece" + jFruit.ToString() + "Fruit").GetComponent<CellFruit>().spriteFruit.GetInstanceID()))
                {
                    if (!GameObject.Find("GamePiece" + (jFruit - 1).ToString() + "Fruit").GetComponent<CellFruit>().needsDestructionFruit)
                    {
                        GameObject.Find("GamePiece" + (jFruit - 1).ToString() + "Fruit").GetComponent<CellFruit>().needsDestructionFruit = true;
                        if (pointCountFruit)
                            pointsFruit += 10;
                    }
                    if (!GameObject.Find("GamePiece" + (jFruit).ToString() + "Fruit").GetComponent<CellFruit>().needsDestructionFruit)
                    {
                        GameObject.Find("GamePiece" + (jFruit).ToString() + "Fruit").GetComponent<CellFruit>().needsDestructionFruit = true;
                        if (pointCountFruit)
                            pointsFruit += 10;
                    }
                    if (!GameObject.Find("GamePiece" + (jFruit + 1).ToString() + "Fruit").GetComponent<CellFruit>().needsDestructionFruit)
                    {
                        GameObject.Find("GamePiece" + (jFruit + 1).ToString() + "Fruit").GetComponent<CellFruit>().needsDestructionFruit = true;
                        if (pointCountFruit)
                            pointsFruit += 10;
                    }
                }
            }
            CoinFlipFruit();
            if (vertical.Contains(jFruit))
            {
             
                if ((GameObject.Find("GamePiece" + (jFruit + 5).ToString() + "Fruit").GetComponent<CellFruit>().spriteFruit.GetInstanceID() == GameObject.Find("GamePiece" + jFruit.ToString() + "Fruit").GetComponent<CellFruit>().spriteFruit.GetInstanceID()) && (GameObject.Find("GamePiece" + (jFruit - 5).ToString() + "Fruit").GetComponent<CellFruit>().spriteFruit.GetInstanceID() == GameObject.Find("GamePiece" + jFruit.ToString() + "Fruit").GetComponent<CellFruit>().spriteFruit.GetInstanceID()))
                {
                    if (!GameObject.Find("GamePiece" + (jFruit - 5).ToString()+"Fruit").GetComponent<CellFruit>().needsDestructionFruit)
                    {
                        GameObject.Find("GamePiece" + (jFruit - 5).ToString() + "Fruit").GetComponent<CellFruit>().needsDestructionFruit = true;
                        if (pointCountFruit)
                            pointsFruit += 10;
                    }
                    if (!GameObject.Find("GamePiece" + (jFruit).ToString() + "Fruit").GetComponent<CellFruit>().needsDestructionFruit)
                    {
                        GameObject.Find("GamePiece" + (jFruit).ToString() + "Fruit").GetComponent<CellFruit>().needsDestructionFruit = true;
                        if (pointCountFruit)
                            pointsFruit += 10;
                    }
                    if (!GameObject.Find("GamePiece" + (jFruit + 5).ToString() + "Fruit").GetComponent<CellFruit>().needsDestructionFruit)
                    {
                        GameObject.Find("GamePiece" + (jFruit + 5).ToString() + "Fruit").GetComponent<CellFruit>().needsDestructionFruit = true;
                        if (pointCountFruit)
                            pointsFruit += 10;
                    }
                }
            }


        }

        bool happened = false;
        for (int jFruit = 1; jFruit < 26; jFruit++)
        {
            CoinFlipFruit();
            if ( GameObject.Find("GamePiece" + jFruit.ToString() + "Fruit").GetComponent<CellFruit>().needsDestructionFruit){
                if (GameObject.Find("GamePiece" + jFruit.ToString() + "Fruit").GetComponent<CellFruit>().spriteFruit==goalFruit1.sprite)
                {
                    goalNumberFruit1--;
                    if (goalNumberFruit1 > -1) goalFruitText1.text = "x" + goalNumberFruit1.ToString();
                }
                else if (GameObject.Find("GamePiece" + jFruit.ToString() + "Fruit").GetComponent<CellFruit>().spriteFruit == goalFruit2.sprite)
                {
                    goalNumberFruit2--;
                    if(goalNumberFruit2>-1) goalFruitText2.text = "x" + goalNumberFruit2.ToString();
                }
                GameObject.Find("GamePiece" + jFruit.ToString() + "Fruit").GetComponent<CellFruit>().needsDestructionFruit = false;
                NewDestroyFruit(GameObject.Find("GamePiece" + jFruit.ToString() + "Fruit").GetComponent<CellFruit>(), jFruit);
                happened = true;
            }
        }
        CoinFlipFruit();
        if (happened) { destructionHappenedFruit = true;
            if (pointCountFruit) GameObject.Find("MainCameraFruit").GetComponent<SoundManagerFruit>().PlayPingFruit();
        }
        else destructionHappenedFruit= false;
        CoinFlipFruit();

    }


    public void NewDestroyFruit(CellFruit targetFruit,int numberFruit)
    {
        if (numberFruit < 6)
        {        
            targetFruit.spriteFruit = RandomSpriteFruit(GameObject.Find("GamePiece" + (numberFruit + 5).ToString() + "Fruit").GetComponent<CellFruit>().spriteFruit);
        }
        else
        {
            targetFruit.spriteFruit = GameObject.Find("GamePiece" + (numberFruit-5).ToString() + "Fruit").GetComponent<CellFruit>().spriteFruit;
            NewDestroyFruit(GameObject.Find("GamePiece" + (numberFruit - 5).ToString() + "Fruit").GetComponent<CellFruit>(), numberFruit - 5);
        }
        CoinFlipFruit();
    }

    public void GameStartFruit()
    {
        pointCountFruit = false;
        horizontal = new List<int>
        {2,3,4,7,8,9,12,13,14,17,18,19,22,23,24};

        vertical = new List<int>
        {6,7,8,9,10,11,12,13,14,15,16,17,18,19,20};
        CoinFlipFruit();


        CoinFlipFruit();

        for (int jFruit = 1; jFruit < 26; jFruit++)
        {
            GameObject.Find("GamePiece" + jFruit.ToString() + "Fruit").GetComponent<CellFruit>().spriteFruit = RandomSpriteFruit();
            GameObject.Find("GamePiece" + jFruit.ToString() + "Fruit").GetComponent<CellFruit>().CellStartFruit();

        }


        pointsFruit = 0;
        pointGoalFruit = 500 + pickedLevelFruit * 50;
        goalNumberFruit1 = 5 + pickedLevelFruit * 2;
        goalNumberFruit2 = 10 + pickedLevelFruit * 2;

        goalFruit1.sprite = RandomSpriteFruit();
        goalFruit2.sprite=RandomSpriteFruit();

        goalFruitText1.text = "x" + goalNumberFruit1.ToString();
        goalFruitText2.text = "x" + goalNumberFruit2.ToString();
        while (goalFruit1.sprite == goalFruit2)
        {
            goalFruit2.sprite=RandomSpriteFruit();
        }


        CoinFlipFruit();

        BigGameCheckFruit();
        pointCountFruit = true;
    }
    public Sprite RandomSpriteFruit(Sprite previousSprite = null)
    {
        Sprite tempSpriteFruit;
        int rIntFruit = rFruit.Next(0, 7);
        if (rIntFruit == 0) tempSpriteFruit = sprite1Fruit;
        else if (rIntFruit == 1) tempSpriteFruit = sprite2Fruit;
        else if (rIntFruit == 2) tempSpriteFruit = sprite3Fruit;
        else if (rIntFruit == 3) tempSpriteFruit = sprite4Fruit;
        else if (rIntFruit == 4) tempSpriteFruit = sprite5Fruit;
        else if (rIntFruit == 5) tempSpriteFruit = sprite6Fruit;
        else tempSpriteFruit = sprite7Fruit;
        CoinFlipFruit();
        if (previousSprite != null)
        {
            while (previousSprite.GetInstanceID() == tempSpriteFruit.GetInstanceID())
            {
               tempSpriteFruit=RandomSpriteFruit();
            }
        }

        CoinFlipFruit();
        return tempSpriteFruit;
    }

    void SwapFruit()
    {
     
        if ((Math.Abs(firstClickedFruit.positionXFruit - secondClickedFruit.positionXFruit) +Math.Abs(firstClickedFruit.positionYFruit - secondClickedFruit.positionYFruit))==1)
        {
            Vector3 firstTempFruit = secondClickedFruit.currentPositionFruit;
            Vector3 secondTempFruit = firstClickedFruit.currentPositionFruit;
            Sprite temp1 = secondClickedFruit.spriteFruit;
            Sprite temp2 = firstClickedFruit.spriteFruit;
            firstClickedFruit.StartMoveFruit(firstTempFruit, temp1);
            secondClickedFruit.StartMoveFruit(secondTempFruit, temp2);
            CoinFlipFruit();
        }
        else
        {
            firstClickedFruit.RefreshSpriteFruit();
            firstClickedFruit = null;
            secondClickedFruit = null;
            boolFirstFruit = false;
            boolSecondFruit = false;
        }
        CoinFlipFruit();
    }

 


    public void BigGameCheckFruit()
    {
        TryCheckFruit();

        while (destructionHappenedFruit)
        {
            TryCheckFruit();
            CoinFlipFruit();
        }
        for (int jFruit = 1; jFruit < 26; jFruit++)
        {
            GameObject.Find("GamePiece" + jFruit.ToString() + "Fruit").GetComponent<CellFruit>().RefreshSpriteFruit();
            CoinFlipFruit();

        }
        scoreTextFruit.text = "Score:\n" + pointsFruit.ToString();
    }



    void Update()
    {
        if (GameObject.Find("MainCameraFruit").GetComponent<CanvasHolderFruit>().gameCanvasFruit.enabled)
        {
            if ((goalNumberFruit1<1)&&(goalNumberFruit2<1))
            {
                CoinFlipFruit();
                GameObject.Find("MainCameraFruit").GetComponent<CanvasHolderFruit>().MoveFruit("winFruit");
            }
        }

        if (boolFirstFruit && boolSecondFruit)
        {
            CoinFlipFruit();
            boolFirstFruit = false;
            boolSecondFruit = false;
            if (firstClickedFruit != secondClickedFruit) SwapFruit();
            else firstClickedFruit.RefreshSpriteFruit();         
           
        }

        if (firstMoveFinishedFruit && secondMoveFinishedFruit)
        {
            firstMoveFinishedFruit = false;
            secondMoveFinishedFruit = false;
            BigGameCheckFruit();
        }
    }
}
