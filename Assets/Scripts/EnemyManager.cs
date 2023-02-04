using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
  public List<Spawner> spawners_;
  public List<int> spawners_quantity_;
  public List<GameObject> enemy_prefabs_;
  public float time_between_waves_ = 1.0f;
  private int spawn_index_ = 0;
  private bool level_finished_ = false;
  private bool transition_ = false;
  private int max_waves_ = 0;
  public float initial_timer_ = 3.0f;
  private bool start_ = false;
  // Start is called before the first frame update
  void Start()
  {
    InitSpawners();
    StartWaves();
  }

  // Update is called once per frame
  void Update()
  {
    if(start_){
      spawners_[0].enabled_ = true;
      start_ = false;
    }
    if(!level_finished_ && !transition_ && start_){
      if(spawners_[spawn_index_].quantity_ <= 0){
        StartCoroutine(NextWave());
      }
    }
  }

  GameObject SpawnEnemy(Vector3 position){

    return null;
  }

  void InitSpawners(){
    for(int i = 0; i < spawners_.Count; i++){
      spawners_[i].quantity_ = spawners_quantity_[i];
      spawners_[i].enemy_prefab_ = enemy_prefabs_[i];
    }
    max_waves_ = spawners_.Count;
  }

  IEnumerator NextWave(){
    transition_ = true;
    if(spawners_[spawn_index_] != null){
      spawners_[spawn_index_].enabled_ = false;
    }
    yield return new WaitForSeconds(time_between_waves_);
    spawn_index_++;
    if(spawn_index_ < max_waves_){
      spawners_[spawn_index_].enabled_ = true;
    }else{
      Debug.Log("Level finished");
      level_finished_ = true;
    }
    transition_ = false;
  }

  void StartWaves(){
    StartCoroutine(InitialTimer());
  }

  IEnumerator InitialTimer(){
    yield return new WaitForSeconds(initial_timer_);
    start_ = true;
  }
}
