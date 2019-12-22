using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour {

    public GameObject door;
    bool doorIsOpen = false;
    public Inventory inventoryScript;
    public AudioSource soundBaloon;
    public AudioSource soundChimes;
    InteractableArea buttonDialogueScript;
    public DialogueManager dm;

    BoxCollider2D buttonBoxCollider;

    public int counter = 0;

    // Use this for initialization
    void Start ()
    {
        buttonDialogueScript = GetComponentInParent<InteractableArea>();
        dm = FindObjectOfType<DialogueManager>();
        inventoryScript = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        soundBaloon = GameObject.Find("Windows Balloon").GetComponent<AudioSource>();
        soundChimes = GameObject.Find("chimes").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (buttonDialogueScript.inRange == true)
        {
            if (doorIsOpen == false)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (dm.onYes == true)
                    {
                        if (inventoryScript.checkInventory(2) == true)
                        {
                            door.SetActive(false);
                            doorIsOpen = true;
                            buttonDialogueScript.hasYesNoChoice = false;
                            soundChimes.Play();
                        }
                        else
                        {
                            soundBaloon.Play();
                        }
                    }
                }
            }
            else if (doorIsOpen == true && Input.GetKeyDown(KeyCode.Space))
            {
                if (counter == 0)
                {
                    buttonDialogueScript.changeDialogue("The door is already open", 0);
                }
                else if (counter == 1)
                {
                    buttonDialogueScript.changeDialogue("Just go through", 0);
                }
                else if (counter == 5)
                {
                    buttonDialogueScript.changeDialogue("Please (^_^)", 0);
                }

                if (counter < 5)
                {
                    counter++;
                }
            }
        }
    }


}




/*void Update ()
    {
        if (buttonDialogueScript.inRange == true)
        {
            if (doorIsOpen == false)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {

                    if (yesNoOpen == true)
                    {
                        Debug.Log("checkInventory");
                        dm.yesNoText.SetActive(false);
                        yesNoOpen = false;
                        dm.yesNoOpen = false;
                        if (dm.onYes == true)
                        {
                            if (inventoryScript.checkInventory(2) == true)
                            {
                                door.SetActive(false);
                                doorIsOpen = true;
                                soundChimes.Play();
                            }
                            else
                            {
                                soundBaloon.Play();
                            }
                        }
                    }
                    else if(yesNoOpen == false)
                    {
                        dm.openYesNoOption();
                        yesNoOpen = true;
                        dm.playerMovementScript.enabled = false;
                        Debug.Log("openYesNo");
                    }
                }
            }
            else if (doorIsOpen == true && Input.GetKeyDown(KeyCode.Space))
            {
                if (counter == 0)
                {
                    buttonDialogueScript.changeDialogue("The door is already open", 0);
                }
                else if (counter == 1)
                {
                    buttonDialogueScript.changeDialogue("Just go through", 0);
                }
                else if (counter == 5)
                {
                    buttonDialogueScript.changeDialogue("Please (^_^)", 0);
                }

                if (counter < 5)
                {
                    counter++;
                }         
            }
        } 
	}
*/