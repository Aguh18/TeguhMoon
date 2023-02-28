using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    Animator anim;
    
    private Vector2 moveDirection;

    // Start is called before the first frame update
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       processInput();
    }
    private void FixedUpdate() {
         Move();
    }
    void processInput(){
        
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX,moveY).normalized;
        anim.SetFloat("Speed", moveDirection.sqrMagnitude);
        
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
        anim.SetFloat("Horizontal",moveX);
        anim.SetFloat("Vertical", moveY);
        }
       
       
    }
    private void Move(){
        rb.velocity = new Vector2(moveDirection.x*speed,moveDirection.y*speed );
    }
}
