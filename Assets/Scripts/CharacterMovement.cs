using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float maxSpeed;

    public List<Construction> buildings;
    public CanvasRenderer menu;

    //private Tile interactionTile;
    public Rigidbody rb;
    public Hud hud_info_;

    private Tile interactionTile;


    float horizontalInput;
    float verticalInput;
    float speed;
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

        if (isMenuOpen == false && Physics.Raycast(transform.position, transform.forward, out hit, 100, LayerMask.GetMask("TileVolume"), QueryTriggerInteraction.Collide))
        {
            interactionTile = hit.transform.parent.gameObject.GetComponent<Tile>();
        }
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 movement = new Vector3(maxSpeed * input.x, 0, maxSpeed * input.y);
        movement = Vector3.ClampMagnitude(movement, maxSpeed);
        movement *= Time.deltaTime;
        transform.Translate(movement, Space.World);




        if (Input.GetButtonDown("Fire1") && !isMenuOpen && interactionTile != null)
        {
            if(interactionTile.type_ == TileType.Buildable) {
                isMenuOpen = true;
                menu.gameObject.SetActive(true);
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
        }

    }

    public void SpawnBuilding(int type)
    {
        Debug.Log(interactionTile);
        Instantiate(buildings[type], interactionTile.gameObject.transform);
        isMenuOpen= false;
        menu.gameObject.SetActive(false);
    }

    
}
