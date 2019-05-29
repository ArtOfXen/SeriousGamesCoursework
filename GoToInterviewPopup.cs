using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToInterviewPopup : MonoBehaviour {

    public GameObject interviewPopupUI;

    private bool interviewPopupHasHappened;

    private ClockScript clockScript;

    // Use this for initialization
    void Start () {
        interviewPopupHasHappened = false;

        clockScript = GetComponent<ClockScript>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!interviewPopupHasHappened && clockScript.getCurrentHour() >= 8 && clockScript.getCurrentMinutes() >= 10 && clockScript.isSecondDay)
        {
            interviewPopupHasHappened = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerScript>().playerMovementEnabled = false;
			GameObject.FindGameObjectWithTag("GameManager").GetComponent<ClockScript>().timeIsPaused = true;
            interviewPopupUI.SetActive(true);
        }
    }

    public void contunuePressed()
    {
        interviewPopupUI.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerScript>().playerMovementEnabled = true;
		GameObject.FindGameObjectWithTag("GameManager").GetComponent<ClockScript>().timeIsPaused = false;
    }
}
