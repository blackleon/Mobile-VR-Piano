using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioFadeOutAndDestroy : MonoBehaviour //Destory instantiated audio objects by fading out the volume
{
    void Start()
    {
        StartCoroutine(fadeOutAndDestroy()); //start coroutine to destroy the object
    }

    IEnumerator fadeOutAndDestroy() //destroy the object coroutine
    {
        float volume = 1f;
        while(GetComponent<AudioSource>().volume > 0f) //if volume > 0
        {
            GetComponent<AudioSource>().volume = volume; //set audiosource volume
            volume -= 0.1f; //reduce volume
            yield return new WaitForSeconds(0.25f); //wait for a while
        }
        Destroy(gameObject); //destroy the gameobject
    }
}