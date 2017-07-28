using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    // Singleton using a counter
    static int musicPlayerCount = 0;

    // First method
    void Awake () {
        //Debug.Log("MusicPlayer Awake " + GetInstanceID());

        if (musicPlayerCount != 0)
        {
            Destroy(gameObject);
            print("Duplicate MusicPlayer self-destructing!");
        }
        else
        {
            musicPlayerCount++;
            print("MusicPlayer" + musicPlayerCount + " created!");
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        //Debug.Log("MusicPlayer Start " + GetInstanceID());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
