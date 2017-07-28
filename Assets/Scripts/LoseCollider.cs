using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;

    // Trigger => Ignore the physics
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        Brick.breakebleCount = 0;
        print("Trigger");
        levelManager.LoadLevel("Lose");
    }

    // Collider => Apply the physics
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }

    // Use this for initialization
    void Start () {
        // Dont need to associate on editor
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
