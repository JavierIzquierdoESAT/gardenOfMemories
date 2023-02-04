using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
  public Hud hud_info_;
  public int on_pick_resources_ = 5;
  // Start is called before the first frame update
  void Start()
  {
    hud_info_ = GameObject.FindObjectOfType<Hud>();
  }

  // Update is called once per frame
  void Update()
  {
      
  }

  void OnTriggerEnter(Collider other){

    if(other.gameObject.GetComponent<CharacterMovement>() != null){
      Destroy(gameObject);
      hud_info_.n_resources_ += on_pick_resources_;
    }
  }
}
