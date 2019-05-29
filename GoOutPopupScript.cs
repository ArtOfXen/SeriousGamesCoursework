using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoOutPopupScript : MonoBehaviour {

    public GameObject goOutInvite_UI;
    public Text goOutText_UI;
    public GameObject goHomeEarly_UI;
    public GameObject goHomeLate_UI;

    private bool goOutPopUpHasHappened;

    private ClockScript clockScript;

    // Use this for initialization
    void Start() {
        goOutPopUpHasHappened = false;

        string playerName = GameObject.FindGameObjectWithTag("PlayerInformation").GetComponent<PlayerInformationScript>().playerName;
        goOutText_UI.GetComponent<Text>().text = "One of your mates calls you on the phone.\n\n'Hi " + playerName + ", we are going to the pub for drinks now. Do you want to come?'";

        clockScript = GetComponent<ClockScript>();
    }

    // Update is called once per frame
    void Update() {
        if (!goOutPopUpHasHappened && clockScript.getCurrentHour() >= 19 && PlayerUseItem.CurrentPhase == "Afternoon")
        {
            goOutPopUpHasHappened = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerScript>().playerMovementEnabled = false;
			GameObject.FindGameObjectWithTag("GameManager").GetComponent<ClockScript>().timeIsPaused = true;
            goOutInvite_UI.SetActive(true);
        }
    }

    public void checkIfTimeForPopup()
    {
        
    }

    public void goOutButtonPressed()
    {
        GetComponent<ClockScript>().setTimeToAbsolute(21f, 00f);
        Camera.main.GetComponent<CameraFade>().triggerDelayedCameraChange(new Vector2(0f, 0f), new Vector2(-4.57f, -3.68f), "entranceHall", "down");
        goOutInvite_UI.SetActive(false);
        goHomeEarly_UI.SetActive(true);
    }

    public void stayHomeButtonPressed()
    {
        goOutInvite_UI.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerScript>().playerMovementEnabled = true;
    }

    public void goHomeEarlyButtonPressed()
    {
        goHomeEarly_UI.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerScript>().playerMovementEnabled = true;
        Camera.main.GetComponent<CameraFade>().triggerFadeIn();
    }

    public void stayOutLongerButtonPressed()
    {
        GetComponent<ClockScript>().setTimeToAbsolute(00f, 00f);
        goHomeEarly_UI.SetActive(false);
        goHomeLate_UI.SetActive(true);
    }

    public void continueButtonPressed()
    {
        goHomeLate_UI.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerScript>().playerMovementEnabled = true;
		GameObject.FindGameObjectWithTag("GameManager").GetComponent<ClockScript>().timeIsPaused = false;
        Camera.main.GetComponent<CameraFade>().triggerFadeIn();
    }
}
