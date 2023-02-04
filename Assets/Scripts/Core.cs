using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
  [SerializeField] private int health_ = 10;
  public Hud hud_info_;
  private bool core_died_ = false;
  void Start()
  {
    
  }

  // Update is called once per frame
  void Update()
  {
    hud_info_.core_health_ = health_;
  }

  public void damageCore(int dmg){
    if(health_ > 0 && !core_died_){
      health_ -= dmg;
    }else{
      health_ = 0;
      core_died_ = true;
      Debug.Log("You lost");
    }
  }
}
