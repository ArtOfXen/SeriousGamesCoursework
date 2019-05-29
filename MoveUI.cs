using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUI : MonoBehaviour {
    [SerializeField] private RectTransform Livingroom;
    [SerializeField] private RectTransform Bathroom;
    [SerializeField] private RectTransform Kitchen;
    [SerializeField] private RectTransform Bedroom;
    [SerializeField] private RectTransform Entrance;
    // Use this for initialization
    void Start () {
        Livingroom.localPosition = new Vector3(0, 0, 0);
        Bathroom.localPosition = new Vector3(0, 0, 0);
        Kitchen.localPosition = new Vector3(0, 0, 0);
        Bedroom.localPosition = new Vector3(0, 0, 0);
        Entrance.localPosition = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
