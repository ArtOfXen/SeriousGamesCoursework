using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManagerScript : MonoBehaviour {

    public float timeBetweenSpriteChanges;

    public Sprite[] walkLeft_clean;
    public Sprite[] walkLeft_dirty;
    public Sprite[] walkLeft_none;

    public Sprite[] walkRight_clean;
    public Sprite[] walkRight_dirty;
    public Sprite[] walkRight_none;

    public Sprite[] walkUp_clean;
    public Sprite[] walkUp_dirty;
    public Sprite[] walkUp_none;

    public Sprite[] walkDown_clean;
    public Sprite[] walkDown_dirty;
    public Sprite[] walkDown_none;

    public Sprite[] idleLeft_clean;
    public Sprite[] idleLeft_dirty;
    public Sprite[] idleLeft_none;

    public Sprite[] idleRight_clean;
    public Sprite[] idleRight_dirty;
    public Sprite[] idleRight_none;

    public Sprite[] idleUp_clean;
    public Sprite[] idleUp_dirty;
    public Sprite[] idleUp_none;

    public Sprite[] idleDown_clean;
    public Sprite[] idleDown_dirty;
    public Sprite[] idleDown_none;

    private Sprite[] currentSpriteArray;
    private int currentSpriteArrayElement;
    private int spriteArrayLastElement;

    private string currentAction;
    private string currentDirection;
    private string currentClothesState;

    private float lastFrameChange;

    // Use this for initialization
    void Start () {
        currentAction = "idle";
        currentDirection = "down";
        currentClothesState = "dirty";
        currentSpriteArray = idleDown_clean;
        lastFrameChange = 0.0f;
        currentSpriteArrayElement = 0;
}
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= lastFrameChange + timeBetweenSpriteChanges)
        {
            lastFrameChange = Time.time;
            currentSpriteArrayElement += 1;
            if (currentSpriteArrayElement > spriteArrayLastElement) { currentSpriteArrayElement = 0; }

            GetComponent<SpriteRenderer>().sprite = currentSpriteArray[currentSpriteArrayElement];
        }
        
	}

    public void updateSpriteClothes(string newClothesState)
    {
        currentClothesState = newClothesState;
    }

    public void updateSpriteArray(string newAction, string newDirection)
    {
        if (newAction != currentAction || newDirection != currentDirection)
        {
            if (newAction != currentAction)
            {
                currentSpriteArrayElement = 0;
            }

            currentAction = newAction;
            if (newDirection != "null") { currentDirection = newDirection; }
            
            if (currentAction == "idle")
            {
                spriteArrayLastElement = 6;

                switch (currentDirection)
                {
                    case "down":
                        if (currentClothesState == "clean") { currentSpriteArray = idleDown_clean; }
                        if (currentClothesState == "dirty") { currentSpriteArray = idleDown_dirty; }
                        if (currentClothesState == "none") { currentSpriteArray = idleDown_none; }
                        break;

                    case "up":
                        if (currentClothesState == "clean") { currentSpriteArray = idleUp_clean; }
                        if (currentClothesState == "dirty") { currentSpriteArray = idleUp_dirty; }
                        if (currentClothesState == "none") { currentSpriteArray = idleUp_none; }
                        break;

                    case "left":
                        if (currentClothesState == "clean") { currentSpriteArray = idleLeft_clean; }
                        if (currentClothesState == "dirty") { currentSpriteArray = idleLeft_dirty; }
                        if (currentClothesState == "none") { currentSpriteArray = idleLeft_none; }
                        break;

                    case "right":
                        if (currentClothesState == "clean") { currentSpriteArray = idleRight_clean; }
                        if (currentClothesState == "dirty") { currentSpriteArray = idleRight_dirty; }
                        if (currentClothesState == "none") { currentSpriteArray = idleRight_none; }
                        break;
                }

            }

            else if (currentAction == "walk")
            {
                spriteArrayLastElement = 3;

                switch (currentDirection)
                {
                    case "down":
                        if (currentClothesState == "clean") { currentSpriteArray = walkDown_clean; }
                        if (currentClothesState == "dirty") { currentSpriteArray = walkDown_dirty; }
                        if (currentClothesState == "none") { currentSpriteArray = walkDown_none; }
                        break;

                    case "up":
                        if (currentClothesState == "clean") { currentSpriteArray = walkUp_clean; }
                        if (currentClothesState == "dirty") { currentSpriteArray = walkUp_dirty; }
                        if (currentClothesState == "none") { currentSpriteArray = walkUp_none; }
                        break;

                    case "left":
                        if (currentClothesState == "clean") { currentSpriteArray = walkLeft_clean; }
                        if (currentClothesState == "dirty") { currentSpriteArray = walkLeft_dirty; }
                        if (currentClothesState == "none") { currentSpriteArray = walkLeft_none; }
                        break;

                    case "right":
                        if (currentClothesState == "clean") { currentSpriteArray = walkRight_clean; }
                        if (currentClothesState == "dirty") { currentSpriteArray = walkRight_dirty; }
                        if (currentClothesState == "none") { currentSpriteArray = walkRight_none; }
                        break;
                }
            }

            else
            {
                spriteArrayLastElement = 1;
                currentSpriteArray = idleDown_none;
            }

            lastFrameChange = Time.time;
            GetComponent<SpriteRenderer>().sprite = currentSpriteArray[currentSpriteArrayElement];
        }
    }
}
