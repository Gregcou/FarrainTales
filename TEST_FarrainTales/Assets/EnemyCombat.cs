using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EnemyCombat : MonoBehaviour {

    public bool inRange = false;
    public GameObject combatCanvas;

    public int enemyHealth;
    public int enemyDamage; // maybe set damage and health by name of enemy

    public Player playerScript;
    public Text enemyHealthText;
    public Text playerHealthText;
    public bool inCombat;
    public Animator playerAnimator;

    public bool playerTurn = true;

    public SpriteRenderer enemySR;
    public SpriteRenderer combatSpriteSR;

    public Button attackButton;

    EventSystem eventSystem;
    GameObject selectedObject;

    Inventory inventoryScript;
    public Text inventoryButtonText1;
    public Text inventoryButtonText2;
    public Text inventoryButtonText3;

    public Button inventoryButton1;
    public Button inventoryButton2;
    public Button inventoryButton3;
    public Button inventoryReturnButton;

    public Button itemsButton;

    // Use this for initialization
    void Start ()
    {
        playerScript = GameObject.Find("Ore").GetComponent<Player>();
        playerAnimator = GameObject.Find("Ore").GetComponent<Animator>();
        enemySR = gameObject.transform.parent.gameObject.GetComponent<SpriteRenderer>();
        inventoryScript = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        combatCanvas = playerScript.combatCanvas;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (inRange == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (inCombat == false)
                {
                    playerScript.currentEnemyScript = this;
                    combatCanvas.SetActive(true);
                    combatSpriteSR = GameObject.Find("CurrentCombatSprite").GetComponent<SpriteRenderer>();
                    combatSpriteSR.sprite = Resources.Load<Sprite>(enemySR.sprite.name);
                    enemyHealthText = GameObject.Find("CurrentEnemyHealth").GetComponent<Text>();
                    playerHealthText = GameObject.Find("PlayerHealth").GetComponent<Text>();

                    attackButton = GameObject.Find("AttackButton").GetComponent<Button>();
                    attackButton.Select();

                    inventoryButton1 = GameObject.Find("InventorySlot1Button").GetComponent<Button>();
                    inventoryButton2 = GameObject.Find("InventorySlot2Button").GetComponent<Button>();
                    inventoryButton3 = GameObject.Find("InventorySlot3Button").GetComponent<Button>();
                    inventoryReturnButton = GameObject.Find("InventoryReturnButton").GetComponent<Button>();

                    itemsButton = GameObject.Find("ItemsButton").GetComponent<Button>();


                    inventoryButtonText1 = GameObject.Find("InventorySlot1Button").GetComponentInChildren<Text>();
                    inventoryButtonText2 = GameObject.Find("InventorySlot2Button").GetComponentInChildren<Text>();
                    inventoryButtonText3 = GameObject.Find("InventorySlot3Button").GetComponentInChildren<Text>();

                    inCombat = true;
                    playerAnimator.SetBool("Walking", false);
                    playerAnimator.SetBool("WalkingBack", false);
                    playerAnimator.SetBool("WalkingSideRight", false);
                    playerAnimator.SetBool("WalkingSideLeft", false);
                } 
            }

            if (inCombat == true)
            {
                enemyHealthText.text = enemyHealth.ToString();
                playerHealthText.text = playerScript.playerHealth.ToString();
                inventoryButtonText1.text = inventoryScript.itemNames[0];
                inventoryButtonText2.text = inventoryScript.itemNames[1];
                inventoryButtonText3.text = inventoryScript.itemNames[2];
                playerScript.moveable = false;
                if (playerTurn == false)
                {
                    playerScript.playerHealth -= enemyDamage;
                    playerTurn = true;
                }

                if (EventSystem.current.currentSelectedGameObject == null)
                {
                    EventSystem.current.SetSelectedGameObject(selectedObject);
                }

                selectedObject = EventSystem.current.currentSelectedGameObject;
            }
        }


        if (enemyHealth <= 0)
        {
            combatCanvas.SetActive(false);
            Destroy(gameObject.transform.parent.gameObject);
            playerScript.moveable = true;
            combatSpriteSR.sprite = null;
        }
	}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Ore")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Ore")
        {
            inRange = false;
        }
    }
}

