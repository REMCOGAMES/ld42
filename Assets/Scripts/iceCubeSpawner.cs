using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceCubeSpawner : MonoBehaviour
{

    GameObject iceCube;
    public GameObject iceCubePrefab; 
    int cubesSpawned = 0;
    
    private void FixedUpdate()
    {
        if (cubesSpawned < 4)
        {
            spawnIceCube();
        }
        if (iceCube.transform.position.y < -10)
        {
            Destroy(iceCube);
        }
    }
    

    void spawnIceCube()
    {
        cubesSpawned += 1;
        iceCube = Instantiate(iceCubePrefab, gameObject.transform);
        float randNum = Random.Range(0.4f, 0.9f);
        iceCube.transform.localScale = new Vector2(randNum, randNum);

    }
}
