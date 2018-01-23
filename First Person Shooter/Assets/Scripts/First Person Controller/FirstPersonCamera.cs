using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField]
    private float mouseSensitivity;

    private Camera mainCamera;

    public float x_Rotation { get; private set; }
    public float y_Rotation { get; private set; }

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        x_Rotation += Input.GetAxis("Mouse X") * mouseSensitivity;

        y_Rotation = Mathf.Clamp(y_Rotation + (Input.GetAxis("Mouse Y") * mouseSensitivity), -90, 90);
        
        transform.rotation = Quaternion.Euler(0, x_Rotation, 0);

        mainCamera.transform.rotation = Quaternion.Euler(-y_Rotation, x_Rotation, 0);
    }
}
