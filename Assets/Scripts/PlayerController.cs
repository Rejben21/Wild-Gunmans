using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xPos;
    public bool dontMove;
    public bool canMove;

    [Header("Jumping")]

    public Transform groundPoint;
    private bool isGrounded;
    public LayerMask whatIsGround;

    private float jumpForce = 15;
    public KeyCode jumpInput;

    private new Rigidbody2D rigidbody;

    [Header("Shooting")]

    public GameObject bullet;
    public Transform firePoint;
    public KeyCode shootInput;
    public bool shootLeft;
    private float reloadTime;

    public Animator gunAnim;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        reloadTime = 0;

        xPos = transform.position.x;
    }

    void Update()
    {
        if (canMove)
        {
            if (dontMove)
            {
                transform.position = new Vector2(xPos, transform.position.y);
            }

            //Jumping
            isGrounded = Physics2D.OverlapCircle(groundPoint.position, 0.05f, whatIsGround);

            if (Input.GetKeyDown(jumpInput) && isGrounded)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
            }

            //Shooting
            if (Input.GetKeyDown(shootInput) && reloadTime <= 0)
            {
                if (shootLeft)
                {
                    Instantiate(bullet, firePoint.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                }
                else
                {
                    Instantiate(bullet, firePoint.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                }

                AudioManager.instance.PlaySFX(Random.Range(10, 12));
                gunAnim.SetTrigger("Shoot");
                reloadTime = .35f;
            }

            if (reloadTime > 0)
            {
                reloadTime -= Time.deltaTime;
            }
        }
    }
}
