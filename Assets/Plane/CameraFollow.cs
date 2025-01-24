using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform targetTransform;
    [SerializeField] private float speed;
    void Update()
    {
        Vector3 target = targetTransform.position + targetTransform.up * 5 + targetTransform.forward * -8;
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);
    }
}
