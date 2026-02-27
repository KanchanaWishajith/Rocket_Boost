using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrsut;
    [SerializeField] float thrustStrength = 100f;

    Rigidbody rb;

    private void Start()
    {
       rb = GetComponent<Rigidbody>(); 
    }

    private void OnEnable()
    {
        thrsut.Enable();
    }

    private void FixedUpdate()
    {
        if(thrsut.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
        }
    }
}
