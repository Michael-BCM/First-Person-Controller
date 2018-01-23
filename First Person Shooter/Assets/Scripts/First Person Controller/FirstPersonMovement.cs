using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    [SerializeField]
    private float normalSpeed = 10;

    [SerializeField]
    private float runSpeed = 20;
    
    public float movementSpeed { get; private set; }

    [SerializeField]
    private Rigidbody _rigidbody;

    private float Acceleration ()
    {
        if (Input.GetButton("Run") && Input.GetAxis("Vertical") > 0)
        {
            if(movementSpeed < runSpeed)
            {
                return 10;
            }
        }
        else
        {
            if(movementSpeed > normalSpeed)
            {
                return -10;
            }
        }
        return 0;
    }
    
    public float MovementSpeed ()
    {
        if(movementSpeed < normalSpeed)
        {
            return normalSpeed;
        }
        else if (movementSpeed > runSpeed)
        {
            return runSpeed;
        }
        return movementSpeed;
    }

    private void Update()
    {
        movementSpeed += Acceleration() * 4 * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(transform.position + transform.TransformDirection(Vector3.ClampMagnitude(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")), 1) * Time.deltaTime * MovementSpeed()));
    }
}

/*
    private bool AnalogControlIsInUse()
    {
        return Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0;
    }

    private float AnalogMagnitude ()
    {
        if(!AnalogControlIsInUse())
        {
            return 0;
        }
        return Vector3.ClampMagnitude(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")), 1).magnitude;
    }*/
