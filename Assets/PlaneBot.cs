using UnityEngine;

public class PlaneBot : MonoBehaviour
{

    private Vector2 direction;
    private Rigidbody rb;
    private Vector3 meshRotation = Vector3.zero, rotation = Vector3.zero;
    private int index = 0;
    [SerializeField] LineRenderer path;
    [SerializeField] private float speedX, speedY, decY, speed, rotationSpeed;
    [SerializeField] private Transform mesh;
    private int hp;
    [SerializeField] int maxhp;

    void Start()
    {
        hp = maxhp;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (index < path.positionCount)
        {
            transform.LookAt(path.GetPosition(index) + path.transform.position);
            if ((path.GetPosition(index) + path.transform.position - transform.position).magnitude <= 1) index++;
        }
        rb.linearVelocity = transform.forward * speed;
    }

}