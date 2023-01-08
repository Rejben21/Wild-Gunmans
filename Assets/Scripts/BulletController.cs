using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float moveSpeed;
    private new Rigidbody2D rigidbody;
    private bool hasHit;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        Destroy(gameObject, 2);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(other.gameObject.GetComponent<PlayerController>().shootLeft)
            {
                other.gameObject.GetComponent<Rigidbody2D>().AddTorque(-10);
            }
            else
            {
                other.gameObject.GetComponent<Rigidbody2D>().AddTorque(10);
            }
        }

        AudioManager.instance.PlaySFX(Random.Range(0, 9));
        Destroy(gameObject);
    }
}
