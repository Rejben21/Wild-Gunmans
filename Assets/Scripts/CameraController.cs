using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform[] players;
    public float distance;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        distance = (Mathf.Abs(players[0].transform.position.x) + Mathf.Abs(players[1].transform.position.x)) / 2;

        cam.orthographicSize = distance;

        if (cam.orthographicSize >= 10)
        {
            cam.orthographicSize = 10;
        }
        else if(cam.orthographicSize <= 4)
        {
            cam.orthographicSize = 4;
        }
    }
}
