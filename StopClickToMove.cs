using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StopClickToMove : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	private PlayerControllerScript playerScript;

	// Use this for initialization
	void Start () {
		playerScript = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControllerScript>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		playerScript.mouseMovementEnabled = false;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		playerScript.mouseMovementEnabled = true;
	}

	void OnDisable()
	{
		playerScript.mouseMovementEnabled = true;
	}
}
