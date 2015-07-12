using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    public Rigidbody shotPrefab;
    public float shotPower = 100f;

    float timer = 0f;
    Transform currentTarget;
    AudioSource source;

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        /*Ray ray = new Ray(transform.position, transform.forward * 200f);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.transform.root == currentTarget)
            {
                timer += Time.deltaTime;
            }
            else if (hitInfo.collider.CompareTag("Zombie"))
            {
                currentTarget = hitInfo.collider.transform.root;
                timer = 0f;
            }

            if (timer > 1f)
            {
                Rigidbody shot = Instantiate(shotPrefab, transform.position, transform.rotation) as Rigidbody;
                shot.AddForce(transform.forward * shotPower, ForceMode.Impulse);
                timer = 0f;
                source.Play();
            }
        }*/
    }
}
