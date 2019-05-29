using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bars : MonoBehaviour
{
    string objectName;
    [SerializeField] private string BartoChange;
    [SerializeField] private int AmountToChangeBy;
    [SerializeField] private int TimeUsed;
    [SerializeField] public Button button;
    [SerializeField] string SpecialCondition;

    // Use this for initialization
    void Start()
    {
        button.onClick.AddListener(TaskOnClick);

        string objectName = gameObject.name;
    }
    //check when the button (inputted through unity) is clicked
    void TaskOnClick()
    {

        Invoke("DestroyPlusClone", 1f);
        ClockScript GM2 = GameObject.Find("GameManager").GetComponent<ClockScript>();
        GM2.itemWasUsed();
        //goes through all 4 types of bar and changes it by amount to change by field
        if (BartoChange == "Cleanliness")
        {
            PlayerInformationScript.Cleanliness += AmountToChangeBy;
            if (PlayerInformationScript.Cleanliness > 10)
            {
                PlayerInformationScript.Cleanliness = 10;
            }
            if (PlayerInformationScript.Cleanliness < 0)
            {
                PlayerInformationScript.Cleanliness = 0;
            }
            //Debug.Log(Cleanliness);
        }
        else if (BartoChange == "Preparedness")
        {
            PlayerInformationScript.Preparedness += AmountToChangeBy;
            if (PlayerInformationScript.Preparedness > 10)
            {
                PlayerInformationScript.Preparedness = 10;
            }
            if (PlayerInformationScript.Preparedness < 0)
            {
                PlayerInformationScript.Preparedness = 0;
            }
            //Debug.Log(Preparedness);
        }
        else if (BartoChange == "Energy")
        {
            if (AmountToChangeBy > 0)
            {
                PlayerInformationScript.Energy += AmountToChangeBy * 2;
            }
            else
            {
                PlayerInformationScript.Energy += AmountToChangeBy;
            }
            if (PlayerInformationScript.Energy > 10)
            {
                PlayerInformationScript.Energy = 10;
            }
            if (PlayerInformationScript.Energy < 0)
            {
                PlayerInformationScript.Energy = 0;
            }
            //Debug.Log(Energy);
        }
        else if (BartoChange == "Happiness")
        {
            PlayerInformationScript.Happiness += AmountToChangeBy;
            if (PlayerInformationScript.Happiness > 10)
            {
                PlayerInformationScript.Happiness = 10;
            }
            if (PlayerInformationScript.Happiness < 0)
            {
                PlayerInformationScript.Happiness = 0;
            }
            //Debug.Log(Happiness);
        }
        //checks for any typos or mispellings for debugging
        else
        {
            Debug.Log("Bar not recognised, Bar: " + BartoChange + " is not a valid type of bar on object: " + objectName);
        }
        if(SpecialCondition == "FoodReady")
        {
            PlayerUseItem.FoodReady = "Ready";
            Sprite TableSprite = Resources.Load<Sprite>("breakfast");
            GameObject.Find("Table").GetComponent<SpriteRenderer>().sprite = TableSprite;
            GameObject.Find("TableGlow").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("OvenGlow").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (SpecialCondition == "FoodReadyBreakfast")
        {
            PlayerUseItem.FoodReady = "Ready";
            Sprite TableSprite = Resources.Load<Sprite>("breakfast");
            GameObject.Find("Table").GetComponent<SpriteRenderer>().sprite = TableSprite;
            GameObject.Find("TableGlow").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("FridgeGlow").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (SpecialCondition == "ChangePhase")
        {
            PlayerUseItem.CurrentPhase = "Morning";
        }
        if (SpecialCondition == "ChangePhaseEnd")
        {
            PlayerUseItem.CurrentPhase = "Afternoon";
            PlayerUseItem.FoodReady = "NotReady";
            PlayerUseItem.RadioUsed = "RadioUnused";
            PlayerUseItem.Wallet = "notGrabbed";
            PlayerUseItem.Dressed = "notDressed";
            PlayerUseItem.HairbrushUsed = "HairbrushUnused";
            PlayerUseItem.ToothpasteUsed = "Unused";
            GameObject.Find("BedGlow").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("WalletGlow").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("ToothGlow").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("FridgeGlow").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("OvenGlow").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("WardrobeGlow").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("ClothesGlow").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("FrontDoorGlow").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (SpecialCondition == "FoodNotReady")
        {
            PlayerUseItem.FoodReady = "NotReady";
            Sprite TableSprite = Resources.Load<Sprite>("table");
            GameObject.Find("Table").GetComponent<SpriteRenderer>().sprite = TableSprite;
            GameObject.Find("TableGlow").GetComponent<SpriteRenderer>().enabled = false;
            if (PlayerUseItem.CurrentPhase == "Morning")
            {
                GameObject.Find("FridgeGlow").GetComponent<SpriteRenderer>().enabled = true;

            }
            else
            {
                GameObject.Find("OvenGlow").GetComponent<SpriteRenderer>().enabled = true;
            }
        }

        if (SpecialCondition == "RadioUsedM")
        {
            PlayerUseItem.RadioUsed = "RadioUsed";
            Sprite RadioSprite = Resources.Load<Sprite>("radiosong");
            GameObject.Find("Radio").GetComponent<SpriteRenderer>().sprite = RadioSprite;
            GameObject.Find("RadioGlow").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (SpecialCondition == "RadioUsedN")
        {
            PlayerUseItem.RadioUsed = "RadioUsed";
            Sprite RadioSprite = Resources.Load<Sprite>("radionews");
            GameObject.Find("Radio").GetComponent<SpriteRenderer>().sprite = RadioSprite;
            GameObject.Find("RadioGlow").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (SpecialCondition == "HairbrushUsed")
        {
            PlayerUseItem.HairbrushUsed = "HairbrushUsed";
            GameObject.Find("BrushGlow").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (SpecialCondition == "Dirty")
        {
            PlayerUseItem.Dressed = "Dressed";
            GameObject.Find("WardrobeGlow").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("ClothesGlow").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (SpecialCondition == "Clean")
        {
            PlayerUseItem.Dressed = "Dressed";
            GameObject.Find("WardrobeGlow").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("ClothesGlow").GetComponent<SpriteRenderer>().enabled = false;
        }

        if (SpecialCondition == "SixHours")
        {

            PlayerUseItem.CurrentPhase = "Morning";
            GameObject.FindGameObjectWithTag("PlayerInformation").GetComponent<PlayerInformationScript>().howWellSlept = PlayerInformationScript.HowWellSlept.sixHours;

            PlayerUseItem.Dressed = "notDressed";
            PlayerUseItem.ToothpasteUsed = "Unused";
            GameObject.Find("BedGlow").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("WalletGlow").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("ToothGlow").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("FridgeGlow").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("OvenGlow").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("WardrobeGlow").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("ClothesGlow").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("FrontDoorGlow").GetComponent<SpriteRenderer>().enabled = true;

        }
        if (SpecialCondition == "EightHours")
        {
            GameObject.FindGameObjectWithTag("PlayerInformation").GetComponent<PlayerInformationScript>().howWellSlept = PlayerInformationScript.HowWellSlept.eightHours;
            PlayerUseItem.CurrentPhase = "Morning";

            PlayerUseItem.Dressed = "notDressed";
            PlayerUseItem.ToothpasteUsed = "Unused";
            GameObject.Find("BedGlow").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("WalletGlow").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("ToothGlow").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("FridgeGlow").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("OvenGlow").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("WardrobeGlow").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("ClothesGlow").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("FrontDoorGlow").GetComponent<SpriteRenderer>().enabled = true;
        }

        if (SpecialCondition == "TenHours")
        {
            GameObject.FindGameObjectWithTag("PlayerInformation").GetComponent<PlayerInformationScript>().howWellSlept = PlayerInformationScript.HowWellSlept.tenHours;
            PlayerUseItem.CurrentPhase = "Morning";

            PlayerUseItem.Dressed = "notDressed";
            PlayerUseItem.ToothpasteUsed = "Unused";
            GameObject.Find("BedGlow").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("WalletGlow").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("ToothGlow").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("FridgeGlow").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("OvenGlow").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("WardrobeGlow").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("ClothesGlow").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("FrontDoorGlow").GetComponent<SpriteRenderer>().enabled = true;
			Debug.Log("10 HOURS SLEEP");

        }

        if(SpecialCondition == "Wallet")
        {
            PlayerUseItem.Wallet = "Grabbed";
            GameObject.Find("WALLET").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("WalletGlow").GetComponent<SpriteRenderer>().enabled = false;

        }
        if (SpecialCondition == "Toothpaste")
        {
            PlayerUseItem.ToothpasteUsed = "Used";
            GameObject.Find("ToothGlow").GetComponent<SpriteRenderer>().enabled = false;
        }
        ClockScript GM = GameObject.Find("GameManager").GetComponent<ClockScript>();
        Transform CanvasTrans = GameObject.Find("Canvas").GetComponent<Transform>();
        GameObject Plus = GameObject.Find("Plus");
        Transform PlayerTrans = GameObject.Find("Character").GetComponent<Transform>();
        Vector3 PlayerPos = PlayerTrans.localPosition;
        GM.progressTimeByMinutes((float)TimeUsed);
        var newPlus = Instantiate(Plus, PlayerPos, Quaternion.identity, CanvasTrans);
        newPlus.gameObject.tag = "Plus";
        Invoke("DestroyPlusClone", 0.1f);

    }
    // Update is called once per frame

        private void DestroyPlusClone()
    {
        Destroy(GameObject.FindGameObjectWithTag("Plus"));

    }
    void Update()
    {
    }
    static public void  ChangePhase()
    {
        //if (timeofday == "Morning")
        //{
            PlayerUseItem.CurrentPhase = "Morning";

            PlayerUseItem.Dressed = "notDressed";
            PlayerUseItem.ToothpasteUsed = "Unused";
            GameObject.Find("BedGlow").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("WalletGlow").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("ToothGlow").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("FridgeGlow").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("OvenGlow").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("WardrobeGlow").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("ClothesGlow").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("FrontDoorGlow").GetComponent<SpriteRenderer>().enabled = true;
        /*}
        if (timeofday == "Afternoon")
        {
            PlayerUseItem.CurrentPhase = timeofday;

            PlayerUseItem.Dressed = "Dressed";
            PlayerUseItem.ToothpasteUsed = "Unused";
            GameObject.Find("BedGlow").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("WalletGlow").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("ToothGlow").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("FridgeGlow").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("OvenGlow").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("WardrobeGlow").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("ClothesGlow").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("FrontDoorGlow").GetComponent<SpriteRenderer>().enabled = false;
        }*/
    }
}
