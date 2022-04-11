using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bull : MonoBehaviour
{

    public float time = 5f;
 
    float cur = 0f;

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
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy" ){
            Destroy(gameObject);
        }
    }
}
