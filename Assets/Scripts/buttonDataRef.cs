using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class buttonDataRef : MonoBehaviour
{
    private Button button;
    public Construction building;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    private void Update()
    {
      if (AvailableBuilding(transform.parent.parent.GetComponent<Hud>().resources_inv_, building.cost_))
      {
        button.interactable = false;
      }
      else
      {
        button.interactable = true;
      }
    }

    public bool AvailableBuilding(Vector3 rs1, Vector3 rs2){
      if(rs2 != null){
        Vector3 tmp_inv = rs1 - rs2;
        if(tmp_inv.x < 0.0f || tmp_inv.y < 0 || tmp_inv.z < 0){
          return false;
        }
      }
      return false;
    }
}
