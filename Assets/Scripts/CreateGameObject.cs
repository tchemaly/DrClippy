using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGameObject : MonoBehaviour
{
  public GameObject prefabToInstantiate;
  public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
          Instantiate(prefabToInstantiate, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
