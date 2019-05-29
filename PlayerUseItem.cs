using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUseItem : MonoBehaviour {
    [SerializeField] private Image bgImage;
    [SerializeField] private Text DescriptionText;
    [SerializeField] private Image buttonImage;
    //[SerializeField] private Image buttonSoundImage;
    [SerializeField] private Text buttonText;
    [SerializeField] private string SpecialRequirement;
    static public string CurrentPhase = "Afternoon";
    static public string FoodReady = "NotReady";
    static public string RadioUsed = "RadioUnused";
    static public string Wallet = "notGrabbed";
    static public string Dressed = "notDressed";
    static public string HairbrushUsed = "HairbrushUnused";
    static public string ToothpasteUsed = "Unused";


    void Start()
    {
        bgImage.enabled = false;
        buttonImage.enabled = false;
        buttonText.enabled = false;
        DescriptionText.enabled = false;
        //buttonSoundImage.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        {
            if (SpecialRequirement == "")
            {
                bgImage.enabled = true;
                buttonImage.enabled = true;
                buttonText.enabled = true;
                DescriptionText.enabled = true;
                //buttonSoundImage.enabled = true;
            }
            else if (SpecialRequirement == CurrentPhase)
            {
                bgImage.enabled = true;
                buttonImage.enabled = true;
                buttonText.enabled = true;
                DescriptionText.enabled = true;
                //buttonSoundImage.enabled = true;
            }
            else if (SpecialRequirement == FoodReady)
            {
                bgImage.enabled = true;
                buttonImage.enabled = true;
                buttonText.enabled = true;
                DescriptionText.enabled = true;
                //buttonSoundImage.enabled = true;
            }
            else if (SpecialRequirement == RadioUsed)
            {
                bgImage.enabled = true;
                buttonImage.enabled = true;
                buttonText.enabled = true;
                DescriptionText.enabled = true;
                //buttonSoundImage.enabled = true;
            }
            else if (SpecialRequirement == HairbrushUsed)
            {
                bgImage.enabled = true;
                buttonImage.enabled = true;
                buttonText.enabled = true;
                DescriptionText.enabled = true;
                //buttonSoundImage.enabled = true;
            }
            else if (SpecialRequirement == Dressed && CurrentPhase == "Morning")
            {
                bgImage.enabled = true;
                buttonImage.enabled = true;
                buttonText.enabled = true;
                DescriptionText.enabled = true;
                //buttonSoundImage.enabled = true;
            }
            else if (SpecialRequirement == Wallet && CurrentPhase == "Morning")
            {
                bgImage.enabled = true;
                buttonImage.enabled = true;
                buttonText.enabled = true;
                DescriptionText.enabled = true;
            }
            else if (SpecialRequirement == "ToothpasteUsed")
            {
                bgImage.enabled = true;
                buttonImage.enabled = true;
                buttonText.enabled = true;
                DescriptionText.enabled = true;
            }
            else if (SpecialRequirement == "Dinner" && FoodReady == "NotReady" && CurrentPhase == "Afternoon")
            {
                bgImage.enabled = true;
                buttonImage.enabled = true;
                buttonText.enabled = true;
                DescriptionText.enabled = true;
                //buttonSoundImage.enabled = true;
            }
            else if (SpecialRequirement == "Breakfast" && FoodReady == "NotReady" && CurrentPhase == "Morning")
            {
                bgImage.enabled = true;
                buttonImage.enabled = true;
                buttonText.enabled = true;
                DescriptionText.enabled = true;
                //buttonSoundImage.enabled = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            bgImage.enabled = false;
            buttonImage.enabled = false;
            buttonText.enabled = false;
            DescriptionText.enabled = false;
            //buttonSoundImage.enabled = false;
        }
    }

    void Update()
    {
        
        if (SpecialRequirement == "Ready" && FoodReady == "NotReady")
        {
            bgImage.enabled = false;
            buttonImage.enabled = false;
            buttonText.enabled = false;
            DescriptionText.enabled = false;
            //buttonSoundImage.enabled = true;
        }

        if (SpecialRequirement == "Dinner" && FoodReady == "Ready" && CurrentPhase == "Afternoon")
        {
            bgImage.enabled = false;
            buttonImage.enabled = false;
            buttonText.enabled = false;
            DescriptionText.enabled = false;
            //buttonSoundImage.enabled = true;
        }
        if (SpecialRequirement == "Breakfast" && FoodReady == "Ready" && CurrentPhase == "Morning")
        {
            bgImage.enabled = false;
            buttonImage.enabled = false;
            buttonText.enabled = false;
            DescriptionText.enabled = false;
            //buttonSoundImage.enabled = true;
        }
        if (SpecialRequirement == "RadioUnused" && RadioUsed == "RadioUsed")
        {
            bgImage.enabled = false;
            buttonImage.enabled = false;
            buttonText.enabled = false;
            DescriptionText.enabled = false;
        }
        if (SpecialRequirement == "HairbrushUnused" && HairbrushUsed == "HairbrushUsed")
        {
            bgImage.enabled = false;
            buttonImage.enabled = false;
            buttonText.enabled = false;
            DescriptionText.enabled = false;
        }
        if (SpecialRequirement == "notDressed" && Dressed == "Dressed")
        {
            bgImage.enabled = false;
            buttonImage.enabled = false;
            buttonText.enabled = false;
            DescriptionText.enabled = false;
        }
        if (SpecialRequirement == "notGrabbed" && Wallet == "Grabbed")
        {
            bgImage.enabled = false;
            buttonImage.enabled = false;
            buttonText.enabled = false;
            DescriptionText.enabled = false;
        }
        if(SpecialRequirement == "Afternoon" && CurrentPhase == "Morning")
        {
            bgImage.enabled = false;
            buttonImage.enabled = false;
            buttonText.enabled = false;
            DescriptionText.enabled = false;
        }
        if (SpecialRequirement == "ToothpasteUsed" && ToothpasteUsed == "Used")
            {
            bgImage.enabled = false;
            buttonImage.enabled = false;
            buttonText.enabled = false;
            DescriptionText.enabled = false;
        }
    }
}