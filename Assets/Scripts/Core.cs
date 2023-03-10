using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Core : MonoBehaviour
{
    [SerializeField] private int health_ = 10;
    private Hud hud_info_;
    private bool core_died_ = false;
    void Start()
    {
        hud_info_ = FindObjectOfType<Hud>();
    }

    // Update is called once per frame
    void Update()
    {
        hud_info_.core_health_ = health_;
    }

    public void damageCore(int dmg)
    {
        if (health_ > dmg && !core_died_)
        {
            health_ -= dmg;
        }
        else
        {
            health_ = 0;
            core_died_ = true;
            SceneManager.LoadScene("Lose", LoadSceneMode.Single);
        }
    }
}
