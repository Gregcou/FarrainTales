using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpawnLocation : MonoBehaviour {

    public GameObject playerObject;
    public Player playerScript;
    public Vector3 westEntranceLocation;
    public Vector3 eastEntranceLocation;

    // Use this for initialization
    void Start ()
    {
        playerObject = GameObject.Find("Ore");
        playerScript = playerObject.GetComponent<Player>();

        if (playerScript.lastDoorUsed == "WestEntrance")
        {
            playerObject.transform.position = westEntranceLocation;
        }
        else if (playerScript.lastDoorUsed == "EastEntrance")
        {
            playerObject.transform.position = eastEntranceLocation;
        }
            
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
