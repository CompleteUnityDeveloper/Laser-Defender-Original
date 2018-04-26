using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisplay : MonoBehaviour
{
    void Update()
    {
        var myText = GetComponent<Text>();
        var game = FindObjectOfType<Game>();
        myText.text = game.GetScore().ToString();
    }
}
