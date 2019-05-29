using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorningScript : MonoBehaviour {

    public GameObject morningPopupUI;
    public GameObject frontDoorNavigationUI;

    private bool popupHasHappened;

	// Use this for initialization
	void Start () {
        popupHasHappened = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void bedUsed()
    {
        if (!popupHasHappened)
        {
            popupHasHappened = true;
            morningPopupUI.SetActive(true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerScript>().playerMovementEnabled = false;
			GameObject.FindGameObjectWithTag("GameManager").GetComponent<ClockScript>().timeIsPaused = true;
        }
    }

    public void continuePressed()
    {
        morningPopupUI.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerScript>().playerMovementEnabled = true;
		GameObject.FindGameObjectWithTag("GameManager").GetComponent<ClockScript>().timeIsPaused = false;
        frontDoorNavigationUI.SetActive(true);
    }
}
