using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateControl : MonoBehaviour
{
    public Transform player;

    public Transform target;
    public float zAngle;

    public bool lookDown;

    void Start()
    {
        
    }

    void Update()
    {
        if (lookDown)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, player.rotation.z * -1));
        }
        else
        {
            Vector3 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(zAngle + angle, Vector3.forward);
        }
    }
}
