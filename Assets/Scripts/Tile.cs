using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
  
  }

  void ChangeMaterial(Material mat){
    transform.GetChild(0).gameObject.GetComponent<Renderer>().material = mat;
  }
}
