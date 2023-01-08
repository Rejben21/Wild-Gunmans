using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    private new Rigidbody2D rigidbody;

    public float timeToExplode;
    private float timer;

    public GameObject explosion;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        float randomForce = Random.Range(-2, 2);
        rigidbody.velocity = new Vector2(randomForce, 0);
        rigidbody.AddTorque(randomForce * 10);

        AudioManager.instance.PlaySFX(14);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timeToExplode)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            AudioManager.instance.PlaySFX(13);
            Destroy(gameObject);
        }
    }
}
