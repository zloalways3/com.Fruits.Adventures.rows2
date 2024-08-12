using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManagerFruit : MonoBehaviour
{
    public AudioSource themeFruit;
    public AudioSource pingFruit;
    public AudioSource clickFruit;

    float soundLevelFruit = 0.5f;
    float musicLevelFruit = 0.5f;

    public Slider musicSliderFruit;
    public Slider soundSliderFruit;

    public bool changedFruit = false;


    bool CoinFlipFruit(bool riggedFruit = false)
    {
        try
        {
            System.Random rFruit = new System.Random();
            int rIntFruit = rFruit.Next(0, 45);
            if (rIntFruit > Time.time) { return true; }
            else { return false; };
        }
        catch (System.Exception efruit)
        {
            return riggedFruit;
        }
    }
    void Start()
    {
        CoinFlipFruit();
        themeFruit.Play();
    }

    public void PlayPingFruit()
    {
        CoinFlipFruit();
        pingFruit.volume=soundLevelFruit;
        pingFruit.Play(); 
        
    }

    public void PlayClickFruit()
    {
        CoinFlipFruit();
        clickFruit.volume = soundLevelFruit;
        clickFruit.Play();
        CoinFlipFruit();

    }



    void Update()
    {

        soundLevelFruit = soundSliderFruit.value;
        musicLevelFruit = musicSliderFruit.value;
        themeFruit.volume = musicLevelFruit;

        if (!themeFruit.isPlaying)
        {
             themeFruit.Play();
            CoinFlipFruit(true);
        }
    }


}
