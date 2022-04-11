using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour
{
    private float  time = 0f;
    Rigidbody rx;
    float pos;  
    void Start()
    {
        pos = transform.position.y;
        rx = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(time >= 10f){
            Destroy(gameObject);
        }
        time += Time.deltaTime;
        
        
        if(rx.velocity.y == 0){
            if(transform.position.y > 4f)  rx.velocity = Vector3.down*2f;
            else rx.velocity = Vector3.up*2f;
        }
        rx.AddForce(Vector3.up*(pos-transform.position.y)*4f,ForceMode.Force);
            
    }
    private void OnTriggerEnter(Collider collide){
        if(collide.gameObject.tag == "Player"){
            ScoreScript.scorevalue += 1;
            rem_bullets.remaining += 1;
            Destroy(gameObject);
        }
    }
}
