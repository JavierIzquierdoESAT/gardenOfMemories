using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
  [SerializeField] private int health_ = 10;
  public Hud hud_info_;
  void Start()
  {
      
  }

  // Update is called once per frame
  void Update()
  {
    hud_info_.core_health_ = health_;
  }

  public void damageCore(int dmg){
    health_ -= dmg;
  }
}
