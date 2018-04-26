using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{	
    // configuration parameters, consdier SO
    [SerializeField] AudioClip startClip;
	[SerializeField] AudioClip gameClip;
	[SerializeField] AudioClip endClip;

    // private instance variables for state

    // cached references for readability

    // messages, then public methods, then private methods...
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading; // always unsubscribe
    }

    void Start ()
    {
        SetupSingleton();
        PlayMusicForScene(SceneManager.GetActiveScene());
    }

    private void SetupSingleton()
    {
        int musicPlayerCount = FindObjectsOfType<MusicPlayer>().Length;
        if (musicPlayerCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(scene);
    }

    private void PlayMusicForScene(Scene scene)
    {
        var audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        if (scene.buildIndex == 0)
        {
            audioSource.clip = startClip;
        }
        if (scene.buildIndex == 1)
        {
            audioSource.clip = gameClip;
        }
        if (scene.buildIndex == 2)
        {
            audioSource.clip = endClip;
        }
        audioSource.loop = true;
        audioSource.Play();
    }
}
