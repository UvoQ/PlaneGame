using UnityEngine;
using UnityEngine.InputSystem;

public class Plane : MonoBehaviour
{

    private Vector2 direction;
    private Rigidbody rb;
    private Vector3 meshRotation = Vector3.zero, rotation = Vector3.zero;

    [SerializeField] private float speedX, speedY, decY, speed, rotationSpeed;
    [SerializeField] private Transform mesh;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rotation += new Vector3((direction.y * speedY - decY) * Time.deltaTime, direction.x * Time.deltaTime * speedX, 0);
        rotation.x = Mathf.Clamp(rotation.x, -70, 70);
        transform.localEulerAngles = rotation;
        rb.linearVelocity = transform.forward * speed;
        if (direction.x != 0)
        {
            meshRotation.z -= rotationSpeed * Time.deltaTime * direction.x;
        }
        else
        {
            if (meshRotation.z > 0)
            {
                meshRotation.z -= rotationSpeed * Time.deltaTime;
            } else
            {
                meshRotation.z += rotationSpeed * Time.deltaTime;
            }
        }
        meshRotation.z = Mathf.Clamp(meshRotation.z, -60, 60);
        mesh.localEulerAngles = meshRotation;
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        direction = ctx.ReadValue<Vector2>();
    }
}
