// This script is only for testing purpose.
// We would need a Enemy AI so that our demon will attack by its own.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon_Controller : MonoBehaviour
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
        if(horizontalInput < 0){
            transform.localScale = new Vector3(4,4,4);
        }
        else if(horizontalInput > 0){
            transform.localScale = new Vector3(-4,4,4);
        }

        if(Input.GetKey(KeyCode.Backspace)){
            anim.SetTrigger("death");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetTrigger("cleave");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetTrigger("take_hit");
        }
        //Setting animation parameters
        anim.SetBool("walk", horizontalInput != 0);
    }
}
