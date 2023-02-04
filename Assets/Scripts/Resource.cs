using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType{
  TypeOne,
  TypeTwo,
  TypeThree
};
public class Resource : MonoBehaviour
{
  public ResourceType type_ = ResourceType.TypeOne;
  public Hud hud_info_;
  public int on_pick_resources_ = 5;
  // Start is called before the first frame update
  void Start()
  {
    hud_info_ = GameObject.FindObjectOfType<Hud>();
  }

  // Update is called once per frame
  void Update()
  {
      
  }

  void OnTriggerEnter(Collider other){

    if(other.gameObject.GetComponent<CharacterMovement>() != null){
      Destroy(gameObject);
      switch(type_){
        case ResourceType.TypeOne:{
          hud_info_.resources_inv_.x += on_pick_resources_;
          break;
        }
        case ResourceType.TypeTwo:{
          hud_info_.resources_inv_.y += on_pick_resources_;
          break;
        }
        case ResourceType.TypeThree:{
          hud_info_.resources_inv_.z += on_pick_resources_;
          break;  
        }
      }
    }
  }
}
