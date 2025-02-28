using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    float vertical;
    float horizontal;
    Rigidbody rb;
    Transform transf;
    float JumpForce = 120f;
    bool isGrounded = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transf = GetComponent<Transform>();
    }


    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        rb.AddRelativeForce(0, 0, vertical*50f);
        transf.Rotate(0, horizontal, 0);


        if(Input.GetKeyDown("space") && isGrounded == true){
            rb.drag = 3;
            rb.angularDrag = 3;
            rb.AddForce(0, JumpForce, 0, ForceMode.Impulse);
        }
    }
    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "ground"){
            isGrounded = true;
            rb.drag = 0;
            rb.angularDrag = 0.05f;
        }
        if(col.gameObject.tag == "coin"){
            Destroy(col.gameObject);
        }
    }

    void OnCollisionExit(Collision col){
        if(col.gameObject.tag == "ground"){
            isGrounded = false;
        }
    }
}
