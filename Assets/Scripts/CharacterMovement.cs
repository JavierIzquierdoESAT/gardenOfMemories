using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float maxSpeed;


    public Rigidbody rb;

    float horizontalInput;
    float verticalInput;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 movement = new Vector3(maxSpeed * input.x, 0, maxSpeed * input.y);
        movement = Vector3.ClampMagnitude(movement, maxSpeed);
        movement *= Time.deltaTime;
        transform.Translate(movement, Space.World);

        if (Input.GetButtonDown("Fire1")){
            //Display Menu
            
            buildingList[n].Instantiate(tile.spawnSpot);
        }
    }
}
