using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;

public class CharacterMovement : MonoBehaviour
{
    public float maxSpeed;
    public float rotationSpeed;

    public GameObject mesh;
    public List<Construction> buildings;
    public CanvasRenderer menu;

    //private Tile interactionTile;
    public Rigidbody rb;
    public Hud hud_info_;

    private Tile interactionTile;

    bool isMenuOpen;
    // Start is called before the first frame update
    void Start()
    {
        isMenuOpen= false;
        menu.gameObject.SetActive(false);

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 movement = new Vector3(maxSpeed * input.x, 0, maxSpeed * input.y);
        movement = Vector3.ClampMagnitude(movement, maxSpeed) * Time.deltaTime;
        transform.Translate(movement, Space.Self);
        
        if (movement.magnitude > 0)
        {
            mesh.transform.rotation = Quaternion.Slerp(mesh.transform.rotation, Quaternion.LookRotation(movement.normalized), Time.deltaTime * rotationSpeed);
        }
        Vector3 tst = transform.position + mesh.transform.forward.normalized;
        Debug.DrawRay(transform.position, mesh.transform.forward.normalized);
        if (isMenuOpen == false && Physics.Raycast(transform.position, mesh.transform.forward.normalized, out hit, 100, LayerMask.GetMask("TileVolume"), QueryTriggerInteraction.Collide))
        {
            interactionTile = hit.transform.parent.gameObject.GetComponent<Tile>();
        }

        if (Input.GetButtonDown("Fire1") && !isMenuOpen && interactionTile != null)
        {
            if(interactionTile.type_ == TileType.Buildable) {
                showBuildMenu(true);
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
            if (Input.GetButtonDown("Cancel"))
            {
                showBuildMenu(false);
            }
        }

    }

    public void SpawnBuilding(int type)
    {
        Debug.Log(interactionTile);
        Instantiate(buildings[type], interactionTile.gameObject.transform);
        showBuildMenu(false);
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
    
}
