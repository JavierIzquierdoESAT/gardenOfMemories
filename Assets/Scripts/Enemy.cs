using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
  public int sound_index = 0;
  public float speed_ = 1.0f;
  private Transform tr_;
  public int damagePoints_ = 2;
  public int health_ = 10;
  public AudioManager audio_manager_;
  public SingleTargetTurret shooting_tower_ = null;
  public bool fix_position_ = false;
  // Start is called before the first frame update
  void Start()
  {
    tr_ = GetComponent<Transform>();
    audio_manager_ = GameObject.FindObjectOfType<AudioManager>();
    if(fix_position_){
      tr_.Translate(new Vector3(0.0f, -0.3f, 0.0f), Space.Self);
    }
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
    tr_.Rotate(new Vector3(0.0f, -90.0f, 0.0f), Space.Self);
  }

  public void RotateRight(){
    tr_.Rotate(new Vector3(0.0f, 90.0f, 0.0f), Space.Self);
  }

  public void MoveForward(){
    tr_.localPosition += (Time.deltaTime * 0.1f) * (speed_ * tr_.forward);
  }

  public void receiveDamage(int dmg){
    health_ -= dmg;
  }

  void die(){
    if(shooting_tower_ != null){
      shooting_tower_.UnlinkTarget();
    }
    Destroy(gameObject);
    switch(sound_index){
      case 0:{
        audio_manager_.PupusitoDeathSound();
        break;
      }
      case 1:{
        audio_manager_.MisterDDeathSound();
        break;
      }
      default:{
        audio_manager_.RanaDeathSound();
        break;
      }
    }
  }

  void OnTriggerEnter(Collider other){
    if(!other.CompareTag("IgnoreEnemy")){

      Tile tile_collider = other.GetComponent<Tile>();
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
        Destroy(bullet_collider.gameObject);
      }
    }
  }
}
