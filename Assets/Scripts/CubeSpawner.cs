using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject _cube;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var newCube = Instantiate(_cube);
            newCube.transform.position = new Vector3(Random.Range(-15,15), 30, 20);
        }
    }
}
