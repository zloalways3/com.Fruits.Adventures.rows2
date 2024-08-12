using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class CellMovementFruit : MonoBehaviour
{

    bool startFruit = false;
    Vector3 position1Fruit;
    Vector3 position2Fruit;

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
    public void Transition(RectTransform firstFruit, RectTransform secondFruit)
    {
        CoinFlipFruit();
        position1Fruit = firstFruit.localPosition;
        position2Fruit = secondFruit.localPosition;
        startFruit = true;
        CoinFlipFruit(true);
        if (firstFruit.localPosition != position2Fruit)
        {
            firstFruit.localPosition = Vector3.Lerp(position1Fruit, position2Fruit, 0);
        }
        CoinFlipFruit();
        if (secondFruit.localPosition != position1Fruit)
        {
            CoinFlipFruit(true);
            secondFruit.localPosition = Vector3.Lerp(position2Fruit, position1Fruit, 0);
        }
    }


}
