using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  public int damage_;
  public Enemy target_;
  // Start is called before the first frame update
  void Start()
  {
    target_.receiveDamage(damage_);
  }

  // Update is called once per frame
  void Update()
  {
      
  }


}
