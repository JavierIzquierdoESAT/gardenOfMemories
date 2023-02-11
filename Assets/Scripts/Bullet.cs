using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  public Enemy target_;
  private float alive_time_ = 0.2f;
  // Start is called before the first frame update
  void Start()
  {
    
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
    public void hit(int am)
    {
        target_.receiveDamage(am);
    }

}
