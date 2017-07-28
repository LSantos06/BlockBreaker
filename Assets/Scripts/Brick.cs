using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public AudioClip crackSound;
    public static int breakebleCount = 0;
    public Sprite[] hitSprites;
    public GameObject smoke;

    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakeble;

    // Collider => Apply the physics
    private void OnCollisionExit2D(Collision2D collision) {
        //AudioSource.PlayClipAtPoint(crackSound, transform.position);
        if (isBreakeble) {
            HandleHits();
        }

    }

    void HandleHits() {
        timesHit++;
        // >= Future funcionalities
        if (timesHit >= (hitSprites.Length + 1)) {
            breakebleCount--;
            levelManager.BrickDestroyed();
            //print(breakebleCount);
            PuffSmoke();
            Destroy(gameObject);
        }
        // Change sprites
        else {
            LoadSprites();
        }
    }

    void PuffSmoke() {
        // Smoke
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity);
        ParticleSystem ps = smokePuff.GetComponent<ParticleSystem>();
        var main = ps.main;
        main.startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    // Use this for initialization
    void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();

        isBreakeble = (this.tag == "Breakeble");
        // Keep track of breakeble objects
        if (isBreakeble) {
            breakebleCount++;
            //print(breakebleCount);
        }
        timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadSprites () {
        // Element of the vector
        int spriteIndex = timesHit - 1;

        if (hitSprites[spriteIndex]) {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else {
            Debug.LogError("Brick missing sprite");
        }

    }

    // Remove after
    void SimulateWin () {
        levelManager.LoadNextLevel();
    }
        
}
