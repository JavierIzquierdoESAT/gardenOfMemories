using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;

public class CharacterMovement : MonoBehaviour
{
    public float maxSpeed;
    public float rotationSpeed;
    public Animator animator_;

    public GameObject mesh;

    public CanvasRenderer menu;
    public CanvasRenderer demolishMenu;

    //private Tile interactionTile;
    public Rigidbody rb;
    public Hud hud_info_;

    private Tile interactionTile;
    public List<GameObject> buildings;
    public float max_velocity_ = 2.0f;
    public float movement_force_ = 50.0f;

    bool isMenuOpen;
    bool isDemolishOpen;

    const float inputTimer = 0.3f;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        showBuildMenu(false);
        showDemolishMenu(false);
        rb = GetComponent<Rigidbody>();

        foreach (Transform child in menu.transform)
        {
            buildings.Add(child.gameObject.GetComponent<buttonDataRef>().building.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        RaycastHit hit;

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 movement = new Vector3(maxSpeed * input.x, 0, maxSpeed * input.y);
        movement = Vector3.ClampMagnitude(movement, maxSpeed) * Time.deltaTime;
        if(rb.velocity.magnitude < max_velocity_)
        rb.AddForce(movement * movement_force_, ForceMode.VelocityChange);
        
        if (movement.magnitude > 0)
        {
            animator_.SetBool("IsMoving", true);
            mesh.transform.rotation = Quaternion.Slerp(mesh.transform.rotation, Quaternion.LookRotation(movement.normalized), Time.deltaTime * rotationSpeed);
        }else{
            animator_.SetBool("IsMoving", false);
        }
        Vector3 tst = transform.position + mesh.transform.forward.normalized;
        Debug.DrawRay(transform.position, mesh.transform.forward.normalized);
        if (isMenuOpen == false && Physics.Raycast(transform.position, mesh.transform.forward.normalized, out hit, 100, LayerMask.GetMask("TileVolume"), QueryTriggerInteraction.Collide))
        {
            interactionTile = hit.transform.parent.gameObject.GetComponent<Tile>();
        }

        if (Input.GetButtonDown("Fire1") && !isMenuOpen && interactionTile != null && timer <= 0)
        {
            timer = inputTimer;
            if(interactionTile.type_ == TileType.Buildable && interactionTile.attachedBuilding == null) {
                showBuildMenu(true);
            }
            else if(interactionTile.type_ == TileType.Buildable){
                showDemolishMenu(true);
            }

        }

        if (isMenuOpen)
        {
            if (Input.GetButtonDown("Build1"))
            {
                SpawnBuilding(0);
            }
            if (Input.GetButtonDown("Build2"))
            {
                SpawnBuilding(1);
            }
            if (Input.GetButtonDown("Build3"))
            {
                SpawnBuilding(2);
            }
            if (Input.GetButtonDown("Build4"))
            {
                SpawnBuilding(3);
            }
            if (Input.GetButtonDown("Build5"))
            {
                SpawnBuilding(4);
            }
            if (Input.GetButtonDown("Build6"))
            {
                SpawnBuilding(5);
            }
            if (Input.GetButtonDown("Fire1") && timer < 0)
            {
                showBuildMenu(false);
                timer = inputTimer;
            }
        }

        if(isDemolishOpen)
        {
            if (Input.GetButtonDown("Fire1") && timer < 0)
            {
                showDemolishMenu(false);
                timer = inputTimer;
            }
        }

    }

    public void SpawnBuilding(int type)
    {
        if(AvailableBuilding(hud_info_.resources_inv_, buildings[type].GetComponent<Construction>().cost_))
        {
            interactionTile.attachedBuilding = Instantiate(buildings[type], interactionTile.gameObject.transform).GetComponent<Construction>();
            hud_info_.resources_inv_ -= interactionTile.attachedBuilding.cost_;
            showBuildMenu(false);
        }
    }

    public bool AvailableBuilding(Vector3 rs1, Vector3 rs2){
      Vector3 tmp_inv = rs1 - rs2;
      if(tmp_inv.x < 0.0f || tmp_inv.y < 0.0f || tmp_inv.z < 0.0f){
        return false;
      }else{
        return true;
      }
    }
    public void Demolish()
    {
        //hud_info_.resources_inv_ += interactionTile.attachedBuilding.cost_ / 2;
        Destroy(interactionTile.attachedBuilding.gameObject);
        interactionTile.attachedBuilding = null;
        showDemolishMenu(false);
    }

    private void showBuildMenu(bool Activate)
    {
        if(Activate)
        {
            isMenuOpen = true;
            menu.gameObject.SetActive(true);
        }
        else
        {
            isMenuOpen = false;
            menu.gameObject.SetActive(false);
        }

    }

    private void showDemolishMenu(bool Activate)
    {
        if (Activate)
        {
            isDemolishOpen = true;
            demolishMenu.gameObject.SetActive(true);
        }
        else
        {
            isDemolishOpen = false;
            demolishMenu.gameObject.SetActive(false);
        }
    }



}
