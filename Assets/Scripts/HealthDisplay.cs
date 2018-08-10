using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    void Update()
    {
        var myText = GetComponent<Text>();
        var player = FindObjectOfType<Player>();
        myText.text = player.GetCurrentHealth().ToString();
    }
}
