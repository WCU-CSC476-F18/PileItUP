using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildTower : MonoBehaviour {
    public static BuildTower CurrentCube { get; private set; }
    public static BuildTower LastCube { get; private set; }

    public float moveSpeed = 1f;

    // Cut blocks
    private float hangover;
    private float direction;
    private float newZSize;
    private float fallingBlockSize;
    private float newZPos;
    private float cubeEdge;
    private float fallingBlockZPos;
    private float newXPos;
    private float newXSize;
    private float fallingBlockXPos;

    private void OnEnable()
    {
        
        // add color to cube
        GetComponent<Renderer>().material.color = GetRandomColor();
        
        // the first cube
        if (LastCube == null)
        {
            // LastCube is the tower base
            LastCube = GameObject.Find("Tower Base").GetComponent<BuildTower>();
            LastCube.moveSpeed = 0;
            return;
        }
        // set current cube
        CurrentCube = this;
        CurrentCube.moveSpeed += 1f;

        transform.localScale = new Vector3(LastCube.transform.localScale.x, transform.localScale.y,
            LastCube.transform.localScale.z);
        
    }

    // Update is called once per frame
    private void Update () {
        //Cube goes in opposite direction
        if (Math.Abs(transform.position.z) > 5 || Math.Abs(transform.position.x)>5)
        {
            moveSpeed *= -1;
        }
        
        //If score is odd, move in z direction, else move in x direction
        if (GameManager.SCORE % 2 == 1)
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
        else
        {
            transform.position += transform.right * Time.deltaTime * moveSpeed;
        }

        }

    private Color GetRandomColor()
    {
        // get random color by randomizing RGB values
        return new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));
    }

    internal void Stop()
    {
        moveSpeed = 0;
        
        //if GameManager.SCORE is odd - split cube on z axis
        if (GameManager.SCORE % 2 == 1)
        {
            hangover = transform.position.z - LastCube.transform.position.z;

            if (Mathf.Abs(hangover) >= LastCube.transform.localScale.z)
            {
                CurrentCube = null;
                LastCube = null;

                SceneManager.LoadScene("End_Scene");
            }
            else
            {
                if (hangover > 0)
                {
                    direction = 1f;
                }
                else
                {
                    direction = -1f;
                }

                // fixes slicing error on initigal click
                if (hangover != 0)
                    SplitOnZ(hangover, direction);

                LastCube = this;
                LastCube.moveSpeed = 0;
            }
        }
        else//else GameManager.SCORE is even - split cube on x axis
        {
            hangover = transform.position.x - LastCube.transform.position.x;

            if (Mathf.Abs(hangover) >= LastCube.transform.localScale.x)
            {
                CurrentCube = null;
                LastCube = null;

                SceneManager.LoadScene("End_Scene");
            }
            else
            {

                if (hangover > 0)
                {
                    direction = 1f;
                }
                else
                {
                    direction = -1f;
                }

                // fixes slicing error on initigal click
                if (hangover != 0)
                    SplitOnX(hangover, direction);

                LastCube = this;
                LastCube.moveSpeed = 0;
            }
        }
    }

    private void SplitOnZ(float hangover, float direction)
    {
        newZSize = LastCube.transform.localScale.z - Mathf.Abs(hangover);
        fallingBlockSize = transform.localScale.z - newZSize;
        newZPos = LastCube.transform.position.z + (hangover / 2);

        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newZSize);
        transform.position = new Vector3(transform.position.x, transform.position.y, newZPos);

        cubeEdge = transform.position.z + (newZSize / 2f * direction);
        fallingBlockZPos = cubeEdge + fallingBlockSize / 2f * direction;

        SpawnDropBlock(fallingBlockZPos,0, fallingBlockSize);
    }

    //Split cube on the x axis
    private void SplitOnX(float hangover, float direction)
    {
        newXSize = LastCube.transform.localScale.x - Mathf.Abs(hangover);
        fallingBlockSize = transform.localScale.x - newXSize;
        newXPos = LastCube.transform.position.x + (hangover / 2);

        transform.localScale = new Vector3(newXSize, transform.localScale.y, transform.localScale.z);
        transform.position = new Vector3(newXPos, transform.position.y, transform.position.z);

        cubeEdge = transform.position.x + (newXSize / 2f * direction);
        fallingBlockXPos = cubeEdge + fallingBlockSize / 2f * direction;

        SpawnDropBlock(0,fallingBlockXPos, fallingBlockSize);
    }


    private void SpawnDropBlock(float fallingBlockZPos, float fallingBlockXPos, float fallingBlockSize)
    {
        var block = GameObject.CreatePrimitive(PrimitiveType.Cube);

        
        if (fallingBlockXPos == 0)//if going in z direction 
        {
            block.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, fallingBlockSize);
            block.transform.position = new Vector3(transform.position.x, transform.position.y, fallingBlockZPos);
        }
        else if(fallingBlockZPos ==0)//if going in x direction
        {
            block.transform.localScale = new Vector3(fallingBlockSize, transform.localScale.y, transform.localScale.z);
            block.transform.position = new Vector3(fallingBlockXPos, transform.position.y, transform.position.z);
        }


        // make split segment same color as the main block
        block.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;

        // put gravity on split segment so it drops
        block.AddComponent<Rigidbody>();
        Destroy(block.gameObject, 3f);
    }

}