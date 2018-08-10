using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Game : MonoBehaviour
{
	[SerializeField] int score = 0; // todo private

    public int GetScore()
    {
        return score;
    }

	public void Score(int points)
    {
		score += points;
	}

    private void OnWhyTF(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0) // assumes build index 0 is menu
        {
            score = 0;
        }
    }
}
