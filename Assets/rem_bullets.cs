using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rem_bullets : MonoBehaviour
{
    static public int remaining = 40;
    Text rem;
    // Start is called before the first frame update
    void Start()
    {
        rem = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(remaining == 0){
            rem.text = "No more ammo left";
        }
        else rem.text = "Remaining Bullets: " + remaining;
    }
}
