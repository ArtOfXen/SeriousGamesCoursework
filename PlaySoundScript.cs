using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundScript : MonoBehaviour {

	private bool currentlyPlayingList;
	private List<AudioClip> currentList;
	private int currentListElement;
	private int lastListElement;

	// Use this for initialization
	void Start () {
		currentlyPlayingList = false;
		currentList = new List<AudioClip> ();
		currentListElement = 0;
		lastListElement = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentlyPlayingList) {
			if (!GetComponent<AudioSource>().isPlaying)
			{
				playAudioClip(currentList[currentListElement]);
				currentListElement++;

				if (currentListElement > lastListElement)
				{
					currentlyPlayingList = false;
					currentList.Clear ();
				}
			}
		}
	}


    public void playAudioClip(AudioClip audioClip)
    {
		GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(audioClip, 0.7f);
    }

	public void playAudioClipList(List<AudioClip> listOfClips)
	{
		currentList = listOfClips;
		currentListElement = 0;
		lastListElement = listOfClips.Count - 1;
		currentlyPlayingList = true;
	}

	public void stopAudio()
	{
		GetComponent<AudioSource>().Stop();
	}

}
