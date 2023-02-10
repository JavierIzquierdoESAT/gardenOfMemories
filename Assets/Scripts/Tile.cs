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

    [HideInInspector]
  public Outline outline;
  // Start is called before the first frame update
  void Start()
  {
        outline = GetComponent<Outline>();
        if(outline != null )
        {
            outline.enabled = false;
        }

        if(attachedBuilding != null)
        {
            attachedBuilding = Instantiate(attachedBuilding, gameObject.transform);
        }
  }

  // Update is called once per frame
  void Update()
  {
  
  }


  
}
