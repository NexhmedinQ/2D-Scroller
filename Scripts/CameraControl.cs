using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // fix this to make the foreground smaller
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        // player.position.y + cam.orthographicSize * 0.5f
    }
}
