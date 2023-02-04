using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResourceTower : Construction
{
  public ResourceType type_ = ResourceType.TypeOne;
  public GameObject resource_prefab_;
  public float cooldown_ = 3.0f;
  public float drop_radius_ = 2.0f;
  public float inner_radius_ = 1.0f;
  private bool can_produce_ = true;
  public Transform []spawn_points_ = new Transform[4];
  void Start()
  {
   
  }

  // Update is called once per frame
  void Update()
  {
    if(can_produce_){
      StartCoroutine(SpawnResource());
    }
  }

  IEnumerator SpawnResource(){
    can_produce_ = false;
 
    float offset_x = Random.Range(-drop_radius_, drop_radius_);
    float offset_z = Random.Range(-drop_radius_, drop_radius_);

    if(offset_x < inner_radius_ && offset_x > 0.0f){
      offset_x = inner_radius_;
    }

    if(offset_x > -inner_radius_ && offset_x < 0.0f){
      offset_x = -inner_radius_;
    }

    if(offset_z < inner_radius_ && offset_z > 0.0f){
      offset_z = inner_radius_;
    }

    if(offset_z > -inner_radius_ && offset_z < 0.0f){
      offset_z = -inner_radius_;
    }
    Vector3 drop_point = transform.position + new Vector3(offset_x, 0.0f, offset_z);
    
    Vector3 spawn_point = drop_point;
    GameObject go = Instantiate(resource_prefab_, spawn_point, Quaternion.identity);
    go.GetComponent<Resource>().type_ = type_;
    yield return new WaitForSeconds(cooldown_);
    can_produce_ = true;
  }

}
