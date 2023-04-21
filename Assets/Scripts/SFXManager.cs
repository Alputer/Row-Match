using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    public static SFXManager instance;

    public AudioSource swipeSound, matchSound, celebrationSound, gameEndLosingSound;

    void Awake(){

        instance = this;

    }

    public void playSwipeSound(){

        swipeSound.Stop();

        swipeSound.pitch = Random.Range(0.8f, 1.2f);

        swipeSound.Play();

    }

    public void playMatchSound(){

        matchSound.Stop();

        matchSound.pitch = Random.Range(0.8f, 1.2f);

        matchSound.Play();

    }

    public void playGameEndLosingSound(){

        
        gameEndLosingSound.Play();

    }

}
