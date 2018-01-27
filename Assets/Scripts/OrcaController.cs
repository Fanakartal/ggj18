using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcaController : MonoBehaviour 
{
    public float jumpSpeed = 50f;
    public float moveSpeed = 10f;

    private Transform from;
    public Transform up;
    public Transform down;

    private Vector3 _newPosition;

	// Use this for initialization
	void Start () 
    {
        from = transform;// new Vector3(0.0f, 0.0f, 0.0f);
        
        this.gameObject.GetComponent<Rigidbody>().velocity 
            = new Vector3(moveSpeed, gameObject.GetComponent<Rigidbody>().velocity.y, gameObject.GetComponent<Rigidbody>().velocity.z);
	}
	
	// Update is called once per frame
	void Update () 
    {
        _newPosition = transform.position;
        _newPosition.y += 2 * Mathf.Sin(Time.time) * Time.deltaTime;
        transform.position = _newPosition;

        //gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed, ForceMode.Acceleration);
        
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            transform.rotation = Quaternion.Lerp(from.rotation, up.rotation, Time.time * 0.01f);
            //transform.Rotate(45.0f, transform.rotation.y, transform.rotation.z);
            
            //gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed, ForceMode.Acceleration);// new Vector3(transform.forward * moveSpeed, jumpSpeed, 0.0f));
                
            // velocity = new Vector3(moveSpeed, jumpSpeed, gameObject.GetComponent<Rigidbody>().velocity.z);
        }

        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            transform.rotation = Quaternion.Lerp(from.rotation, down.rotation, Time.time * 0.1f);
            //transform.Rotate(45.0f, transform.rotation.y, transform.rotation.z);

            //gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed, ForceMode.Acceleration);// new Vector3(transform.forward * moveSpeed, jumpSpeed, 0.0f));

            // velocity = new Vector3(moveSpeed, jumpSpeed, gameObject.GetComponent<Rigidbody>().velocity.z);
        }

        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward * moveSpeed, ForceMode.Acceleration); //new Vector3(-moveSpeed, jumpSpeed, 0.0f));

            // velocity = new Vector3(moveSpeed, jumpSpeed, gameObject.GetComponent<Rigidbody>().velocity.z);
        }

        if((Input.GetKeyDown(KeyCode.D) && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.LeftArrow))))
        {
            transform.Rotate(transform.rotation.x * 45.0f, transform.rotation.y, transform.rotation.z);
        }
	}
}
