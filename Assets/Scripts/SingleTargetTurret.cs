using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTargetTurret : Construction
{
  public float attackSpeed_;
  public float attackDamage_;
  public float range_;
  public GameObject bullet_;
  public Enemy target_ = null;
  public Transform position_of_gun_;
  public float force_;
  private bool can_shoot_ = true;
  [SerializeField]private List<Enemy> enemy_buffer_;
  private bool there_are_enemies_to_shoot = false;

    public CustomCrapyAnimation anim;
    public Animator animator;
    public float attackAnimTime;
  

  // Start is called before the first frame update
  void Start()
  {
    enemy_buffer_ = new List<Enemy>();
    if (animator!=null) animator.SetBool("growing", true);
  }

  // Update is called once per frame
  void Update()
  { 
    LookForTargets();
    there_are_enemies_to_shoot = (enemy_buffer_.Count > 0);
    if (animator != null)
    {
        if (there_are_enemies_to_shoot) animator.SetBool("attacking", true);
        else animator.SetBool("attacking", false);
    }
    SetTarget();

    if(target_ != null){
      transform.LookAt(target_.transform);
      if((target_.transform.position - position_of_gun_.position).magnitude > range_){
        UnlinkTarget();
      }
    }
    
    if(can_shoot_ && there_are_enemies_to_shoot && target_ != null){
       StartCoroutine(ShootTarget());
    }

    GarbageCollector();
  }

  IEnumerator ShootTarget(){
    can_shoot_ = false;
    GameObject go = Instantiate(bullet_, position_of_gun_.position, Quaternion.identity);
        
        go.GetComponent<Rigidbody>().AddForce(force_ * (target_.transform.position - position_of_gun_.position).normalized, ForceMode.Impulse);
    go.GetComponent<Bullet>().target_ = target_;
        go.GetComponent<Bullet>().hit((int)attackDamage_);
      
    if(anim != null)
        anim.attack();
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
    if(enemy_buffer_.Count > 0)
        enemy_buffer_.RemoveAt(0);
  }

  void GarbageCollector(){
    for(int i = 0; i < enemy_buffer_.Count; ++i){
      if(enemy_buffer_[i] == null){
        enemy_buffer_.RemoveAt(i);
      }
    }
  }
}
