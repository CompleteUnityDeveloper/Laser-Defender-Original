using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour {

    void Start()
    {
        SetupSingleton();
    }

    private void SetupSingleton()
    {
        int numberOfSingletons = FindObjectsOfType<Singleton>().Length;
        if (numberOfSingletons > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
