using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTargetTower : Construction
{
  public float attackSpeed_;
  public float attackDamage_;
  public float range_;
  public int resourcesPerSecond_;
  public int cost_;
  public GameObject bullet_;
  public Enemy target_ = null;
  public Transform position_of_gun_;
  public float force_;
  private bool can_shoot_ = true;
  private List<Enemy> enemy_buffer_;
  private bool there_are_enemies_to_shoot = false;
  

  // Start is called before the first frame update
  void Start()
  {
    enemy_buffer_ = new List<Enemy>();
  }

  // Update is called once per frame
  void Update()
  {
   
    SetTarget();
    LookForTargets();

    if(target_ != null){
      if((target_.transform.position - position_of_gun_.position).magnitude > range_){
        UnlinkTarget();
      }
    }
    
    if(can_shoot_ && there_are_enemies_to_shoot){
       StartCoroutine(ShootTarget());
    }
    there_are_enemies_to_shoot = (enemy_buffer_.Count > 0);
  }

  IEnumerator ShootTarget(){
    can_shoot_ = false;
    GameObject go = Instantiate(bullet_, position_of_gun_.position, Quaternion.identity);
    go.GetComponent<Rigidbody>().AddForce(force_ * (target_.transform.position - position_of_gun_.position).normalized, ForceMode.Impulse);
    go.GetComponent<Bullet>().target_ = target_;
    yield return new WaitForSeconds(attackSpeed_);
    can_shoot_ = true;
    
  }

  void LookForTargets(){
    Collider[] hitinfo = Physics.OverlapSphere(position_of_gun_.position, range_);
    if(hitinfo != null){
  
      foreach(var hitCollider in hitinfo){
        Enemy tmp = hitCollider.gameObject.GetComponent<Enemy>();
        if(tmp != null){

          if(!enemy_buffer_.Contains(tmp)){
            enemy_buffer_.Add(tmp);
          }

        }
      }
    }
  }

  void SetTarget(){
    if(target_ == null && there_are_enemies_to_shoot){
      target_ = enemy_buffer_[0];
      target_.shooting_tower_ = this;
    }
  }

  public void UnlinkTarget(){
    target_ = null;
    enemy_buffer_.RemoveAt(0);
  }
}
