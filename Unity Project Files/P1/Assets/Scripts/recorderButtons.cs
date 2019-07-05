using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recorderButtons : MonoBehaviour //record processes button controller
{

    public void resetTheLastNote() //reset the last note method
    {
        G.lastNotePressed = "";
    }

    public void resetTheMelody() //reset the melody method
    {
        G.melodyBeingMade = "";
    }

    public void setTheRhythm(int rhythm) //set the rhythm method
    {
        G.lastRhythm = rhythm.ToString();
    }

    public void removeLastFromTheMelody() //method to remove last note
    {
        string[] melody = G.melodyBeingMade.Split(','); //split notes
        int numberOfNotes = melody.Length;

        if (numberOfNotes > 0) //if there are at least 1 note
        {
            G.melodyBeingMade = "";
            for (int i = 0; i < numberOfNotes - 2; i++)
            {
                G.melodyBeingMade += melody[i] + ","; //re write notes except last one
            }
        }
    }

    public void addNoteToTheMelody() //add the note to melody with rhythm
    {
        G.melodyBeingMade += G.lastRhythm + "*" + G.lastNotePressed + ",";
    }

    public void attachTheMelodyToMe() //update test melody's melody string
    {
        if(gameObject.GetComponent<melodyClass>() != null)
        {
            gameObject.GetComponent<melodyClass>().melody = G.melodyBeingMade;
        }
    }

    public void recordTheMelodyToPlayerPrefs() //save the melody to playerprefs
    {
        string name = "melody";
        for(int i = 0; i< 36; i++) 
        {
            if(!PlayerPrefs.HasKey(name + (i+1))) //for the first empty spot
            {
                PlayerPrefs.SetString(name + (i + 1), name + (i+1) + "#" + G.melodyBeingMade); //placethe melody
                G.melodyBeingMade = ""; //reset the string
                break;
            }
        }
    }

    public void quitGame() //quit game!
    {
        Application.Quit();
    }
}