using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
  public float speed_ = 1.0f;
  private Transform tr_;
  public int damagePoints_ = 2;
  public int health_ = 10;
  public SingleTargetTower shooting_tower_ = null;
  // Start is called before the first frame update
  void Start()
  {
    tr_ = GetComponent<Transform>();
    health_ = 10;
  }

  // Update is called once per frame
  void Update()
  {
    MoveForward();
    if(health_ <= 0){
      die();
    }
  }

  public void RotateLeft(){
    tr_.Rotate(new Vector3(0.0f, -45.0f, 0.0f), Space.Self);
  }

  public void RotateRight(){
    tr_.Rotate(new Vector3(0.0f, 45.0f, 0.0f), Space.Self);
  }

  public void MoveForward(){
    tr_.Translate(speed_ * 0.001f * tr_.forward, Space.Self);
  }

  public void receiveDamage(int dmg){
    health_ -= dmg;
  }

  void die(){
    if(shooting_tower_ != null){
      shooting_tower_.UnlinkTarget();
    }
    Destroy(gameObject);
  }

  void OnTriggerEnter(Collider other){
    Tile tile_collider = other.GetComponentInParent<Tile>();
    Core core_collider = other.GetComponentInParent<Core>();
    Bullet bullet_collider = other.GetComponentInParent<Bullet>();
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

    if(core_collider != null){
      core_collider.damageCore(damagePoints_);
      die();
    }

    if(bullet_collider != null){
      receiveDamage(bullet_collider.damage_);
      Destroy(bullet_collider.gameObject);
    }
  }
}
