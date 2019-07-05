using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class G : MonoBehaviour //Global variables
{
    public static string melodyClickMode; //what happens when clicked?
    public static string actionMode; //what is going on?
    public static string noteToPress; //next button on training mode
    public static string lastNotePressed; //last note pressed
    public static string lastRhythm; //last rhythm selected
    public static string melodyBeingMade; //the melody thats being made

    public static GameObject melodyBeingMadeText; //The Text object of melody thats being made
    public static GameObject rhythmToAdd; //note text object
    
    public static List<GameObject> melodies = new List<GameObject>(); //list of the melody objects

    public static GameObject melodyObject; //melody shape prefab
    public static GameObject audioObject; //audio prefab

    public static List<AudioClip> musics; //sound files
    public static List<GameObject> keys; //key objects in screen

    public static float[] startTime = { 0.239f, 0.436f, 0.625f, 0.768f, 0.475f, 0.388f, 0.388f, 0.474f }; //starting sounds for the audio


    //Temp variables to pass on to static ones
    [SerializeField] public List<AudioClip> tempMusics;
    [SerializeField] public List<GameObject> tempKeys;
    [SerializeField] public GameObject tempMelodyObject;
    [SerializeField] public GameObject tempAudioObject;
    [SerializeField] public GameObject tempMelodyBeingMadeText;
    [SerializeField] public GameObject tempRhythmToAdd;

    private void Start()
    {
        melodyBeingMade = ""; //init melody
        lastRhythm = "4"; //init rhythm
        lastNotePressed = ""; //init last note
        melodyClickMode = "OYNAT"; //set click mode to play
        actionMode = "inactive"; //set current action to inactive

        melodyBeingMadeText = tempMelodyBeingMadeText; //temp variable pass
        rhythmToAdd = tempRhythmToAdd; //temp variable pass

        keys = tempKeys; //temp variable pass
        musics = tempMusics; //temp variable pass
        melodyObject = tempMelodyObject; //temp variable pass
        audioObject = tempAudioObject; //temp variable pass

        StartCoroutine(updateMelodyText()); //Update the melody text with melody thats being made
        StartCoroutine(updateRhythmToAdd()); //Update the note to add with selected rhythm and note
    }

    public static void toggleMode() //toggle play or train mode
    {
        if(melodyClickMode == "OYNAT") //if mode is play
        {
            melodyClickMode = "OGRET"; //change it to train
        }else if(melodyClickMode == "OGRET") //if mode is train
        {
            melodyClickMode = "OYNAT"; //change it to play
        }
        actionMode = "inactive"; //reset activity
        noteToPress = ""; //reset next note expected

        foreach(GameObject m in melodies) //foreach melody object on screen
        {
            if(m!=null)
            {
                m.GetComponent<melodyClass>().StopAllCoroutines(); //stop coroutines
            }
        }
    }

    IEnumerator updateMelodyText() //Update the melody text with melody thats being made
    {
        while(true) //forever
        {
            if(melodyBeingMadeText != null) //if text object exists
            {
                melodyBeingMadeText.GetComponent<TextMeshPro>().text = melodyBeingMade; //update melody text
            }
            yield return new WaitUntil(() => (melodyBeingMadeText.GetComponent<TextMeshPro>().text != melodyBeingMade)); //wait till melody string changes
        }
    }

    IEnumerator updateRhythmToAdd() //Update the note to add with selected rhythm and note
    {
        while (true) //forever
        {
            if (rhythmToAdd != null) //if text object exists
            {
                rhythmToAdd.GetComponent<TextMeshPro>().text = lastRhythm + "*" + lastNotePressed; //update note text
            }
            yield return new WaitUntil(() => (rhythmToAdd.GetComponent<TextMeshPro>().text != lastRhythm + "*" + lastNotePressed)); //wait until the string changes
        }
    }

    public static void colorAllKeys() //set all keys to inactive colors
    {
        keys[0].GetComponent<MelodyControl>().setInactiveColor();
        keys[1].GetComponent<MelodyControl>().setInactiveColor();
        keys[2].GetComponent<MelodyControl>().setInactiveColor();
        keys[3].GetComponent<MelodyControl>().setInactiveColor();
        keys[4].GetComponent<MelodyControl>().setInactiveColor();
        keys[5].GetComponent<MelodyControl>().setInactiveColor();
        keys[6].GetComponent<MelodyControl>().setInactiveColor();
        keys[7].GetComponent<MelodyControl>().setInactiveColor();
    }
}
