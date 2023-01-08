using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour
{
    private new Rigidbody2D rigidbody;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bullet") && transform.parent)
        {
            if (rigidbody == null)
            {
                rigidbody = gameObject.AddComponent<Rigidbody2D>();
            }

            if(GetComponentInParent<PlayerController>().shootLeft)
            {
                rigidbody.velocity = new Vector2(-Random.Range(-10, -5), Random.Range(5, 10));
                rigidbody.AddTorque(-360);
            }
            else
            {
                rigidbody.velocity = new Vector2(Random.Range(-10, -5), Random.Range(5, 10));
                rigidbody.AddTorque(360);
            }

            AudioManager.instance.PlaySFX(Random.Range(0, 9));
            transform.parent = null;
        }
    }
}
