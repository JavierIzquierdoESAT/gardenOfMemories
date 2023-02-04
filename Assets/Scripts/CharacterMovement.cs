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

    float horizontalInput;
    float verticalInput;
    float speed;
    bool isMenuOpen;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isMenuOpen= false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 movement = new Vector3(maxSpeed * input.x, 0, maxSpeed * input.y);
        movement = Vector3.ClampMagnitude(movement, maxSpeed);
        movement *= Time.deltaTime;
        transform.Translate(movement, Space.World);

        if (Input.GetButtonDown("Fire1") && !isMenuOpen)
        {
            isMenuOpen= true;
            menu.gameObject.SetActive(true);
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
        Instantiate(buildings[type], gameObject.transform);
        isMenuOpen= false;
        menu.gameObject.SetActive(false);
    }
}
