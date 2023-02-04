using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hud : MonoBehaviour
{
  public TextMeshProUGUI resource_number_;
  public int n_resources_ = 0;
  // Start is called before the first frame update
  void Start()
  {
  
  }

  // Update is called once per frame
  void Update()
  {
    resource_number_.text = n_resources_.ToString();
  }

 
}
