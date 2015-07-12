using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour
{
    public float tilt = 10f;
    public float acceleration = 10f;
    public float range = 2.5f;

    public AudioClip[] steps;
    public AudioClip[] moans;
    public AudioClip[] hits;

    Transform head;
    Transform root;
    NavMeshAgent ai;
    AudioSource source;

    void Start()
    {
        root = transform.Find("Root");
        head = transform.Find("Root/Head");
        ai = GetComponent<NavMeshAgent>();
        ai.SetDestination(Vector3.zero);
        source = GetComponent<AudioSource>();
        StartCoroutine("Walk");
        StartCoroutine("Moan");
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) < range)
        {
            Camera.main.SendMessage("ShowGameOver");
        }
    }

    void Footstep()
    {
        source.PlayOneShot(steps[Random.Range(0, steps.Length)]);
    }

    void Hit()
    {
        StopAllCoroutines();
        ai.Stop();
        source.PlayOneShot(moans[Random.Range(0, moans.Length)]);
        source.PlayOneShot(hits[Random.Range(0, hits.Length)]);
        foreach (Rigidbody body in GetComponentsInChildren<Rigidbody>())
        {
            body.transform.parent = null;
            body.gameObject.tag = "Untagged";
            body.useGravity = true;
            body.isKinematic = false;
            Fall fall = body.gameObject.AddComponent<Fall>();
            fall.hits = hits;
            StartCoroutine(Sink(body));
        }
        Destroy(gameObject, 10f);
    }

    IEnumerator Sink(Rigidbody body)
    {
        yield return new WaitForSeconds(5f);
        body.GetComponent<Collider>().enabled = false;
        body.useGravity = false;
        body.AddForce(Vector3.down, ForceMode.Impulse);
        yield return new WaitForSeconds(3f);
        Destroy(body.gameObject);
    }

    IEnumerator Moan()
    {
        for (;;)
        {
            yield return new WaitForSeconds(Random.Range(5f, 10f));
            source.PlayOneShot(moans[Random.Range(0, moans.Length)]);
        }
    }

    IEnumerator Walk()
    {
        for (;;)
        {
            float velocity = 0f;
            Footstep();
            for (float rotate = -tilt; rotate < tilt; rotate += velocity * Time.deltaTime)
            {
                root.localRotation = Quaternion.Euler(0f, 0f, rotate);
                yield return null;
                velocity += acceleration * Time.deltaTime;
            }

           head.localRotation = Quaternion.Euler(0f, 0f, tilt);

            velocity = 0f;
            Footstep();
            for (float rotate = tilt; rotate > -tilt; rotate -= velocity * Time.deltaTime)
            {
                root.localRotation = Quaternion.Euler(0f, 0f, rotate);
                yield return null;
                velocity += acceleration * Time.deltaTime;
            }

           head.localRotation = Quaternion.Euler(0f, 0f, -tilt);
        }
    }
}
