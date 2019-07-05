using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melodyClass : MonoBehaviour //melody object controller
{
    public string name; //name of the melody
    public string melody; //melody saved for the melody object

    private void Start()
    {
        G.melodies.Add(gameObject); //add this to the melodies list
        StartCoroutine(lookAtCamera()); //make it look at the camera
    }

    IEnumerator lookAtCamera() //look at the camera coroutine
    {
        while(true) //forever
        {
            transform.rotation = Quaternion.LookRotation(transform.position - GameObject.Find("Player").transform.position, transform.up); //look at the camera
            yield return new WaitForSeconds(5f); //sleep 5 seconds
        }
    }

    IEnumerator playMelody() //play melody coroutine
    {
        G.actionMode = "active"; //set mode to active

        while(G.actionMode == "active") //if mode is active
        {
            string[] notes = melody.Split(','); //split melody into notes

            foreach (string note in notes) //for each note
            {
                if(note != "") //if note is valid
                {
                    string[] timeandnote = note.Split('*'); //split note into rhythm and note
                    switch (timeandnote[1]) //play the matching note and instantiate melody shape object
                    {
                        case "c5":
                            {
                                G.keys[0].GetComponent<MelodyControl>().InstantiateTheMelody();
                                G.keys[0].GetComponent<MelodyControl>().InstantiatePlayMelodyObject();
                                break;
                            }
                        case "d5":
                            {
                                G.keys[1].GetComponent<MelodyControl>().InstantiateTheMelody();
                                G.keys[1].GetComponent<MelodyControl>().InstantiatePlayMelodyObject();
                                break;
                            }
                        case "e5":
                            {
                                G.keys[2].GetComponent<MelodyControl>().InstantiateTheMelody();
                                G.keys[2].GetComponent<MelodyControl>().InstantiatePlayMelodyObject();
                                break;
                            }
                        case "f5":
                            {
                                G.keys[3].GetComponent<MelodyControl>().InstantiateTheMelody();
                                G.keys[3].GetComponent<MelodyControl>().InstantiatePlayMelodyObject();
                                break;
                            }
                        case "g5":
                            {
                                G.keys[4].GetComponent<MelodyControl>().InstantiateTheMelody();
                                G.keys[4].GetComponent<MelodyControl>().InstantiatePlayMelodyObject();
                                break;
                            }
                        case "a5":
                            {
                                G.keys[5].GetComponent<MelodyControl>().InstantiateTheMelody();
                                G.keys[5].GetComponent<MelodyControl>().InstantiatePlayMelodyObject();
                                break;
                            }
                        case "b5":
                            {
                                G.keys[6].GetComponent<MelodyControl>().InstantiateTheMelody();
                                G.keys[6].GetComponent<MelodyControl>().InstantiatePlayMelodyObject();
                                break;
                            }
                        case "c6":
                            {
                                G.keys[7].GetComponent<MelodyControl>().InstantiateTheMelody();
                                G.keys[7].GetComponent<MelodyControl>().InstantiatePlayMelodyObject();
                                break;
                            }
                        default:
                            break;
                    }
                    yield return new WaitForSeconds(4f / float.Parse(timeandnote[0]) - Time.fixedDeltaTime); //wait for rhythm amount of time
                    yield return new WaitForFixedUpdate();
                }

            }
            G.actionMode = "inactive"; //set mode to inactive
        }
    }

    IEnumerator trainMelody() //train melody coroutine
    {
        G.actionMode = "active"; //set mode to active
        while(G.actionMode == "active") //if mode is active
        {
            string[] notes = melody.Split(','); //split melody in notes
            foreach (string note in notes) //foreach note
            {
                if (note != "") //if note is valid
                {
                    string[] timeandnote = note.Split('*'); //split note in rhythm and note
                    switch (timeandnote[1]) //color the matching note to active color and set the expected note
                    {
                        case "c5":
                            {
                                G.keys[0].GetComponent<MelodyControl>().setActiveColor();
                                G.noteToPress = timeandnote[1];
                                break;
                            }
                        case "d5":
                            {
                                G.keys[1].GetComponent<MelodyControl>().setActiveColor();
                                G.noteToPress = timeandnote[1];
                                break;
                            }
                        case "e5":
                            {
                                G.keys[2].GetComponent<MelodyControl>().setActiveColor();
                                G.noteToPress = timeandnote[1];
                                break;
                            }
                        case "f5":
                            {
                                G.keys[3].GetComponent<MelodyControl>().setActiveColor();
                                G.noteToPress = timeandnote[1];
                                break;
                            }
                        case "g5":
                            {
                                G.keys[4].GetComponent<MelodyControl>().setActiveColor();
                                G.noteToPress = timeandnote[1];
                                break;
                            }
                        case "a5":
                            {
                                G.keys[5].GetComponent<MelodyControl>().setActiveColor();
                                G.noteToPress = timeandnote[1];
                                break;
                            }
                        case "b5":
                            {
                                G.keys[6].GetComponent<MelodyControl>().setActiveColor();
                                G.noteToPress = timeandnote[1];
                                break;
                            }
                        case "c6":
                            {
                                G.keys[7].GetComponent<MelodyControl>().setActiveColor();
                                G.noteToPress = timeandnote[1];
                                break;
                            }
                        default:
                            G.noteToPress = "ThisWillBeSkipped";
                            break;
                    }
                    yield return new WaitUntil(() => G.noteToPress != timeandnote[1]); //wait till the note is pressed
                    yield return new WaitForSeconds(4f / float.Parse(timeandnote[0]) - Time.fixedDeltaTime); //wait till rhythm amount of time
                    yield return new WaitForFixedUpdate();
                }
                
            }
            G.actionMode = "inactive"; //set mode to inactive
        }
    }

    public void melodyClickEvent() //clicking on melody method
    {
        if(G.actionMode == "inactive") //if action mode is inactive
        {
            if(G.melodyClickMode == "OGRET") //if train mode is active
            {
                StartCoroutine(trainMelody()); //train
            }
            else //if not
            {
                StartCoroutine(playMelody()); //play
            }
        }
    }

    public void deleteMelodyFromSavedOnes() //delete the object from playerperfs
    {
        PlayerPrefs.DeleteKey(name);
        Destroy(gameObject);
    }

    public void destroyMe() //destroy gameobject
    {
        Destroy(gameObject);
    }
}