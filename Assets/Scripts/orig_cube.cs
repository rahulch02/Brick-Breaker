using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orig_cube : MonoBehaviour
{
    Rigidbody rb;

    public GameObject coinobject;

    public GameObject plain_object;
    GameObject plane;
    float plane_time = 2f;
    float planer = 2f;

    float boost_time = 3f; 

    public GameObject bulletprefab;
    GameObject bulletobject;

    public GameObject enemy_plane;
    GameObject enemy;
    System.Random rd = new System.Random();

    public Camera playercam;

    public float speed = 8f;

    float spawntime = 1f;
    float cur_spawntime = 0f;

    public float bull_speed = 40f;

    // float v = transform.position.y;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    float xd = 0f;
    bool auth = true;
    public int max_jumps = 3;
    int cur_jumps = 3; 
    
    // Update is called once per frame
    void Update()
    { 
        if(rb.velocity.x == 0){
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
        }

        else{
            rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
        }
        
        if(cur_spawntime >= spawntime){
            int rand_num = rd.Next(-15,13);
            int rand2 = rd.Next(0,2);
            cur_spawntime = 0f;
            if(spawntime > 0.4) spawntime -= 0.02f;
            enemy = Instantiate(enemy_plane, new Vector3(rand_num, transform.position.y + rand2 , transform.position.z + 60f), Quaternion.identity);
        }
        else
        {
            cur_spawntime += Time.deltaTime;
        }

        if(plane_time >= planer)
        {
            int rand_num = rd.Next(-15,13);
            int rand2 = rd.Next(2,3);
            plane_time = 0f;
            planer = 1f*rd.Next(4,6);
            plane = Instantiate(plain_object, new Vector3(rand_num, transform.position.y + rand2 , transform.position.z + 60f), Quaternion.identity);
            Vector3 plane_pos = plane.transform.position;
            float plane_length = plane.transform.lossyScale.z;
            int n = (int)(plane_length+2)/6;
            float z1 = plane_pos.z - plane_length/2;
            GameObject[] coins = new GameObject[n];
            float[] pos = new float[n];
            float f1 = 0f;
            while(n > 0){
                coins[n-1] = Instantiate(coinobject, new Vector3(plane_pos.x,plane_pos.y+3.3f,z1+f1), Quaternion.identity);
                f1 += 4f;

                n--;
            }
        }

        else
        {
            plane_time += Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space) & cur_jumps > 0){
            rb.AddForce(0,5f,0,ForceMode.Impulse);
            auth = false;
            cur_jumps -= 1;
        }
        if(auth){
            
            if(Input.GetKeyDown("s") && rb.velocity.z >2f){
                rb.AddForce(-transform.forward*1f,ForceMode.Impulse);
            }
            if(Input.GetKey("a")){
                rb.velocity = Vector3.left*5f;
            }
            if(Input.GetKey("d")){
                rb.velocity = Vector3.right*5f;
            }
            
        }
        
        if(Input.GetKey("w")){
            if(xd < 3f){
                rb.AddForce(transform.forward*0.2f,ForceMode.Impulse);
                xd = 0f;
            }
            else xd += Time.deltaTime;
        }

        if(rb.velocity.z < speed)
        {
            rb.AddForce(transform.forward*1f , ForceMode.Impulse);
        }

        if(transform.position.y < -(3f)){
            Destroy(gameObject);
        }

        if (Input.GetButtonDown("Fire1") & rem_bullets.remaining>0)
        {
           Vector3 vel = rb.velocity;
           bulletobject = Instantiate(bulletprefab, new Vector3(transform.position.x,transform.position.y,transform.position.z+3f), Quaternion.identity);
           rem_bullets.remaining -= 1;
           Vector3 shootDirection = Input.mousePosition;
           Vector3 cam_pos = playercam.ScreenToWorldPoint(new Vector3(playercam.transform.position.x,playercam.transform.position.y,playercam.nearClipPlane));
           shootDirection = playercam.ScreenToWorldPoint(new Vector3(shootDirection.x,shootDirection.y,40f));
           shootDirection = shootDirection - cam_pos;
            // shootDirection.z = 40f;
            // shootDirection = shootDirection-transform.position;
            // Rigidbody2D bulletobject = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
            bulletobject.GetComponent<Rigidbody>().velocity = new Vector3(2f*shootDirection.x,2f*shootDirection.y,(bull_speed+vel.z));
        }
    
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Enemy" ){
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Ground" | collision.gameObject.tag == "plane"){
            auth = true;
            cur_jumps = max_jumps;

        }
        
    }
}
