using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrsut;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrength = 100f;
    [SerializeField] float rotationStrength = 100f;

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
        if (rotationInput < 0)
        {
            ApplyRotaion(rotationStrength);
        }
        else if (rotationInput > 0)
        {
            ApplyRotaion(-rotationStrength);
        }

        // rb.AddRelativeTorque(Vector3.forward * rotationInput * 100f * Time.fixedDeltaTime);
    }

    private void ApplyRotaion(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
        rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
    }
}
