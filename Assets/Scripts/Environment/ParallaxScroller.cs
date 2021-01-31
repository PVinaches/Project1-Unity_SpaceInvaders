using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroller : MonoBehaviour
{
    public Vector2 speed;
    // Renderer is from class py? -> polymorphism
    Renderer back;
    
    // Start is called before the first frame update
    void Start()
    {
        back = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // To eliminate the frame dependency (varies from computer!) => * Time.deltaTime
        Vector2 offset = speed * Time.deltaTime;

        back.material.mainTextureOffset += offset;
    }
}