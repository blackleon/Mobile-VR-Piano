using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class defaultMelodies : MonoBehaviour //set the default melodies and instantiate melody objects controller
{
    public GameObject melodySavedObject; //melody prefab
    public GameObject centerObject; //center of the scene object
    static int numberOfDefaultMelodies = 6; //predefined melodies number

    //predefined melodies
    string[] melody = new string[] {
    "Yilan Hikayesi#16*d5,16*e5,16*f5,16*g5,16*a5,8*,16*a5,16*g5,16*g5,16*f5,16*g5,16*f5,16*g5,16*a5,16*g5,8*,16*g5,16*f5,16*f5,16*e5,16*f5,16*e5,16*f5,16*g5,16*f5,8*,16*f5,16*e5,16*e5,16*d5,16*e5,16*d5,16*e5,16*f5,16*e5,8*,16*e5,16*d5,16*d5,16*c5,16*d5,16*c5,16*d5,16*e5,16*d5"
    ,
    "Daha Dün Annemizin#8*c5,8*c5,8*g5,8*g5,8*a5,8*a5,8*g5,8*,8*f5,8*f5,8*e5,8*e5,8*d5,8*d5,8*c5,8*,8*c5,8*c5,8*g5,8*g5,8*a5,8*a5,8*g5,8*,8*f5,8*f5,8*e5,8*e5,8*d5,8*d5,8*c5,8*,8*g5,8*g5,8*f5,8*f5,8*e5,8*e5,8*d5,8*,8*g5,8*g5,8*f5,8*f5,8*e5,8*e5,8*d5,8*,8*c5,8*c5,8*g5,8*g5,8*a5,8*a5,8*g5,8*,8*f5,8*f5,8*e5,8*e5,8*d5,8*d5,8*c5,8*"
    ,
    "Mutlu Yillar#16*c5,16*c5,8*d5,8*c5,8*f5,8*e5,8*,16*c5,16*c5,8*d5,8*c5,8*g5,8*f5,8*,16*c5,16*c5,8*a5,8*f5,8*e5,8*d5,8*c5,16*,16*a5,16*a5,8*g5,8*f5,8*g5,8*f5"
    ,
    "Yalanci#16*a5,16*a5,16*g5,16*,16*a5,16*a5,16*g5,16*,16*f5,16*g5,16*f5,16*g5,16*a5,16*a5,16*g5,16*,16*a5,16*a5,16*g5,16*,16*a5,16*a5,16*g5,16*,16*f5,16*g5,16*f5,16*g5,16*a5,16*a5,16*g5"
    ,
    "This Old Man#8*g5,8*e5,8*g5,8*,8*g5,8*e5,8*g5,8*,8*a5,8*g5,8*f5,8*e5,8*d5,8*e5,8*f5,16*e5,16*f5,8*g5,8*c5,8*c5,8*c5,16*c5,16*d5,16*e5,16*f5,8*g5,8*,8*g5,8*d5,8*d5,8*f5,8*e5,8*d5,8*c5"
    ,
    "9. Senfoni#16*e5,16*e5,16*f5,16*g5,16*g5,16*f5,16*e5,16*d5,16*c5,16*c5,16*d5,16*e5,16*,16*d5,8*,16*e5,16*e5,16*f5,16*g5,16*g5,16*f5,16*e5,16*d5,16*c5,16*c5,16*d5,16*e5,16*d5,16*,32*c5,32*c5,8*,8*d5,16*e5,16*c5,16*d5,32*e5,32*f5,16*e5,16*c5,16*,16*d5,16*e5,16*f5,16*e5,16*d5,16*c5,16*d5,16*c5,16*,16*e5,16*,8*,16*e5,16*f5,16*g5,16*g5,16*f5,16*e5,16*d5,16*c5,16*c5,16*d5,16*e5,16*d5,16*,32*c5,32*c5,"
    };

    private void Start()
    {
        createMelodyObjects(); //start create melody objects coroutine
    }

    public void createMelodyObjects() //create melody objects coroutine
    {
        string name = "melody"; //default playerpref name
        for (int i = 0; i < numberOfDefaultMelodies; i++) //for numbers of predefined melodies
        {
            PlayerPrefs.SetString(name + (i + 1), melody[i]); //save the melody
        }

        for (int i = centerObject.transform.childCount; i>0; i--) //for number of melody objects in scene
        {
            centerObject.transform.GetChild(i-1).GetComponent<melodyClass>().destroyMe(); //destroy instantiated melodyobjects
        }

        int counter = 0; //counter for instantiated objects
        
        for (int i = 0; i < 36; i++) //instantiate existing playerprefab melodies
        {
            if (PlayerPrefs.HasKey(name + (i + 1))) //if melody exists
            {
                counter++; //increase count
                string loadedMelody = PlayerPrefs.GetString(name + (i + 1)); //load melody
                string[] nameNmelody = loadedMelody.Split('#'); //split for getting the name

                GameObject melodyInstantiated = Instantiate(melodySavedObject, new Vector3(0f, 5f, 6f), transform.rotation); //instantiate object
                melodyInstantiated.transform.parent = centerObject.transform; //set objects parent object
                melodyInstantiated.transform.GetChild(1).GetComponent<TextMeshPro>().text = nameNmelody[0]; //set melody text to melody name
                melodyInstantiated.GetComponent<melodyClass>().name = name + (i + 1); //set melodyclass name variable
                melodyInstantiated.GetComponent<melodyClass>().melody = nameNmelody[1]; //set melody class melody variable
                centerObject.transform.Rotate(0f, 10f, 0f); //rotate the melodies 10 degrees
            }
        }

        for (; counter >= 0; counter--) //for number of instantiated melody objects
        {
            centerObject.transform.Rotate(0f, -5f, 0f); //rotate the melodies till facing the middle of them
        }
    }
}