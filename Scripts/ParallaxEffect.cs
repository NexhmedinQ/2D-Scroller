using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField]
    private float parallax;
    [SerializeField]
    private GameObject cam;
    private float length, startPosX, startPosY;

    // Start is called before the first frame update
    void Start()
    {
        startPosX = transform.position.x;
        startPosX = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void LateUpdate() {
        float dist = cam.transform.position.x * parallax;
        transform.position = new Vector3(startPosX + dist, transform.position.y, transform.position.x);
    }

    
}
