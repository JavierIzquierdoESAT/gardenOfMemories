using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TurnDirection{
  Left,
  Right,
  Forward
};
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
          
          break;
        }
        case TurnDirection.Right:{

          break;
        }
      }
    }
  }
}
