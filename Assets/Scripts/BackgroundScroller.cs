using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

    [SerializeField] float backgroundScrollSpeed = 1f;

    Material myMaterial;
    Vector2 offSet;


    private void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offSet = new Vector2(0f, backgroundScrollSpeed);
    }
    private void Update()
    {
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}
