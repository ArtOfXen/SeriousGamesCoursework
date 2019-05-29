using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScreenScript : MonoBehaviour {

    public GameObject helpScreenUI_FirstPage;
	public GameObject helpScreenUI_SecondPage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void triggerHelpScreenVisibility()
    {
		if (!helpScreenUI_FirstPage.activeInHierarchy && !helpScreenUI_SecondPage.activeInHierarchy)
        {
			GameObject.FindGameObjectWithTag("GameManager").GetComponent<ClockScript>().timeIsPaused = true;
			helpScreenUI_FirstPage.SetActive(true);
			helpScreenUI_SecondPage.SetActive(false);
        }
        else
        {
			GameObject.FindGameObjectWithTag("GameManager").GetComponent<ClockScript>().timeIsPaused = false;
			helpScreenUI_FirstPage.SetActive(false);
			helpScreenUI_SecondPage.SetActive(false);
        }
    }

	public void openHelpScreen_FirstPage()
	{
		helpScreenUI_FirstPage.SetActive(true);
		helpScreenUI_SecondPage.SetActive(false);
	}

	public void openHelpScreen_SecondPage()
	{
		helpScreenUI_FirstPage.SetActive(false);
		helpScreenUI_SecondPage.SetActive(true);
	}

	public void continueButtonPressed()
	{
		helpScreenUI_FirstPage.SetActive(false);
		helpScreenUI_SecondPage.SetActive(false);
		GameObject.FindGameObjectWithTag("GameManager").GetComponent<ClockScript>().timeIsPaused = false;
	}
}
