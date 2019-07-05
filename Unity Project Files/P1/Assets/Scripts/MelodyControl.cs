using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelodyControl : MonoBehaviour //Melody Key object controller in screen
{
    [SerializeField] private GameObject model; //the model of the object
    [SerializeField] private Color color; //target color of the object

    private void Start()
    {
        setInactiveColor(); //set color to inactive
    }

    IEnumerator colorBack() //set color to inactive routine
    {
        yield return new WaitForSeconds(0.1f); //wait for a while
        setInactiveColor(); //set inactive color
    }

    public void setInactiveColor() //set inactive color method
    {
        model.GetComponent<Renderer>().material.color = color / 2; //set inactive color
    }

    public void setActiveColor() //set active color method
    {
        model.GetComponent<Renderer>().material.color = color * 3;//set active color
    }

    public void InstantiateTheMelody() //instantiate melody shaped object
    {
        GameObject melodyObject = Instantiate(G.melodyObject, transform.position+ transform.right * Random.Range(-0.25f, 0.25f) + transform.up * 1f + transform.forward * Random.Range(-0.25f, 0.25f), transform.rotation);
        melodyObject.GetComponent<Renderer>().material.color = color; //set color
        for(int i = 0; i < melodyObject.transform.childCount;  i++) //color each child
        {
            melodyObject.transform.GetChild(i).GetComponent<Renderer>().material.color = color;
        }
        melodyObject.GetComponent<Rigidbody>().AddForce(transform.right * Random.Range(-15f, 15f) - transform.forward * Random.Range(50f, 150f) + transform.up * Random.Range(50f, 75f)); //add velocity
        Destroy(melodyObject, 5); //destroy after 5 seconds

        setActiveColor(); //set active color

        StartCoroutine(colorBack()); //start color back coroutine
    }

    public void InstantiatePlayMelodyObject() //instantiate audio source
    {
        GameObject audio = Instantiate(G.audioObject, transform.position, transform.rotation); //instantiate object

        for (int i = 0; i < G.keys.Count; i++) //for each key
        {
            if (gameObject.Equals(G.keys[i])) //for the matching keyobject
            {
                audio.GetComponent<AudioSource>().clip = G.musics[i]; //set the matching sound clip
                audio.GetComponent<AudioSource>().time = G.startTime[i]; //set the starting time
                audio.GetComponent<AudioSource>().Play(); //play the sound

                //set the last pressed key
                if (gameObject == G.keys[0])
                {
                    G.lastNotePressed = "c5";
                }else if (gameObject == G.keys[1])
                {
                    G.lastNotePressed = "d5";
                }
                else if (gameObject == G.keys[2])
                {
                    G.lastNotePressed = "e5";
                }
                else if (gameObject == G.keys[3])
                {
                    G.lastNotePressed = "f5";
                }
                else if (gameObject == G.keys[4])
                {
                    G.lastNotePressed = "g5";
                }
                else if (gameObject == G.keys[5])
                {
                    G.lastNotePressed = "a5";
                }
                else if (gameObject == G.keys[6])
                {
                    G.lastNotePressed = "b5";
                }
                else if (gameObject == G.keys[7])
                {
                    G.lastNotePressed = "c6";
                }
            }
        }
    }

    public void isExpectedKeyPressed() //check if expected key is pressed
    {
        switch (G.noteToPress) //wait for next key if pressed
        {
            case "c5":
                {
                    if (gameObject == G.keys[0])
                    {
                        G.noteToPress = "";
                    }
                    break;
                }
            case "d5":
                {
                    if (gameObject == G.keys[1])
                    {
                        G.noteToPress = "";
                    }
                    break;
                }
            case "e5":
                {
                    if (gameObject == G.keys[2])
                    {
                        G.noteToPress = "";
                    }
                    break;
                }
            case "f5":
                {
                    if (gameObject == G.keys[3])
                    {
                        G.noteToPress = "";
                    }
                    break;
                }
            case "g5":
                {
                    if (gameObject == G.keys[4])
                    {
                        G.noteToPress = "";
                    }
                    break;
                }
            case "a5":
                {
                    if (gameObject == G.keys[5])
                    {
                        G.noteToPress = "";
                    }
                    break;
                }
            case "b5":
                {
                    if (gameObject == G.keys[6])
                    {
                        G.noteToPress = "";
                    }
                    break;
                }
            case "c6":
                {
                    if (gameObject == G.keys[7])
                    {
                        G.noteToPress = "";
                    }
                    break;
                }
            default:
                break;
        }
    }
}