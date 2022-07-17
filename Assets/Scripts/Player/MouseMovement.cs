using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";
    
    [Header("Rotation")]
    private Vector3 rotationVector;
    private float verticalInput;
    private  float horizotalInput;
    
    [SerializeField] private float rotationSpeed = 200f;
    [SerializeField] private Transform playerBody;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        verticalInput += Input.GetAxis(MouseX)  * rotationSpeed ;
        horizotalInput -= Input.GetAxis(MouseY) * rotationSpeed;
        horizotalInput = Mathf.Clamp(horizotalInput, -45, 45);
        playerBody.localRotation = Quaternion.Euler(0,verticalInput,0);
        transform.localRotation = Quaternion.Euler(horizotalInput,0,0);
    }
}
