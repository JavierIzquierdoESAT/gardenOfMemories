using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  public int damage_;
  public Enemy target_;
  private float alive_time_ = 0.2f;
  // Start is called before the first frame update
  void Start()
  {
    target_.receiveDamage(damage_);
  }

  // Update is called once per frame
  void Update()
  {
    alive_time_ -= Time.deltaTime;
    if(alive_time_ <= 0.0f){
      Destroy(gameObject);
    }
  }

  void OnTriggerEnter(Collider other){
    Destroy(gameObject);
  }


}
