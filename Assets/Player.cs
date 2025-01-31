using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] Transform bots;
    [SerializeField] Image image;
    private void Update()
    {
        float dot = 0;
        GameObject target = null;
        foreach (Transform bot in bots) {
            float d = Vector3.Dot(transform.forward, bot.position - transform.position);
            if (d <= 0) continue;
            if (d > dot) {
                dot = d;
                target = bot.gameObject;
            }
        }
        if (target != null)
        {
            Debug.Log(target);
            Vector3 p = Camera.main.WorldToScreenPoint(target.transform.position);
            image.rectTransform.position = p;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ring"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }
}
