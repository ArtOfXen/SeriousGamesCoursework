using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintScript : MonoBehaviour {

	struct Hint
	{
		public string hintString;
		public bool hasBeenShown;
	}

	bool showHint;
	public Text hintText;

	private Hint energyHint;
	private Hint energyHint_Afternoon;
	private Hint cleanlinessHint;
	private Hint happinessHint;
	private Hint readinessHint;

	// Use this for initialization
	void Start () {
		showHint = false;

		energyHint = new Hint ();
		energyHint.hintString = "Maybe you should make some food in the kitchen.";
		energyHint.hasBeenShown = false;

		energyHint_Afternoon = new Hint ();
		energyHint_Afternoon.hintString = "Maybe you should make some food in the kitchen or go to bed.";
		energyHint_Afternoon.hasBeenShown = false;

		cleanlinessHint = new Hint ();
		cleanlinessHint.hintString = "You might want to have a wash in the bathroom.";
		cleanlinessHint.hasBeenShown = false;

		happinessHint = new Hint ();
		happinessHint.hintString = "You could exercise or watch T.V.";
		happinessHint.hasBeenShown = false;

		readinessHint = new Hint ();
		readinessHint.hintString = "You could listen to the news, brush your hair, or use the phone.";
		readinessHint.hasBeenShown = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (showHint) {
			if (!cleanlinessHint.hasBeenShown && PlayerInformationScript.Cleanliness <= 4)
			{
				hintText.text = cleanlinessHint.hintString;
				cleanlinessHint.hasBeenShown = true;
			}
			else if (!happinessHint.hasBeenShown && PlayerInformationScript.Happiness <= 4)
			{
				hintText.text = happinessHint.hintString;
				happinessHint.hasBeenShown = true;
			}
			else if (!energyHint_Afternoon.hasBeenShown && PlayerUseItem.CurrentPhase == "Afternoon" && PlayerInformationScript.Energy <= 4)
			{
				hintText.text = energyHint_Afternoon.hintString;
				energyHint_Afternoon.hasBeenShown = true;
			}
			else if (!energyHint.hasBeenShown && PlayerUseItem.CurrentPhase == "Morning"  && PlayerInformationScript.Energy <= 4)
			{
				hintText.text = energyHint.hintString;
				energyHint.hasBeenShown = true;
			}
			else if (!readinessHint.hasBeenShown && PlayerInformationScript.Preparedness <= 4)
			{
				hintText.text = readinessHint.hintString;
				readinessHint.hasBeenShown = true;
			}

			showHint = false;
		}
	}

	public void showHintText()
	{
		showHint = true;
	}

	public void hideHintText()
	{
		hintText.text = "";
	}
}
