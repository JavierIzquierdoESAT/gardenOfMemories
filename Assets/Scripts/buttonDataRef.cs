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
        if (transform.parent.parent.GetComponent<Hud>().n_resources_ < building.cost_)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }
}
