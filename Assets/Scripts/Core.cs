using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
  [SerializeField] private int health_ = 10;
  void Start()
  {
      
  }

  // Update is called once per frame
  void Update()
  {
      
  }

  public void damageCore(int dmg){
    health_ -= dmg;
  }
}
