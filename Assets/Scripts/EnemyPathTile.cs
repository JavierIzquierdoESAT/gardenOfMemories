using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyPathTile : Tile
{
  public TurnDirection next_direction_ = TurnDirection.Forward;

  void Start()
  {
      
  }


  void Update()
  {
      
  }

  void OnCollisionEnter(Collision collision){
    if(collision.gameObject.GetComponent<Enemy>() != null){
      //Enemy passed through the tile
      switch(next_direction_){
        case TurnDirection.Left:{
          collision.gameObject.GetComponent<Enemy>().RotateLeft();
          break;
        }
        case TurnDirection.Right:{
          collision.gameObject.GetComponent<Enemy>().RotateRight();
          break;
        }
      }
    }
  }
}
