using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level : MonoBehaviour
{
    // state variables
    // todo consider or challenge level play time

    // configuration parameters

    // cached references

	public void LoadLevel(string name)
    {
		Debug.Log ("New Level load: " + name);
        SceneManager.LoadScene(name);
	}

	public void QuitRequest()
    {
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
}
