using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcaController : MonoBehaviour 
{
    public float jumpSpeed = 50f;
    public float moveSpeed = 10f;

    private bool isFacingUp;
    private bool isFacingDown;

    private Transform from;
    public Transform up;
    public Transform down;

    private Vector3 _newPosition;
    private bool doesMoveRight;
    private bool canTurn;
    private int horizontalAxis;

    public FacingDirection facingDirection;

    public enum FacingDirection
    {
        Right = 0,
        Front = 1,
        Left = 2,
        Back = 3
    }

	// Use this for initialization
	void Start () 
    {
        from = transform;// new Vector3(0.0f, 0.0f, 0.0f);
        
        this.gameObject.GetComponent<Rigidbody>().velocity 
            = new Vector3(moveSpeed, gameObject.GetComponent<Rigidbody>().velocity.y, gameObject.GetComponent<Rigidbody>().velocity.z);

        doesMoveRight = true;
        canTurn = true;

        facingDirection = FacingDirection.Right;
	}
	
	// Update is called once per frame
	void Update () 
    {
        SinusMovement();

        if(doesMoveRight)
        {
            if (Input.GetAxis("Vertical") > 0.0f)// (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
            {
                MoveUp();
            }

            if (Input.GetAxis("Vertical") < 0.0f)// ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
            {
                MoveDown();
            }

            // Right -> Back, Front
            if(Input.GetAxis("Horizontal") > 0 && facingDirection == FacingDirection.Right)
            {
                StartCoroutine(TurnRight());
                
            }
            else if (Input.GetAxis("Horizontal") < 0 && facingDirection == FacingDirection.Right)
            {
                StartCoroutine(TurnLeft());
            }

            // Back -> Right, Left
            else if (Input.GetAxis("Horizontal") > 0 && facingDirection == FacingDirection.Back)
            {
                StartCoroutine(TurnRight());

            }
            else if (Input.GetAxis("Horizontal") < 0 && facingDirection == FacingDirection.Back)
            {
                StartCoroutine(TurnLeft());
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                FireSonar();
            }
        }
        //transform.rotation = Quaternion.Lerp(from.rotation, up.rotation, Time.time * 0.1f);

        //gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed, ForceMode.Acceleration);
        
        /*if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            transform.Rotate(Vector3.up * 5 * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(from.rotation, up.rotation, Time.time * 0.1f);
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
        }*/
	}

    private IEnumerator TurnLeft()
    {
        facingDirection = RotateDirectionLeft();

        transform.Rotate(new Vector3(0.0f, -90.0f, 0.0f));

        this.gameObject.GetComponent<Rigidbody>().velocity
            = new Vector3(0.0f, gameObject.GetComponent<Rigidbody>().velocity.y, moveSpeed);

        yield return new WaitForSeconds(5.0f);
        //Waiter();

        canTurn = true;
    }

    private IEnumerator TurnRight()
    {
        facingDirection = RotateDirectionRight();
        
        transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));

        this.gameObject.GetComponent<Rigidbody>().velocity
            = new Vector3(0.0f, gameObject.GetComponent<Rigidbody>().velocity.y, -moveSpeed);

        yield return new WaitForSeconds(5.0f);
        //Waiter();

        canTurn = true;
    }

    private void FireSonar()
    {
        throw new System.NotImplementedException();
    }

    private void MoveDown()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 1.0f, transform.position.z);
    }

    private void MoveUp()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
    }

    private void SinusMovement()
    {
        _newPosition = transform.position;
        _newPosition.y += 2 * Mathf.Sin(Time.time) * Time.deltaTime;
        transform.position = _newPosition;
    }

    private FacingDirection RotateDirectionRight()
    {
        int change = (int)(facingDirection);
        change++;
        //Our FacingDirection enum only has 4 states, if we go past the last state, loop to the first
        if (change > 3)
            change = 0;
        return (FacingDirection)(change);
    }
    /// <summary>
    /// Determines the facing direction after we rotate to the left
    /// </summary>
    /// <returns>The direction left.</returns>
    private FacingDirection RotateDirectionLeft()
    {
        int change = (int)(facingDirection);
        change--;
        //Our FacingDirection enum only has 4 states, if we go below the first, go to the last state
        if (change < 0)
            change = 3;
        return (FacingDirection)(change);
    }
}
