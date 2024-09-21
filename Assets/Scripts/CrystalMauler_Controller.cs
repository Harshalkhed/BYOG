using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalMauler_Controller : MonoBehaviour
{
    [SerializeField] private float speed;
    //[SerializeField] private float jump = 5;
    private Rigidbody2D body;
    private Animator anim;
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

        // Flips the player when it moves left-right
        if(horizontalInput > 0){
            transform.localScale = new Vector3(3,3,3);
        }
        else if(horizontalInput < 0){
            transform.localScale = new Vector3(-3,3,3);
        }

        //Setting animation parameters
        anim.SetBool("run", horizontalInput != 0);


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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump");  
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("take_hit");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            anim.SetTrigger("roll");
        }
    }
}
