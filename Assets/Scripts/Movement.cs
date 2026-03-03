using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrsut;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrength = 100f;

    Rigidbody rb;

    private void Start()
    {
       rb = GetComponent<Rigidbody>(); 
    }

    private void OnEnable()
    {
        thrsut.Enable();
        rotation.Enable();
    }

    private void FixedUpdate()
    {
        ProcessTrust();
        ProcessRotation();
    }

    private void ProcessTrust()
    {
        if (thrsut.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
        }
    }

    private void ProcessRotation()
    {
        float rotationInput = rotation.ReadValue<float>();
        Debug.Log(rotationInput);
        rb.AddRelativeTorque(Vector3.forward * rotationInput * 100f * Time.fixedDeltaTime);
    }
}
