using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour {

    float moveSpeed = 6f;
    Animator PlayerAnimator;
    Rigidbody2D rb2d;
    Vector2 newpos;
    public Inventory inventoryScript;
    public int playerHealth;
    public int playerDamage;

    public EnemyCombat currentEnemyScript;

    public bool moveable = true;

    public bool swordActive = true;
    public SpriteRenderer equippedWeapon;
    public SpriteRenderer unequippedWeapon;
    public int swordDamage;
    public int staffHealAmount;

    public GameObject combatCanvas;

    public string lastDoorUsed;

    // Use this for initialization
    void Start ()
    {
        PlayerAnimator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        equippedWeapon = GameObject.Find("Sword").GetComponent<SpriteRenderer>();
        unequippedWeapon = GameObject.Find("Staff").GetComponent<SpriteRenderer>();
        if (swordActive == true)
        {
            playerDamage += swordDamage;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("TEST2");
        }

            if (Input.GetKeyDown(KeyCode.F))
        {
            if (swordActive == true)
            {
                equippedWeapon.sprite = Resources.Load<Sprite>("Staff");
                unequippedWeapon.sprite = Resources.Load<Sprite>("Sword");
                playerDamage -= swordDamage;
                swordActive = false;
            }
            else if (swordActive == false)
            {
                equippedWeapon.sprite = Resources.Load<Sprite>("Sword");
                unequippedWeapon.sprite = Resources.Load<Sprite>("Staff");
                playerDamage += swordDamage;
                swordActive = true;
            }
        }

        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("TEST1"); // put in death screen (black screen maybe???)
        }

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        newpos = transform.position + new Vector3(moveHorizontal *  moveSpeed * Time.deltaTime, moveVertical * moveSpeed * Time.deltaTime);


        if (moveable == true)
        {

            rb2d.MovePosition(newpos);

            if (moveVertical == -1)
            {
                PlayerAnimator.SetBool("Walking", true);
            }
            else
            {
                PlayerAnimator.SetBool("Walking", false);
            }

            if (moveVertical == 1)
            {
                PlayerAnimator.SetBool("WalkingBack", true);
            }
            else
            {
                PlayerAnimator.SetBool("WalkingBack", false);
            }


            if (moveHorizontal == 1)
            {
                PlayerAnimator.SetBool("WalkingSideRight", true);
            }
            else
            {
                PlayerAnimator.SetBool("WalkingSideRight", false);
            }


            if (moveHorizontal == -1)
            {
                PlayerAnimator.SetBool("WalkingSideLeft", true);
            }
            else
            {
                PlayerAnimator.SetBool("WalkingSideLeft", false);
            }
        }
        

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventoryScript.setSlot(collision.gameObject, true);
        }
        
    }

    public void attack()
    {
        if (currentEnemyScript.playerTurn == true)
        {
            currentEnemyScript.enemyHealth -= playerDamage;
            if (swordActive == false)
            {
                playerHealth += staffHealAmount;
            }

            currentEnemyScript.playerTurn = false;
        }
    }

    public void openInventory()
    {
        if (currentEnemyScript.playerTurn == true)
        {
            currentEnemyScript.inventoryButton1.interactable = true;
            currentEnemyScript.inventoryButton2.interactable = true;
            currentEnemyScript.inventoryButton3.interactable = true;
            currentEnemyScript.inventoryReturnButton.interactable = true;
            currentEnemyScript.attackButton.interactable = false;
            currentEnemyScript.itemsButton.interactable = false;
            currentEnemyScript.inventoryButton1.Select();

        }   
    }

    public void useItemSlot1()
    {
        bool hadItem = false;

        if (inventoryScript.checkSlot(0) == 1)
        {
            if (inventoryScript.checkInventory(1))
            {
                playerHealth += 20;
                hadItem = true;
            }
        }
        else if (inventoryScript.checkSlot(0) == 2)
        {
            // make text to tell user key cannot be used
            hadItem = true;
        }
        else if (inventoryScript.checkSlot(0) == 3)
        {
            if (inventoryScript.checkInventory(3))
            {
                playerDamage += 10;
                hadItem = true;
            }
        }
        else if (inventoryScript.checkSlot(0) == 0)
        {
            hadItem = false;
        }

        if (hadItem == true)
        {
            currentEnemyScript.inventoryButton1.interactable = false;
            currentEnemyScript.inventoryButton2.interactable = false;
            currentEnemyScript.inventoryButton3.interactable = false;
            currentEnemyScript.inventoryReturnButton.interactable = false;
            currentEnemyScript.attackButton.interactable = true;
            currentEnemyScript.itemsButton.interactable = true;
            currentEnemyScript.attackButton.Select();
            currentEnemyScript.playerTurn = false;
        }
    }

    public void useItemSlot2()
    {
        bool hadItem = false;
        if (inventoryScript.checkSlot(1) == 1)
        {
            if (inventoryScript.checkInventory(1))
            {
                playerHealth += 20;
                hadItem = true;
            }
        }
        else if (inventoryScript.checkSlot(1) == 2)
        {
            // make text to tell user door key cannot be used
            hadItem = true;
        }
        else if (inventoryScript.checkSlot(1) == 3)
        {
            if (inventoryScript.checkInventory(3))
            {
                playerDamage += 10;
                hadItem = true;
            }
        }
        else if (inventoryScript.checkSlot(1) == 0)
        {
            hadItem = false;
        }

        if (hadItem == true)
        {
            currentEnemyScript.inventoryButton1.interactable = false;
            currentEnemyScript.inventoryButton2.interactable = false;
            currentEnemyScript.inventoryButton3.interactable = false;
            currentEnemyScript.inventoryReturnButton.interactable = false;
            currentEnemyScript.attackButton.interactable = true;
            currentEnemyScript.itemsButton.interactable = true;
            currentEnemyScript.attackButton.Select();
            currentEnemyScript.playerTurn = false;
        }
    }

    public void useItemSlot3()
    {
        bool hadItem = false;
        if (inventoryScript.checkSlot(2) == 1)
        {
            if (inventoryScript.checkInventory(1))
            {
                playerHealth += 20;
                hadItem = true;
            }
        }
        else if (inventoryScript.checkSlot(2) == 2)
        {
            // make text to tell user key cannot be used
            hadItem = true;
        }
        else if (inventoryScript.checkSlot(2) == 3)
        {
            if (inventoryScript.checkInventory(3))
            {
                playerDamage += 10;
                hadItem = true;
            }
        }
        else if (inventoryScript.checkSlot(2) == 0)
        {
            hadItem = false;
        }

        if (hadItem == true)
        {
            currentEnemyScript.inventoryButton1.interactable = false;
            currentEnemyScript.inventoryButton2.interactable = false;
            currentEnemyScript.inventoryButton3.interactable = false;
            currentEnemyScript.inventoryReturnButton.interactable = false;
            currentEnemyScript.attackButton.interactable = true;
            currentEnemyScript.itemsButton.interactable = true;
            currentEnemyScript.attackButton.Select();
            currentEnemyScript.playerTurn = false;
        }
    }

    public void closeInventory()
    {
        currentEnemyScript.inventoryButton1.interactable = false;
        currentEnemyScript.inventoryButton2.interactable = false;
        currentEnemyScript.inventoryButton3.interactable = false;
        currentEnemyScript.inventoryReturnButton.interactable = false;
        currentEnemyScript.attackButton.interactable = true;
        currentEnemyScript.itemsButton.interactable = true;
        currentEnemyScript.attackButton.Select();
    }

}
