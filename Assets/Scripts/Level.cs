using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class Level : MonoBehaviour
{
    // state variables TODO consider or challenge level play time

    // configuration parameters

    // cached references

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<Game>().ResetGame();
    }


    public void QuitRequest()
    {
		Application.Quit();
	}

    public static Transform GetSpawnParent()
    {
        const string GAMEOBJECT_NAME = "SpawnedObjects";
        var spawnParent = GameObject.Find(GAMEOBJECT_NAME);
        if (spawnParent)
        {
            return spawnParent.transform;
        }
        else
        {
            Debug.LogWarning("Please create a root Game Object called " + GAMEOBJECT_NAME);
            return null;
        }
    }
}
