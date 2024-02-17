using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputParser : MonoBehaviour
{
  public GameObject level1;
  public GameObject level2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space)){
        level1.SetActive(true);
      }
      if (Input.GetKeyDown(KeyCode.Backspace)){
        level2.SetActive(true);
      }
    }
}
