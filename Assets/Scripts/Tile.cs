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
  EnemyPath,
  Bridge,
  
};

public class Tile : MonoBehaviour
{
  public TileType type_ = TileType.Buildable;
  public TurnDirection next_direction_ = TurnDirection.Forward;
  public Collider collider_;
  private Transform tr_;

  public Construction attachedBuilding;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
  
  }


  
}
