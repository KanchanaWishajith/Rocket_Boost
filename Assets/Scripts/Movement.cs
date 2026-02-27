using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrsut;

    private void OnEnable()
    {
        thrsut.Enable();
    }

    private void Update()
    {
        if(thrsut.IsPressed())
        {
            Debug.Log("Dang, I need some space");
            // transform.Translate(Vector3.forward * Time.deltaTime);
        }
    }
}
