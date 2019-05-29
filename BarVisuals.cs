using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarVisuals : MonoBehaviour {
    int CurrentCleanliness;
    int CurrentPreparedness;
    int CurrentEnergy;
    int CurrentHappiness;
    float HappinessWidth;
    float HappyPos;
    float CleanWidth;
    float CleanPos;
    float PrepWidth;
    float PrepPos;
    float EnergyWidth;
    float EnergyPos;
    [SerializeField] public Image BarStretch;
    [SerializeField] public string BarChanging;
    int Max = 10;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        CurrentCleanliness = PlayerInformationScript.Cleanliness;
        CurrentPreparedness = PlayerInformationScript.Preparedness;
        CurrentEnergy = PlayerInformationScript.Energy;
        CurrentHappiness = PlayerInformationScript.Happiness;
        if (BarChanging == "Cleanliness")
        {

            CleanWidth = (12 * (CurrentCleanliness));
            BarStretch.rectTransform.sizeDelta = new Vector2(CleanWidth, 10);
            CleanPos = (-80+(CurrentCleanliness*6));
            BarStretch.rectTransform.localPosition = new Vector3(CleanPos, -7, 0);
            if(CurrentCleanliness >=9)
            {
                BarStretch.color = new Color(0, 1, 0);
            }
            if(CurrentCleanliness <9 && CurrentCleanliness >= 7)
            {
                BarStretch.color = new Color(1, 1, 0);
            }
            if(CurrentCleanliness >= 4 && CurrentCleanliness <7)
            {
                BarStretch.color = new Color(1, (float)0.5, 0);
            }
            if(CurrentCleanliness < 3)
            {
                BarStretch.color = new Color(1, 0, 0);
            }

        }
        else if (BarChanging == "Preparedness")
        {
            PrepWidth = (12 * (CurrentPreparedness));
            BarStretch.rectTransform.sizeDelta = new Vector2(PrepWidth, 10);
            PrepPos = (-80 + (CurrentPreparedness * 6));
            BarStretch.rectTransform.localPosition = new Vector3(PrepPos, -7, 0);
            if (CurrentPreparedness >= 9)
            {
                BarStretch.color = new Color(0, 1, 0);
            }
            if (CurrentPreparedness < 9 && CurrentPreparedness >= 7)
            {
                BarStretch.color = new Color(1, 1, 0);
            }
            if (CurrentPreparedness >= 4 && CurrentPreparedness < 7)
            {
                BarStretch.color = new Color(1, (float)0.5, 0);
            }
            if (CurrentPreparedness < 3)
            {
                BarStretch.color = new Color(1, 0, 0);
            }
        }
        else if (BarChanging == "Energy")
        {

            EnergyWidth = (12 * (CurrentEnergy));
            BarStretch.rectTransform.sizeDelta = new Vector2(EnergyWidth, 10);
            EnergyPos = (-80 + (CurrentEnergy * 6));
            BarStretch.rectTransform.localPosition = new Vector3(EnergyPos, -7, 0);
            if (CurrentEnergy >= 9)
            {
                BarStretch.color = new Color(0, 1, 0);
            }
            if (CurrentEnergy < 9 && CurrentEnergy >= 7)
            {
                BarStretch.color = new Color(1, 1, 0);
            }
            if (CurrentEnergy >= 4 && CurrentEnergy < 7)
            {
                BarStretch.color = new Color(1, (float)0.5, 0);
            }
            if (CurrentEnergy < 3)
            {
                BarStretch.color = new Color(1, 0, 0);
            }
        }
        else if (BarChanging == "Happiness")
        {
            HappinessWidth = (12 * (CurrentHappiness)); 
            BarStretch.rectTransform.sizeDelta = new Vector2(HappinessWidth, 10);
            HappyPos = (-80 + (CurrentHappiness * 6));
            BarStretch.rectTransform.localPosition = new Vector3(HappyPos, -7, 0);
            if (CurrentHappiness >= 9)
            {
                BarStretch.color = new Color(0, 1, 0);
            }
            if (CurrentHappiness < 9 && CurrentHappiness >= 7)
            {
                BarStretch.color = new Color(1, 1, 0);
            }
            if (CurrentHappiness >= 4 && CurrentHappiness < 7)
            {
                BarStretch.color = new Color(1, (float)0.5, 0);
            }
            if (CurrentHappiness < 3)
            {
                BarStretch.color = new Color(1, 0, 0);
            }
        }

    }
}
