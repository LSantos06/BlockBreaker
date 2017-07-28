using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    public float minX = 0.5f, maxX = 15.5f;
    private Ball ball; 

	// Use this for initialization
	void Start () {
       ball = GameObject.FindObjectOfType<Ball>();
       //print(ball);
    }
	
	// Update is called once per frame
	void Update () {
        if (!autoPlay){
            MoveWithMouse();
        }
        else {
            AutoPlay();
        }
    }

    void AutoPlay(){
        float ballPos = ball.transform.position.x;
        Vector3 paddlePos = new Vector3(Mathf.Clamp(ballPos, minX, maxX), this.transform.position.y);
        this.transform.position = paddlePos;
    }

    void MoveWithMouse(){
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        Vector3 paddlePos = new Vector3(Mathf.Clamp(mousePosInBlocks, minX, maxX), this.transform.position.y);
        this.transform.position = paddlePos;
    }
}
