using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float steerSpeed = 180f;
    [SerializeField] float moveSpeed = 25f;
    [SerializeField] float slowSpeed = 10f;
    [SerializeField] float boostSpeed = 30f;

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount); //rotar el objeto en cada frame
        transform.Translate(0, moveAmount, 0); 
        
    }    
    
    void OnCollisionEnter2D(Collision2D other) {
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
        }
    }
}
