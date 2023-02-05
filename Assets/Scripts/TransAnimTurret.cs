using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransAnimTurret : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
        animator.SetBool("grown", true);
    }
    private void Update()
    {
        animator.SetBool("grown", true);
    }

}
