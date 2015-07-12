using UnityEngine;
using System.Collections;

public class Fall : MonoBehaviour
{
    public AudioClip[] hits;
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            source.PlayOneShot(hits[Random.Range(0, hits.Length)]);
            Destroy(this);
        }
    }
}
