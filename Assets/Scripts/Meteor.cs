using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

    public float speed = 1f;
    public bool go;
	// Use this for initialization
	void Start () {
        go = false;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if(pos.y < 0.0f)
        {
            go = true;
            
        }

        if (go)
        {
            this.transform.position += transform.up * Time.deltaTime * speed;
        }

        if(pos.y<2f && pos.x > 2.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
