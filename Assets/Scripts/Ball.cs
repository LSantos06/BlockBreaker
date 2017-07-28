using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private Rigidbody2D rigidBody2D;
    private bool hasStarted = false;

    // Collider => Apply the physics
    private void OnCollisionEnter2D(Collision2D collision) {
        Vector2 tweak = new Vector2(Random.Range(0,0.2f), Random.Range(0, 0.2f));
        //print(tweak);

        // audio.play() in Unity 5
        if (hasStarted) {
            //GetComponent<AudioSource>().Play();
            rigidBody2D.velocity += tweak;
        }

    }

    void Awake() {
        // RigidBody2D in Unity 5
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
        // Dont need to associate on editor
        paddle = GameObject.FindObjectOfType<Paddle>();

        paddleToBallVector = this.transform.position - paddle.transform.position;
        //print(paddleToBallVector.y);


	}
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted) {
            // Lock the ball relative to the paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;

            // Wait for a mouse press to lauch
            if (Input.GetMouseButtonDown(0)) {
                print("Mouse clicked, launch ball!");
                hasStarted = true;
                rigidBody2D.velocity = new Vector2(2f, 10f);
            }
        }
	}
}
