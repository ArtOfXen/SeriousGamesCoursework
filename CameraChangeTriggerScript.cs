using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeTriggerScript : MonoBehaviour {

    private BoxCollider2D trigger;

    public string nextRoom;
    public Vector2 newCameraLocation;
    public Vector2 newPlayerLocation;
    public string newPlayerDirection;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Camera.main.GetComponent<CameraFade>().triggerCameraChange(newCameraLocation, newPlayerLocation, nextRoom, newPlayerDirection);
        }
    }
}
