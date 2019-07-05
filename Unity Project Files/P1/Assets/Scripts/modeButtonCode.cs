using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class modeButtonCode : MonoBehaviour //toggle between record and play/train mode button controller
{
    public GameObject melodyController; //melody controller object

    public bool isPlayModeButton; //is this attached to a button
    public GameObject record; //objects while recording
    public GameObject action; //objects while not recording

    private void Start()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - GameObject.Find("Player").transform.position, transform.up); //look at player
        if (isPlayModeButton)
        {
            transform.GetChild(0).GetComponent<TextMeshPro>().text = "OYNAT"; //set the text to play if its a button
        }
    }

    public void toggleModeAndText() //toggle the mode and the text on button
    {
        G.toggleMode(); //toggle mode
        G.colorAllKeys(); //color keys to inactive
        transform.GetChild(0).GetComponent<TextMeshPro>().text = G.melodyClickMode; //set button text
    }

    public void toggleRecordMode() //set the record mode
    {
        melodyController.GetComponent<defaultMelodies>().createMelodyObjects(); //instantiate the melody objects
        record.gameObject.SetActive(!record.gameObject.activeSelf); //toggle record objects' activity
        action.gameObject.SetActive(!action.gameObject.activeSelf); //toggle action objects' activity
    }
}