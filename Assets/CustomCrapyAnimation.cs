using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCrapyAnimation : MonoBehaviour
{
    public GameObject attackMesh;
    public GameObject idleMesh;
    public GameObject growMesh;

    public float attackTime;
    public float growTime;
    public bool growing;
    public bool attacking;

    private float timer;
    private void Start()
    {
        attackMesh.SetActive(false);
        idleMesh.SetActive(false);
        growMesh.SetActive(false);

        growMesh.SetActive(true);
        timer = growTime;
        growing = true;
        attacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0 && growing)
        {
            growing = false;
            /*idleMesh.SetActive(true);
            idleMesh.GetComponent<Animator>().Play("idle", -1, 0f);*/
        }
        /*else if(timer < 0 && attacking)
        {
            attacking = false;
            attackMesh.SetActive(false);
            idleMesh.SetActive(true);
            idleMesh.GetComponent<Animator>().Play("idle", -1, 0f);
        }*/
    }

    public void attack()
    {
        if (!growing)
        {
            growMesh.SetActive(false);
            idleMesh.SetActive(false);
            attackMesh.SetActive(true);
            attackMesh.GetComponent<Animator>().Play("attack", -1, 0f);
            attacking = true;
        }

        //timer = attackTime;
    }
}
