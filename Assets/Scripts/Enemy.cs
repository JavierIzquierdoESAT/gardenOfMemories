using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
  private Transform tr_;
  public NavMeshAgent agent_;
  // Start is called before the first frame update
  void Start()
  {
    tr_ = GetComponent<Transform>();
  }

  // Update is called once per frame
  void Update()
  {
      
  }

  public void RotateLeft(){

  }

  public void RotateRight(){

  }
}
