using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TurnDirection{
  Left,
  Right,
  Forward
};

public enum TileType{
  Buildable,
  NotBuildable,
  EnemyPath
};

public class Tile : MonoBehaviour
{
  public TileType type_ = TileType.Buildable;
  public TurnDirection next_direction_ = TurnDirection.Forward;
  public Collider collider_;
  private Transform tr_;
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
