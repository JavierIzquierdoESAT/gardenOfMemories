using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Direction{
  Forward,
  Left,
  Right,
  Backwards
};
public class Spawner : MonoBehaviour
{
  bool can_spawn_ = true;
  private Transform tr_;
  public Direction direction_relative_to_z_axis_ = Direction.Forward;
  public GameObject enemy_prefab_;
  public int quantity_;
  public float frequency_in_seconds_;
  public bool enabled_ = false;
  private EnemyManager manager_;
  void Start()
  {
    manager_ = GameObject.FindAnyObjectByType<EnemyManager>();
    tr_ = GetComponent<Transform>();
    switch(direction_relative_to_z_axis_){
      case Direction.Forward:{
        break;
      }
      case Direction.Left:{
        tr_.Rotate(new Vector3(0.0f, -90.0f, 0.0f), Space.Self);
        break;
      }
      case Direction.Right:{
        tr_.Rotate(new Vector3(0.0f, 90.0f, 0.0f), Space.Self);
        break;
      }
      case Direction.Backwards:{
        tr_.Rotate(new Vector3(0.0f, 180.0f, 0.0f), Space.Self);
        break;
      }
    }
  }

  // Update is called once per frame
  void Update()
  {
    if(can_spawn_ && quantity_ > 0 && enabled_){
      StartCoroutine(SpawnEnemy(frequency_in_seconds_));
    }
  }

  IEnumerator SpawnEnemy(float time){
    can_spawn_ = false;

    if(enemy_prefab_ != null){
      
      Instantiate(enemy_prefab_, new Vector3(tr_.position.x, 0.35f, tr_.position.z), tr_.rotation);
      manager_.CountEnemy();
    }
    yield return new WaitForSeconds(time);
    can_spawn_ = true;
    quantity_--;
  }
}
