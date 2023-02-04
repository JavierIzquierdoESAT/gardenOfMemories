using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType{
  Type1,
  Type2,
  Type3
};

public enum Direction{
  Forward,
  Left,
  Right,
  Backwards
}
public class Spawner : MonoBehaviour
{
  bool can_spawn_ = true;
  private Transform tr_;
  public Direction direction_relative_to_z_axis_ = Direction.Forward;
  public GameObject enemy_prefab_1;
  public GameObject enemy_prefab_2;
  public GameObject enemy_prefab_3;
  public EnemyType type_;
  public int quantity_;
  public float frequency_in_seconds_;
  void Start()
  {
    tr_ = GetComponent<Transform>();
    switch(direction_relative_to_z_axis_){
      case Direction.Forward:{
        break;
      }
      case Direction.Left:{
        tr_.Rotate(new Vector3(0.0f, -45.0f, 0.0f), Space.Self);
        break;
      }
      case Direction.Right:{
        tr_.Rotate(new Vector3(0.0f, 45.0f, 0.0f), Space.Self);
        break;
      }
      case Direction.Backwards:{
        tr_.Rotate(new Vector3(0.0f, 90.0f, 0.0f), Space.Self);
        break;
      }
    }
  }

  // Update is called once per frame
  void Update()
  {
    if(can_spawn_ && quantity_ > 0){
      StartCoroutine(SpawnEnemy(frequency_in_seconds_));
    }
  }

  IEnumerator SpawnEnemy(float time){
    can_spawn_ = false;
    GameObject prefab = null;
    switch(type_){
      case EnemyType.Type1:{
        prefab = enemy_prefab_1;
        break;
      }
      case EnemyType.Type2:{
        prefab = enemy_prefab_1;
        break;
      }
      case EnemyType.Type3:{
        prefab = enemy_prefab_1;
        break;
      }
    }
    if(prefab != null){
      
      Instantiate(prefab, new Vector3(tr_.position.x, 0.35f, tr_.position.z), tr_.rotation);
    }
    yield return new WaitForSeconds(time);
    can_spawn_ = true;
  }
}
