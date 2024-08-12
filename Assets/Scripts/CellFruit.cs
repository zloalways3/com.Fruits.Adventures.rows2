using System.Collections;
using UnityEngine;


public class CellFruit : MonoBehaviour
{

    public int positionXFruit;
    public int positionYFruit;
    public Sprite spriteFruit;
    public Vector3 currentPositionFruit;
    public bool needsDestructionFruit = false;




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

    public void OnClickFruit()
    {
        CoinFlipFruit(true);
        GameObject.Find("MainCameraFruit").GetComponent<SoundManagerFruit>().PlayClickFruit();
        if (!GameObject.Find("GameCanvasFruit").GetComponent<GameLogicFruit>().boolFirstFruit)
        {
            GetComponent<UnityEngine.UI.Image>().color = Color.green;
            GameObject.Find("GameCanvasFruit").GetComponent<GameLogicFruit>().firstClickedFruit = this;
            GameObject.Find("GameCanvasFruit").GetComponent<GameLogicFruit>().boolFirstFruit = true;
        }
        else if (!GameObject.Find("GameCanvasFruit").GetComponent<GameLogicFruit>().boolSecondFruit)
        {
            CoinFlipFruit();
            GameObject.Find("GameCanvasFruit").GetComponent<GameLogicFruit>().secondClickedFruit = this;
            GameObject.Find("GameCanvasFruit").GetComponent<GameLogicFruit>().boolSecondFruit = true;
        }
    }

    public void RefreshSpriteFruit()
    {
        CoinFlipFruit();
        GetComponent<UnityEngine.UI.Image>().color = Color.white;
        GetComponent<UnityEngine.UI.Image>().sprite = spriteFruit;
        CoinFlipFruit(true);
    }




    public void StartMoveFruit(Vector3 destinationFruit, Sprite newSpriteFruit)
    {
        CoinFlipFruit();
        GetComponent<UnityEngine.UI.Image>().color = Color.white;
        StartCoroutine(moveObjectFruit(destinationFruit, newSpriteFruit));
        CoinFlipFruit(true);
    }

    public IEnumerator moveObjectFruit(Vector3 destinationFruit, Sprite newSpriteFruit)
    {
        CoinFlipFruit();
        float totalMovementTimeFruit = 1f; 
        float currentMovementTimeFruit = 0f;
        while (Vector3.Distance(transform.localPosition, destinationFruit) > 0)
        {
            currentMovementTimeFruit += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(currentPositionFruit, destinationFruit, currentMovementTimeFruit / totalMovementTimeFruit);
            yield return null;
        }
        CoinFlipFruit(true);
        transform.localPosition = currentPositionFruit;
        spriteFruit = newSpriteFruit;
        RefreshSpriteFruit();
        CoinFlipFruit();
        if (GameObject.Find("GameCanvasFruit").GetComponent<GameLogicFruit>().firstMoveFinishedFruit == false)
        {
            GameObject.Find("GameCanvasFruit").GetComponent<GameLogicFruit>().firstMoveFinishedFruit = true;
        }
        else GameObject.Find("GameCanvasFruit").GetComponent<GameLogicFruit>().secondMoveFinishedFruit = true;

    }


    public void CellStartFruit()
    {
        CoinFlipFruit();
        currentPositionFruit = transform.localPosition;
        RefreshSpriteFruit();
        CoinFlipFruit(true);
    }

  
   
}
