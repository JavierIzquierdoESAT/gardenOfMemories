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
  public float TimeAlive;

  private float aliveTimer;
  // Start is called before the first frame update
  void Start()
  {
    hud_info_ = GameObject.FindObjectOfType<Hud>();
    aliveTimer = TimeAlive;
  }

  // Update is called once per frame
  void Update()
  {
    aliveTimer -= Time.deltaTime;
    if (aliveTimer <= 0)
    {
      Destroy(gameObject);
    }

    /*transform.up = Camera.main.transform.position - transform.position;
    transform.forward = -Camera.main.transform.up;*/
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
