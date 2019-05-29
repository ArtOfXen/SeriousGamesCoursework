using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapScript : MonoBehaviour {

    public Image minimapArrow;

    private Vector2 entranceHallArrowLocation;
    private Vector2 kitchenArrowLocation;
    private Vector2 livingRoomArrowLocation;
    private Vector2 bathroomArrowLocation;
    private Vector2 bedroomArrowLocation;

    private float currentArrowOffset;
    private string currentArrowDirection;
    private Vector3 minimapArrowStaticPosition;

	// Use this for initialization
	void Start () {
        entranceHallArrowLocation = new Vector2(36f, 22f);
        kitchenArrowLocation = new Vector2(-28.5f, 22f);
        livingRoomArrowLocation = new Vector2(5f, 22f);
        bathroomArrowLocation = new Vector2(5f, 49f);
        bedroomArrowLocation = new Vector2(5f, -18.5f);

        minimapArrow.GetComponent<RectTransform>().localPosition = entranceHallArrowLocation;

        currentArrowDirection = "up";
        currentArrowOffset = 0f;
        minimapArrowStaticPosition = minimapArrow.GetComponent<RectTransform>().localPosition;
    }
	
	// Update is called once per frame
	void Update () {
        // arrow bounce
        // move up until 1f about normal position
		if (currentArrowDirection == "up")
        {
            if (currentArrowOffset < 1f)
            {
                currentArrowOffset += 0.1f;
            }
            else
            {
                currentArrowDirection = "down";
            }
        }
        //move down until 1f under normal position
        else
        {
            if (currentArrowOffset > -1f)
            {
                currentArrowOffset -= 0.1f;
            }
            else
            {
                currentArrowDirection = "up";
            }
        }

        Vector3 newArrowPosition = new Vector3(minimapArrowStaticPosition.x, minimapArrowStaticPosition.y + currentArrowOffset, minimapArrowStaticPosition.z);
        minimapArrow.GetComponent<RectTransform>().localPosition = newArrowPosition;

	}

    public void changeRoom(string newRoom)
    {
        switch(newRoom)
        {
            case "entranceHall":
                minimapArrow.GetComponent<RectTransform>().localPosition = entranceHallArrowLocation;
                minimapArrowStaticPosition = entranceHallArrowLocation;
                break;

            case "livingRoom":
                minimapArrow.GetComponent<RectTransform>().localPosition = livingRoomArrowLocation;
                minimapArrowStaticPosition = livingRoomArrowLocation;
                break;

            case "bathroom":
                minimapArrow.GetComponent<RectTransform>().localPosition = bathroomArrowLocation;
                minimapArrowStaticPosition = bathroomArrowLocation;
                break;

            case "bedroom":
                minimapArrow.GetComponent<RectTransform>().localPosition = bedroomArrowLocation;
                minimapArrowStaticPosition = bedroomArrowLocation;
                break;

            case "kitchen":
                minimapArrow.GetComponent<RectTransform>().localPosition = kitchenArrowLocation;
                minimapArrowStaticPosition = kitchenArrowLocation;
                break;

            default:
                Debug.Log("MINIMAP ARROW LOCATION NOT FOUND. INPUT STRING INCORRECT.");
                break;
        }
    }
}
