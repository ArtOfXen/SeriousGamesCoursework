using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public Toggle gardenerToggle;
    public Toggle handymanToggle;
    public Toggle chefsAssistantToggle;
    public Toggle cleanerToggle;
    public Toggle factoryWorkToggle;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void gardenerToggled() {
        if (gardenerToggle.isOn)
        { GameObject.FindWithTag("PlayerInformation").GetComponent<PlayerInformationScript>().changeJob("Gardener"); }
    }

    public void handymanToggled() {
        if (handymanToggle.isOn)
        { GameObject.FindWithTag("PlayerInformation").GetComponent<PlayerInformationScript>().changeJob("Handyman"); }
    }

    public void chefsAssistantToggled() {
        if (chefsAssistantToggle.isOn)
        { GameObject.FindWithTag("PlayerInformation").GetComponent<PlayerInformationScript>().changeJob("Chef's Assistant"); }
    }

    public void cleanerToggled() {
        if (cleanerToggle.isOn)
        { GameObject.FindWithTag("PlayerInformation").GetComponent<PlayerInformationScript>().changeJob("Cleaner"); }
    }

    public void factoryWorkToggled() {
        if (factoryWorkToggle.isOn)
        { GameObject.FindWithTag("PlayerInformation").GetComponent<PlayerInformationScript>().changeJob("Factory Worker"); }
    }

    public void startGame()
    {
        GameObject.FindWithTag("PlayerInformation").GetComponent<PlayerInformationScript>().playerName = GameObject.FindWithTag("PlayerInformation").GetComponent<PlayerInformationScript>().enterNameField.text;
        SceneManager.LoadScene("GameLevel", LoadSceneMode.Single);
    }
}
