using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntranceTrigger : MonoBehaviour {

    public Player playerScript;
    public string entranceName;
    public string sceneToEnter;

	// Use this for initialization
	void Start ()
    {
        playerScript = GameObject.Find("Ore").GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerScript.lastDoorUsed = entranceName;
        SceneManager.LoadScene(sceneToEnter); // make scene to change to generic with public string
    }
}
