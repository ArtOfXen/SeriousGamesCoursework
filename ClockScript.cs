using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockScript : MonoBehaviour {

    //public Image minuteHandImage;
    //public Image hourHandImage;
    public Text timeTextbox;
    public float startingHour;
    public float startingMinutes;
    [HideInInspector] public bool isSecondDay;

	[HideInInspector] public float timeLastItemWasUsed;
	private float timeWithoutItemUsedUntilHintGiven;
	private float timeThisFrame;
	[HideInInspector] public bool timeIsPaused;
	private bool hintIsBeingShown;

    private float timeHours;
    private float timeMinutes;

	// Use this for initialization
	void Start () {
        timeHours = startingHour;
        timeMinutes = startingMinutes;
        progressTimeByMinutes(0f);
        isSecondDay = false;
		timeWithoutItemUsedUntilHintGiven = 30f;
		timeIsPaused = true;
		hintIsBeingShown = false;
    }
	
	// Update is called once per frame
	void Update () {
		timeThisFrame = Time.time;
		if (timeIsPaused || hintIsBeingShown) {
			timeLastItemWasUsed += Time.deltaTime;
		}

		if (timeThisFrame - timeLastItemWasUsed >= timeWithoutItemUsedUntilHintGiven) 
		{
			if (!hintIsBeingShown)
			{
				hintIsBeingShown = true;
				GetComponent<HintScript> ().showHintText ();
			}
		} else 
		{
			GetComponent<HintScript> ().hideHintText();
		}

    }

	public void itemWasUsed()
	{
		timeLastItemWasUsed = Time.time;
		hintIsBeingShown = false;
	}

    public float getCurrentHour()
    {
        return timeHours;
    }

    public float getCurrentMinutes()
    {
        return timeMinutes;
    }

    public void setTimeToAbsolute(float newHours, float newMinutes)
    {
        float hoursDifference = newHours - timeHours;
        if (hoursDifference < 0) { hoursDifference += 24; }

        float minutesDifference = newMinutes - timeMinutes;
        if (minutesDifference < 0) { minutesDifference += 60; hoursDifference--; }

        while (hoursDifference > 0)
        {
            hoursDifference--;
            minutesDifference += 60;
        }

        progressTimeByMinutes(minutesDifference);

    }

    public void progressTimeByMinutes(float minutesToProgress)
    {
        timeMinutes += minutesToProgress;

        // ensure times on clock don't overrun max values
        while (timeMinutes >= 60)
        {
            timeMinutes -= 60;
            timeHours++;
        }

        if (timeHours >= 24)
        {
            isSecondDay = true;
            timeHours -= 24;
        }
        else if (timeHours > 12)
        {
            isSecondDay = false;
        }

		if (isSecondDay && PlayerUseItem.CurrentPhase == "Afternoon" && timeHours >= 4) 
		{
            Bars.ChangePhase();
            MorningScript MS = GameObject.FindGameObjectWithTag("GameManager").GetComponent<MorningScript>();
            MS.bedUsed();
        }
        else if (!isSecondDay && PlayerUseItem.CurrentPhase == "Morning" && timeHours >= 18)
        {
            PlayerUseItem.CurrentPhase = "Afternoon";
        }

        // set clock hand rotations
        //RectTransform minuteHandTransform = minuteHandImage.GetComponent<RectTransform>();
        //minuteHandTransform.rotation = Quaternion.Euler(new Vector3(0, 0, timeMinutes * -6f));

        //RectTransform hourHandTransform = hourHandImage.GetComponent<RectTransform>();
        //hourHandTransform.rotation = Quaternion.Euler(new Vector3(0, 0, (timeHours * -30f) + (timeMinutes * -0.5f)));

        // convert hours as minutes to strings with 2 significant figures
        string hoursAsString = timeHours.ToString();
        if (hoursAsString.Length < 2)
        {
            hoursAsString = "0" + hoursAsString;
        }

        string minutesAsString = timeMinutes.ToString();
        if (minutesAsString.Length < 2)
        {
            minutesAsString = "0" + minutesAsString;
        }

        // set UI to show time as text
        string timeAsString = hoursAsString + ":" + minutesAsString;
        timeTextbox.GetComponent<Text>().text = timeAsString;

    }
}
