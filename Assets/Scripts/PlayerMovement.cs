using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jump = 5;
    [SerializeField] private LayerMask groundLayer; 
    [SerializeField] private Transform groundCheck; 
    private Rigidbody2D body;
    private Animator anim;
    private bool isGrounded;
    private float groundCheckRadius = 0.2f;

    private bool atk_1;
    private void Awake() {
        //Getting the references of components
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Flips the player when it moves left-right
        if(horizontalInput > 0){
            transform.localScale = new Vector3(4,4,4);
        }
        else if(horizontalInput < 0){
            transform.localScale = new Vector3(-4,4,4);
        }

        // // New jump Logic
        // if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
        //     body.velocity = new Vector2(body.velocity.x, jump );
        //     anim.SetTrigger("j_up"); // Trigger jump up animation
        // }

        // // Play fall animation when falling
        // if(!isGrounded && body.velocity.y < 0){
        //     anim.SetTrigger("j_down"); // Trigger jump down animation
        // }

        //earlier Logic to implement Jump but makes player fly by pressing space multiple times
        if(Input.GetKey(KeyCode.Space)){
            body.velocity = new Vector2(body.velocity.x, jump );
        }

        // animations triggers
        if(Input.GetKey(KeyCode.Backspace)){
            anim.SetTrigger("death");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetTrigger("1_atk");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetTrigger("2_atk");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            anim.SetTrigger("3_atk");
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            anim.SetTrigger("sp_atk");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            anim.SetTrigger("air_atk");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger("defend");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            anim.SetTrigger("roll");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("take_hit");
        }

        //Setting animation parameters
        anim.SetBool("run", horizontalInput != 0);
        //anim.SetBool("death", death);
        //anim.SetBool("1_atk", atk_1);
    }
}
