using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  public Enemy target_;
  // Start is called before the first frame update
  void Start()
  {
    
  }

  // Update is called once per frame
  void Update()
  {
      
  }
    public void hit(int am)
    {
        Debug.Log(am);
        target_.receiveDamage(am);
    }

}
