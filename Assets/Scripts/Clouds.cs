using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    //Speed of clouds
    public float speed = .75f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //move cloud along cloud's x-axis
        this.transform.position += transform.right * Time.deltaTime * speed;

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
       
        if (pos.x < -0.25f)//if the cloud goes off the screen 
        {
            //Move cloud to the left side of the screen
            Vector3 camPos = Camera.main.ViewportToWorldPoint(new Vector3(1.25f, pos.y, pos.z));
            this.transform.position = new Vector3(camPos.x, this.transform.position.y, camPos.z);
        }
    }
}
