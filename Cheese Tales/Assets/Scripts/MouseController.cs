using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MouseController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private float jumpForce;
    private bool canDoubleJump;
    public LayerMask walkableLayer;

    public static bool canMove = true;
    [SerializeField] float rayLength;
 

   
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (rb.velocity.y < -13)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (canMove)
        {
            Move();
            Jump();
            anim.SetBool("CanMove", true);
        }
        else
        {
            rb.velocity = Vector2.zero;
            anim.SetBool("CanMove", false);
        }
        
    }
   
    private void Jump()
    {
        
        if(isGrounded())
        {
            canDoubleJump = true;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(isGrounded())
            {
                anim.SetTrigger("Jump");
                rb.velocity = Vector2.up * jumpForce;
            }
            else
            {
                if(canDoubleJump)
                {
                    anim.SetTrigger("Jump");
                    rb.velocity = Vector2.up * jumpForce;
                    canDoubleJump = false;
                }
            }
          
        }
        Fall();
        
    }
    private void Fall()
    {
        if(rb.velocity.y < -1f)
        {
            
            anim.SetBool("CanFall", true);
        }
        else
        {
            
            anim.SetBool("CanFall", false);
        }
    }
    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);

        if(rb.velocity.magnitude > 0)
        {
            if (x < 0)
            {
                this.transform.rotation = Quaternion.Euler(new Vector2(0f, 180f));
            }
            else
            {
                this.transform.rotation = Quaternion.identity;
            }
        }
        anim.SetFloat("Walk", Mathf.Abs(x));
    }

  
    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up,rayLength,walkableLayer);
        if (hit.collider != null)
        {
           
            if (hit.collider.tag == "Ground" || hit.collider.tag == "JumpPad")         //change after design
            {
                return true;
            }
            else if (hit.collider.tag == "Platform")
            {

                this.transform.SetParent(hit.collider.gameObject.transform);
                return true;
            }
            
        }
        else
        {
            
            this.transform.SetParent(null);
            return false;
        }
        return false;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(this.transform.position, -Vector2.up * rayLength);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag =="Key")
        {
            GameObject.FindObjectOfType<TransitionDoor>().isUnlocked = true;
            Destroy(other.gameObject);
        }
    }
}
