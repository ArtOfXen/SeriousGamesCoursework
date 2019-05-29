using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {

    public float movementSpeed;

    [HideInInspector] public bool playerMovementEnabled;
	[HideInInspector] public bool mouseMovementEnabled;

    private bool moveUp;
    private bool moveDown;
    private bool moveLeft;
    private bool moveRight;
    Resolution res;

    private BoxCollider2D hitbox;

	// Use this for initialization
	void Start () {

        moveUp = false;
        moveDown = false;
        moveLeft = false;
        moveRight = false;

        hitbox = GetComponent<BoxCollider2D>();

        playerMovementEnabled = true;
		mouseMovementEnabled = true;
        res = Screen.currentResolution;
        if (res.refreshRate == 60)
        {
            QualitySettings.vSyncCount = 1;
        }
        if (res.refreshRate == 120)
        {
            QualitySettings.vSyncCount = 2;
        }
    }


    void Update()
    {
        if (playerMovementEnabled)
        {
			bool mouseMovementInUse = false;
			if (mouseMovementEnabled)
			{
	            // mouse movement input
	            if (Input.GetButton("Fire1"))
	            {
					mouseMovementInUse = true;

	                if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y > transform.position.y + (hitbox.size.y / 3))
	                {
	                    moveUp = true;
	                }
	                else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < transform.position.y - (hitbox.size.y / 3))
	                {
	                    moveDown = true;
	                }

	                if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x - (hitbox.size.x / 3))
	                {
	                    moveLeft = true;
	                }
	                else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x + (hitbox.size.x / 3))
	                {
	                    moveRight = true;
	                }
	            }
			}

            // if mouse not being used for movement, check keys
			if (!mouseMovementInUse)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    moveUp = true;
                }

                else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    moveDown = true;
                }

                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    moveLeft = true;
                }

                else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    moveRight = true;
                }
            }

            if (moveUp || moveDown)
            {
                // if moving both horizontally and vertically, slow movement speed of both.
                if (moveLeft || moveRight)
                {
                    if (moveUp)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y + (movementSpeed * 0.707f), transform.position.z);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y - (movementSpeed * 0.707f), transform.position.z);
                    }
                    if (moveLeft)
                    {
                        transform.position = new Vector3(transform.position.x - (movementSpeed * 0.707f), transform.position.y, transform.position.z);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x + (movementSpeed * 0.707f), transform.position.y, transform.position.z);
                    }
                }
                // move up / down full amount
                else
                {
                    if (moveUp)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y + (movementSpeed), transform.position.z);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y - (movementSpeed), transform.position.z);
                    }
                }
            }
            // move left / right full amount.
            else if (moveLeft || moveRight)
            {
                if (moveLeft)
                {
                    transform.position = new Vector3(transform.position.x - movementSpeed, transform.position.y, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x + movementSpeed, transform.position.y, transform.position.z);
                }
            }

            // update sprite

            string movementDirectionString;
            string actionString = "walk";

            if (moveLeft)
            {
                movementDirectionString = "left";
            }
            else if (moveRight)
            {
                movementDirectionString = "right";
            }
            else if (moveUp)
            {
                movementDirectionString = "up";
            }
            else if (moveDown)
            {
                movementDirectionString = "down";
            }
            else
            {
                movementDirectionString = "null";
                actionString = "idle";
            }

            GetComponent<SpriteManagerScript>().updateSpriteArray(actionString, movementDirectionString);

            moveUp = false;
            moveDown = false;
            moveLeft = false;
            moveRight = false;

        }
    }
}
