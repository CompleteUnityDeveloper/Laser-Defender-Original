using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class Level : MonoBehaviour
{
    // state variables TODO consider or challenge level play time

    // configuration parameters

    // cached references

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
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
