using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Game : MonoBehaviour
{
	[SerializeField] int score = 0; // todo private

    private void Awake()
    {
        SetupSingleton();
    }

    private void SetupSingleton()
    {
        int gameCount = FindObjectsOfType<Game>().Length;
        if (gameCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

	public void Score(int points)
    {
		score += points;
	}

    public void ResetGame()
    {
        Destroy(gameObject);
    }
 
}
