using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject CurrentCheck;
    public KeyCode mouse;
    public GameUI scrpit;
    public GameUI gameUi;
    public float moveSpeed;
    public float jumpForce = 15f;
    public float WebFall;
    private float mx;
    private float jumpCoolDown;
    public int additionalJumps = 1;
    public int health;
    private int jumpCount = 0;
    public AimScript aimScript;
    public SlowFall slowFall;
    private bool isGrounded;
    public Vector2 respawnPoint;

    public Animator animator;

    [SerializeField] GameObject player;
    [SerializeField] LayerMask platformLayer;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform feet;
    
  

    void Start()
    {
        GameObject.Find("Eggbasket");
        health = 10;
        respawnPoint = transform.position;
      
    }

    private void Update()
    {
      
       //Cursor.visible = false;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float rotateY = 0f;

        animator.SetFloat("Speed", Mathf.Abs(mx));

        if (mousePos.x < transform.position.x)
        {
            rotateY = 180f;
        }
        transform.eulerAngles = new Vector3(transform.rotation.x, rotateY, transform.rotation.z);

        mx = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
            
        }

        CheckGrounded();
        
        if (isGrounded == true)
        {
            animator.SetBool("IsJumping", false);
        }
        else if (isGrounded == false)
        {
            animator.SetBool("IsJumping", true);
        }

        if (health <= 0)
        {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(mx * moveSpeed, rb.velocity.y);
    }


    void Jump()
    {
        //animator.SetBool("IsJumping", true);
        if (isGrounded || jumpCount < additionalJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
            
        }

    }

    void CheckGrounded()
    {
        if (Physics2D.OverlapCircle(feet.position, 0.1f, platformLayer))
        {
             
            isGrounded = true;
            jumpCount = 0;
            jumpCoolDown = Time.time + 0.05f;
            
        }

        else if (Time.time < jumpCoolDown)
        {
            isGrounded = true; 
           
        }

        else
        {
            isGrounded = false;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Trap"))
        {
            foreach (GameObject Egg in GameObject.FindGameObjectsWithTag("Egg"))
            {
                Destroy(Egg);
            }
            Debug.Log ("Hep");
            GetComponent<Rigidbody2D>().gravityScale = 5;
            aimScript.startForce = 13;
            health --;
            transform.position = respawnPoint;
        }

        if (collision.gameObject.CompareTag("Collectable"))
        {
            scrpit.timeLeft += 60;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("checkPoint"))
        {
            respawnPoint = transform.position;
            //aimScript.startForce = 0;
            scrpit.timerIsOn = false;
           
        }

        if (collider.gameObject.CompareTag("Icy"))
        {
            moveSpeed = 25;

        }
        if (collider.gameObject.CompareTag("Web"))
        {
            moveSpeed = 0.5f;
            jumpForce = 0;

        }
        if (collider.gameObject.CompareTag("Air web"))
        {
            GetComponent<Rigidbody2D>().drag = WebFall;
            moveSpeed = 1f;

        }
        

    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("checkPoint"))
        {
            scrpit.timerIsOn = true;
            aimScript.startForce = 13;
        }

        if (collider.gameObject.CompareTag("Icy"))
        {
            moveSpeed = 10;

        }
        if (collider.gameObject.CompareTag("Web"))
        {
            moveSpeed = 10f;
            jumpForce = 15;
        }
        if (collider.gameObject.CompareTag("Air web"))
        {
            GetComponent<Rigidbody2D>().drag = 0;
            moveSpeed = 10f;
        }
    }
       
    }




                    
                
      


                               