using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Zombie"))
        {
            collision.collider.transform.root.SendMessage("Hit");
        }

        Destroy(gameObject, 10f);
        Destroy(this);
    }
}
