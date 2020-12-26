using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float backgroundScrollSpeed = 0.02f;
    
    // The material from the texture
    Material myMaterial;

    // The movement
    Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Get the material of the background
        myMaterial = GetComponent<Renderer>().material;
        // Scroll in the y-axis
        offset = new Vector2(0f, backgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
       // Move the material
        myMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
