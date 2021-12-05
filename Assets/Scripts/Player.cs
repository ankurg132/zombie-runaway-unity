using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private bool isGrounded = true;
    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";

    // public float maxVelocity = 22f;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }

    void FixedUpdate()
    {
        
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        print(movementX);
        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;
    }

    void AnimatePlayer()
    {
        if(movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if(movementX == 0)
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
    }

    void PlayerJump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == GROUND_TAG)
        {
            isGrounded = true;
        }
        if(collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
}
