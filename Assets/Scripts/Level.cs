using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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
		Application.Quit ();
	}
}
