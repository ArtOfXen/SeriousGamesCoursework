using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneMenu : MonoBehaviour {

    [SerializeField] private Button ButtonForNextScreen;
    [SerializeField] private string SceneName;

	// Use this for initialization
	void Start () {
        ButtonForNextScreen.onClick.AddListener(ChangeScene);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void ChangeScene()
    {
        if(SceneName == "EndScreen")
        {
            ClockScript GM = GameObject.Find("GameManager").GetComponent<ClockScript>();
            if(GM.getCurrentHour() > 8)
            {
                GameObject.FindGameObjectWithTag("PlayerInformation").GetComponent<PlayerInformationScript>().timeLeftHouse = PlayerInformationScript.InterviewArrivalTime.late;
            }
            else if (GM.getCurrentHour() <8)
            {
                GameObject.FindGameObjectWithTag("PlayerInformation").GetComponent<PlayerInformationScript>().timeLeftHouse = PlayerInformationScript.InterviewArrivalTime.early;
            }
            else
            {
                if (GM.getCurrentMinutes() > 45)
                {
                    GameObject.FindGameObjectWithTag("PlayerInformation").GetComponent<PlayerInformationScript>().timeLeftHouse = PlayerInformationScript.InterviewArrivalTime.late;
                }
                else if (GM.getCurrentMinutes() < 31)
                {
                    GameObject.FindGameObjectWithTag("PlayerInformation").GetComponent<PlayerInformationScript>().timeLeftHouse = PlayerInformationScript.InterviewArrivalTime.early;
                }
                else
                {
                    GameObject.FindGameObjectWithTag("PlayerInformation").GetComponent<PlayerInformationScript>().timeLeftHouse = PlayerInformationScript.InterviewArrivalTime.onTime;
                }
            }
        }
        
        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);

    }
}
