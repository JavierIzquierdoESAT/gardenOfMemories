using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
  private Transform tr_;
  // Start is called before the first frame update
  void Start()
  {
    tr_ = GetComponent<Transform>();
  }

  // Update is called once per frame
  void Update()
  {
    MoveForward();
  }

  public void RotateLeft(){
    tr_.Rotate(new Vector3(0.0f, -45.0f, 0.0f), Space.Self);
  }

  public void RotateRight(){
    tr_.Rotate(new Vector3(0.0f, 45.0f, 0.0f), Space.Self);
  }

  public void MoveForward(){
    tr_.Translate(0.001f * tr_.forward, Space.Self);
  }

  void OnTriggerEnter(Collider other){
    Tile tile_collider = other.GetComponentInParent<Tile>();
    if(tile_collider != null){
      switch(tile_collider.next_direction_){
        case TurnDirection.Left:{
          RotateLeft();
          break;
        }
        case TurnDirection.Right:{
          RotateRight();
          break;
        }
      }
    }
  }
}
