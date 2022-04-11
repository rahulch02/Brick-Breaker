using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies : MonoBehaviour
{
    public float time = 13f;
    public float enemy_speed = 20f;
    float cur = 0f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {

        if(cur > time)
        {
            Destroy(gameObject);
        }
        else
        {
            cur += Time.deltaTime;
        }
        rb.velocity = -Vector3.forward*enemy_speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bullet" ){
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "plane" ){
            Collision cd = GetComponent<Collision>();
            Physics.IgnoreCollision(collision.collider,cd.collider);
        }
    }
}
