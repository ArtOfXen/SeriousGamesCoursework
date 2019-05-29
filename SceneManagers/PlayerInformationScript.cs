using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInformationScript : MonoBehaviour {

    public enum HowWellSlept
    {
        noSleep,
        sixHours,
        eightHours,
        tenHours
    }

    public enum InterviewArrivalTime
    {
        early,
        onTime,
        late
    };

    [HideInInspector] public string playerName;
    [HideInInspector] public string chosenJob;

    [HideInInspector] public static int Happiness;
    [HideInInspector] public static int Cleanliness;
    [HideInInspector] public static int Energy;
    [HideInInspector] public static int Preparedness;

    [HideInInspector] public InterviewArrivalTime timeLeftHouse;
    [HideInInspector] public HowWellSlept howWellSlept;
    public InputField enterNameField;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }


    // Use this for initialization
    void Start () {
        chosenJob = "Gardener";
        Happiness = 0;
        Cleanliness = 0;
        Energy = 0;
        Preparedness = 0;
        howWellSlept = HowWellSlept.noSleep;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeJob(string job)
    {
        chosenJob = job;
    }
}
