﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishCreator : MonoBehaviour {

    public GameObject jellyFish;
    private int i = 0;
    
    // Use this for initialization
	void Start () 
    {
        InvokeRepeating("CreateJellyFish", 1.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}

    private float RandomPos(float posFloat)
    {
        if (Mathf.Approximately(this.gameObject.transform.forward.x, -1.0f)
            || Mathf.Approximately(this.gameObject.transform.forward.z, -1.0f))
            return Random.Range(posFloat, posFloat - 50.0f);
        else
            return Random.Range(posFloat, posFloat + 50.0f);
    }

    private void CreateJellyFish()
    {
        //Debug.Log("Instantiate" + i);
        i++;
        //Debug.Log("Forward.x is: " + this.gameObject.transform.forward.x);
        //Debug.Log("Forward.z is: " + this.gameObject.transform.forward.z);

        if (Mathf.Approximately(this.gameObject.transform.forward.x, 1.0f))
        {
            Instantiate(jellyFish, new Vector3(RandomPos(this.gameObject.transform.position.x + 50.0f), this.gameObject.transform.position.y,
                this.gameObject.transform.position.z), Quaternion.identity);

            //Debug.Log("Forward.x is: " + this.gameObject.transform.forward);
        }
        
        if (Mathf.Approximately(this.gameObject.transform.forward.z, 1.0f))
        {
            Instantiate(jellyFish, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y,
                RandomPos(this.gameObject.transform.position.z + 50.0f)), Quaternion.identity);

            //Debug.Log("Forward.x is: " + this.gameObject.transform.forward);
        }
        
        if (Mathf.Approximately(this.gameObject.transform.forward.x, -1.0f))
        {
            Instantiate(jellyFish, new Vector3(RandomPos(this.gameObject.transform.position.x - 100.0f), this.gameObject.transform.position.y,
                this.gameObject.transform.position.z), Quaternion.identity);

            //Debug.Log("Forward.x is: " + this.gameObject.transform.forward);
        }
        
        if (Mathf.Approximately(this.gameObject.transform.forward.z, -1.0f))
        {
            Instantiate(jellyFish, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y,
                RandomPos(this.gameObject.transform.position.z - 100.0f)), Quaternion.identity);

            Debug.Log("Forward.x is: " + this.gameObject.transform.forward);
        }
    }
}
