using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreenManagerScript : MonoBehaviour {

    [HideInInspector] public Text positivesText;
	[HideInInspector] public Text negativesText;

	[HideInInspector] public int happinessValue;
	[HideInInspector] public int cleanlinessValue;
	[HideInInspector] public int energyValue;
	[HideInInspector] public int preparednessValue;
    
    private string playerName;
    private PlayerInformationScript.HowWellSlept howWellSlept;
	[HideInInspector] public PlayerInformationScript.InterviewArrivalTime timeArrived;

    private List<string> positives;
    private List<string> negatives;

	[HideInInspector] public List<AudioClip> positivesAudioClips;
	[HideInInspector] public List<AudioClip> negativesAudioClips;

	public AudioClip earlyArrival_audioClip;
	public AudioClip onTime_positiveAudioClip;
	public AudioClip lateArrival_positiveAudioClip;
	public AudioClip lateArrival_negativeAudioClip;

	public AudioClip noSleep_audioClip;
	public AudioClip sixHoursSleep_audioClip;
	public AudioClip eightHoursSleep_audioClip;

	public AudioClip highHappiness_audioClip;
	public AudioClip lowHappiness_audioClip;
	public AudioClip highCleanliness_audioClip;
	public AudioClip lowCleanliness_audioClip;
	public AudioClip highEnergy_audioClip;
	public AudioClip lowEnergy_audioClip;
	public AudioClip highReadiness_audioClip;
	public AudioClip lowReadiness_audioClip;



    // Use this for initialization
    void Start () {
        playerName = GameObject.FindGameObjectWithTag("PlayerInformation").GetComponent<PlayerInformationScript>().playerName;
        howWellSlept = GameObject.FindGameObjectWithTag("PlayerInformation").GetComponent<PlayerInformationScript>().howWellSlept;
        timeArrived = GameObject.FindGameObjectWithTag("PlayerInformation").GetComponent<PlayerInformationScript>().timeLeftHouse;

        happinessValue = PlayerInformationScript.Happiness;
        cleanlinessValue = PlayerInformationScript.Cleanliness;
        energyValue = PlayerInformationScript.Energy;
        preparednessValue = PlayerInformationScript.Preparedness;

        positives = new List<string>();
        negatives = new List<string>();

		positivesAudioClips = new List<AudioClip> ();
		negativesAudioClips = new List<AudioClip> ();

		List<AudioClip> allPositivesAudioClips = new List<AudioClip>();
		List<AudioClip> allNegativesAudioClips = new List<AudioClip>();

        switch (timeArrived)
        {

            // these string should pop up when they leave the house, not on the endscreen.

            case PlayerInformationScript.InterviewArrivalTime.early:
                positives.Add("Good job, " + playerName + "! You got to the interview 15 minutes early; the interviewer was very happy.");
				allPositivesAudioClips.Add (earlyArrival_audioClip);
                break;

            case PlayerInformationScript.InterviewArrivalTime.onTime:
                positives.Add("Well done, " + playerName + "! You made it to the interview on time.");
				allPositivesAudioClips.Add(onTime_positiveAudioClip);
                negatives.Add("You should try to get to your interview 15 minutes early.");
			allNegativesAudioClips.Add(lateArrival_negativeAudioClip);
                break;

            case PlayerInformationScript.InterviewArrivalTime.late:
                positives.Add("Well done for making it to the interview, " + playerName + ".");
				allPositivesAudioClips.Add(lateArrival_positiveAudioClip);
                negatives.Add("You should try to get to your interview 15 minutes early.");
				allNegativesAudioClips.Add(lateArrival_negativeAudioClip);
                break;
        }

        switch (howWellSlept)
        {
            case PlayerInformationScript.HowWellSlept.noSleep:
                negatives.Add("You should try to sleep for 8 hours every night.");
				allNegativesAudioClips.Add(noSleep_audioClip);
                break;

            case PlayerInformationScript.HowWellSlept.sixHours:
                negatives.Add("You should try to go to bed earlier to make sure you are at your best. Try to get 8 hours of sleep.");
				allNegativesAudioClips.Add(sixHoursSleep_audioClip);
                break;

            case PlayerInformationScript.HowWellSlept.eightHours:
                positives.Add("Your interviewer thought it looked like you had a good nights sleep.");
				allPositivesAudioClips.Add(eightHoursSleep_audioClip);
                break;

            case PlayerInformationScript.HowWellSlept.tenHours:
                positives.Add("Your interviewer thought it looked like you had a good nights sleep.");
				allPositivesAudioClips.Add(eightHoursSleep_audioClip);
                //negatives.Add("TRY TO GET 8 HOURS");
                break;
        }

        if (happinessValue >= 8){
			positives.Add("Your interviewer noticed how happy you were and liked that.");
			allPositivesAudioClips.Add(highHappiness_audioClip);
		}
        else if (happinessValue >= 4){// NOTHING HAPPENS
        }
        else{
			negatives.Add("You should try to be happier before your interview, it will help you be more relaxed.");
			allNegativesAudioClips.Add(lowHappiness_audioClip);
		}


        if (cleanlinessValue >= 8) { 
			positives.Add("The interviewer noticed you were well dressed and looked smart.");
			allPositivesAudioClips.Add(highCleanliness_audioClip);
		}
        else if (cleanlinessValue >= 4){// NOTHING HAPPENS 
        }
        else{
			negatives.Add("It is important to wash and wear clean clothes to impress your interviewer.");
			allNegativesAudioClips.Add(lowCleanliness_audioClip);
		}


        if (energyValue >= 8){
			positives.Add("Your interviewer was happy that you were energetic and focused.");
			allPositivesAudioClips.Add(highEnergy_audioClip);
		}
        else if (energyValue >= 4){// NOTHING HAPPENS
        }
        else{
			negatives.Add("Try to be energetic and focused for your interviews.");
			allNegativesAudioClips.Add(lowEnergy_audioClip);
		}


        if (preparednessValue >= 8){
			positives.Add("Good job! The interviewer saw that you were very ready for the interview.");
			allPositivesAudioClips.Add(highReadiness_audioClip);
		}
        else if (preparednessValue >= 4){// NOTHING HAPPENS
        }
        else{
			negatives.Add("You can be more ready by making sure you have money on you, and by listening to the news.");
			allNegativesAudioClips.Add(lowReadiness_audioClip);
		}


        // only use 4 of each
        List<string> finalPositives = new List<string>();

        if (positives.Count <= 4)
        {
            for (int i = 0; i < positives.Count; i++)
            {
                finalPositives.Add(positives[i]);
				positivesAudioClips.Add (allPositivesAudioClips[i]);
            }
        }
        else
        {
            // get 2 different entries other than the first 2
            int randomPositive1 = Random.Range(3, positives.Count);
            int randomPositive2 = Random.Range(3, positives.Count);
            while (randomPositive1 == randomPositive2)
            {
                randomPositive2 = Random.Range(3, positives.Count);
            }

            finalPositives.Add(positives[0]); finalPositives.Add(positives[1]);
			positivesAudioClips.Add(allPositivesAudioClips[0]); positivesAudioClips.Add(allPositivesAudioClips[1]);
            finalPositives.Add(positives[randomPositive1]); finalPositives.Add(positives[randomPositive2]);
			positivesAudioClips.Add(allPositivesAudioClips[randomPositive1]); positivesAudioClips.Add(allPositivesAudioClips[randomPositive2]);
        }

        List<string> finalNegatives = new List<string>();

        if (negatives.Count <= 4)
        {
            for (int i = 0; i < negatives.Count; i++)
            {
				finalNegatives.Add(negatives[i]);
				negativesAudioClips.Add (allNegativesAudioClips[i]);
            }
        }
        else
        {
            // get 2 different entries other than the first 2
            int randomNegative1 = Random.Range(3, negatives.Count);
            int randomNegative2 = Random.Range(3, negatives.Count);
            while (randomNegative1 == randomNegative2)
            {
                randomNegative2 = Random.Range(3, negatives.Count);
            }

            finalNegatives.Add(negatives[0]); finalNegatives.Add(negatives[1]);
			negativesAudioClips.Add (allNegativesAudioClips[0]); negativesAudioClips.Add (allNegativesAudioClips[1]);
            finalNegatives.Add(negatives[randomNegative1]); finalNegatives.Add(negatives[randomNegative2]);
			negativesAudioClips.Add (allNegativesAudioClips[randomNegative1]); negativesAudioClips.Add (allNegativesAudioClips[randomNegative2]);
        }

        // Set text on screen
        positivesText.text = "";
        for (int i = 0; i < finalPositives.Count; i++)
        {
            positivesText.text += (i+1).ToString() + ". " + finalPositives[i];
            if (i < finalPositives.Count - 1)
            {
                positivesText.text += '\n';
            }
        }

        negativesText.text = "";
        for (int i = 0; i < finalNegatives.Count; i++)
        {
            negativesText.text += (i + 1).ToString() + ". " + finalNegatives[i];
            if (i < finalNegatives.Count - 1)
            {
                negativesText.text += '\n';
            }
        }


        // Player information persists through the entire program, so needs to be destroyed here so that it does not carry over into the next game
        Destroy(GameObject.FindGameObjectWithTag("PlayerInformation"));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void goToTitleScreen()
    {
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }

	public void playPositiveAudioClips()
	{
		GetComponent<PlaySoundScript> ().playAudioClipList (positivesAudioClips);
	}

	public void playNegativeAudioClips()
	{
		GetComponent<PlaySoundScript> ().playAudioClipList (negativesAudioClips);
	}
}
