using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hud : MonoBehaviour
{
  public TextMeshProUGUI resource_one_;
  public TextMeshProUGUI resource_two_;
  public TextMeshProUGUI resource_three_;
  public TextMeshProUGUI core_status_;
  public Vector3 resources_inv_;
  public int core_health_;
  // Start is called before the first frame update
  void Start()
  {
  
  }

  // Update is called once per frame
  void Update()
  {
    resource_one_.text = resources_inv_.x.ToString();
    resource_two_.text = resources_inv_.y.ToString();
    resource_three_.text = resources_inv_.z.ToString();
    core_status_.text = core_health_.ToString();
  }

 
}
