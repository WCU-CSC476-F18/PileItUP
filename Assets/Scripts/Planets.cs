using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planets : MonoBehaviour {
    public float rotateSpeed = 15f;

	// Use this for initialization
	void Start () {
        rotateSpeed = 15f;

	}
	
	// Update is called once per frame
	void Update () {
        //rotate planets
        this.transform.Rotate(0,rotateSpeed * Time.deltaTime, 0);
	}
}
