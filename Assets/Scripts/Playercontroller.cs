using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float speed = 20;
    public float turnSpeed = 20;
    public float jumpspeed = 20;

    private Vector3 startPosition;
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rigidBody = GetComponent<Rigidbody>();
    }

    void HandleMovement()
     {
        float turnValue = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float walkValue = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float jumpValue = Input.GetAxis("Jump") * jumpspeed * Time.deltaTime;

        turnValue *= Mathf.Sign(walkValue);
        if(walkValue == 0){
            turnValue = 0;
        }

        Vector3 positionChange = Vector3.forward * walkValue;

        transform.Translate(Vector3.up * jumpValue);
        transform.Rotate(Vector3.up, turnValue);
        transform.Translate(positionChange);

    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }
}
