using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewCube : MonoBehaviour {
    public BuildTower cubePrefab;
    private GameObject xSpawn;
    private GameObject zSpawn;

   

	
    // Use this for initialization
	void Start () {
     
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnCube()
    {
        var cube = Instantiate(cubePrefab);

        if (BuildTower.LastCube != null && BuildTower.LastCube.gameObject != GameObject.Find("Tower Base"))
        {

            
            //if odd score, spawn at z spawn
            if (GameManager.SCORE % 2 == 1)
            {
                zSpawn = GameObject.FindGameObjectWithTag("ZSpawn");
                cube.transform.position = new Vector3(BuildTower.LastCube.transform.position.x, BuildTower.LastCube.transform.position.y
                                    + cubePrefab.transform.localScale.y, zSpawn.transform.position.z);
            }
            else//else spawn at x spawn
            {
                xSpawn = GameObject.FindGameObjectWithTag("XSpawn");
                cube.transform.position = new Vector3(xSpawn.transform.position.x, BuildTower.LastCube.transform.position.y
                                                       + cubePrefab.transform.localScale.y, BuildTower.LastCube.transform.position.z);
                
            }
            
            

            //cube.GetComponent<BuildTower>().moveSpeed += 1f;
        }
        else
        {
            cube.transform.position = transform.position;
        }
    }
}
