using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    static int sceneIndex = 2;

    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for " + name);
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        // Bug in video
        //Brick.breakebleCount = 0;
        print(sceneIndex);
        // Win scene
        if(sceneIndex == 5) {
            sceneIndex = 2;
        }
        SceneManager.LoadScene(sceneIndex++);
    }

    public void BrickDestroyed() {
        // Last brick destroyed
        if (Brick.breakebleCount <= 0){
            LoadNextLevel();
        }
    }

}
