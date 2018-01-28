using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishController : MonoBehaviour {

    private bool isTurnedDown;
    private bool isUnderTerrain;
    // Use this for initialization
	void Start () 
    {
        isTurnedDown = false;
        isUnderTerrain = false;
        
        this.gameObject.GetComponent<Rigidbody>().velocity
            = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, 2.0f, gameObject.GetComponent<Rigidbody>().velocity.z);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(this.gameObject.transform.position.y >= 20.0f && !isTurnedDown)
        {
            isTurnedDown = true;

            this.gameObject.GetComponent<Rigidbody>().velocity
            = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, -2.0f, gameObject.GetComponent<Rigidbody>().velocity.z);
        }

        if(this.gameObject.transform.position.y <= -20.0f && !isUnderTerrain)
        {
            isUnderTerrain = true;
            Destroy(this.gameObject, 3.0f);
        }
		
	}
}
