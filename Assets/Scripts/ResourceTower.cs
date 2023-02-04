using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTower : Construction
{
  public GameObject resource_prefab_;
  public float cooldown_ = 3.0f;
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
    Vector3 spawn_point = spawn_points_[Random.Range(0, 4)].position;
    GameObject go = Instantiate(resource_prefab_, spawn_point, Quaternion.identity);
    yield return new WaitForSeconds(cooldown_);
    can_produce_ = true;
  }
}
