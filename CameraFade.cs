using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFade : MonoBehaviour {

    //public Canvas GUI;
    public Image fadeToBlackGUIImage;

    private bool fadeIn;
    private bool fadeOut;
    private bool fadeOutWithDelay;
    private Vector2 newCameraLocation;
    private Vector2 newPlayerLocation;
    private string newPlayerDirection;
    private string roomToTransitionTo;

	// Use this for initialization
	void Start () {
        fadeIn = false;
        fadeOut = false;
        fadeOutWithDelay = false;
	}
	
	// Update is called once per frame
	void Update () {

        var blackGUIImageColour = fadeToBlackGUIImage.color;

        if ((fadeOut || fadeOutWithDelay) && blackGUIImageColour.a <= 1f)
        {
            blackGUIImageColour.a += Time.deltaTime;
            if (blackGUIImageColour.a > 1f)
            {
                blackGUIImageColour.a = 1f;

                if (fadeOutWithDelay)
                {
                    fadeOutWithDelay = false;
                    changeCameralocation(false);
                }
                else if (fadeOut)
                {
                    fadeOut = false;
                    changeCameralocation(true);
                }
            }
            fadeToBlackGUIImage.color = blackGUIImageColour;
        }
        else if (fadeIn && blackGUIImageColour.a >= 0f)
        {
            blackGUIImageColour.a -= Time.deltaTime;
            if (blackGUIImageColour.a < 0f) {
                fadeIn = false;
                blackGUIImageColour.a = 0f;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerScript>().playerMovementEnabled = true;
            }
            fadeToBlackGUIImage.color = blackGUIImageColour;
        }
	}

    public void triggerCameraChange(Vector2 _newCameraLocation, Vector2 _newPlayerLocation, string nextRoom, string _newPlayerDirection)
    {
        newCameraLocation = _newCameraLocation;
        newPlayerLocation = _newPlayerLocation;
        newPlayerDirection = _newPlayerDirection;
        fadeOut = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerScript>().playerMovementEnabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteManagerScript>().updateSpriteArray("idle", "null");
        roomToTransitionTo = nextRoom;
    }

    public void triggerDelayedCameraChange(Vector2 _newCameraLocation, Vector2 _newPlayerLocation, string nextRoom, string _newPlayerDirection)
    {
        newCameraLocation = _newCameraLocation;
        newPlayerLocation = _newPlayerLocation;
        newPlayerDirection = _newPlayerDirection;
        fadeOutWithDelay = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerScript>().playerMovementEnabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteManagerScript>().updateSpriteArray("idle", "null");
        roomToTransitionTo = nextRoom;
    }

    public void triggerFadeIn()
    {
        fadeIn = true;
    }

    void changeCameralocation(bool fadeInImmediately)
    {
        transform.position = new Vector3(newCameraLocation.x, newCameraLocation.y, -10f);
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<MinimapScript>().changeRoom(roomToTransitionTo);
        GameObject.FindGameObjectWithTag("Player").transform.position = newPlayerLocation;
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteManagerScript>().updateSpriteArray("idle", newPlayerDirection);
        fadeIn = fadeInImmediately;
    }
}
