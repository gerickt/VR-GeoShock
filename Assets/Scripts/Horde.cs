using UnityEngine;
using System.Collections;

public class Horde : MonoBehaviour
{
    public Zombie zombie;
    public Texture[] faces;
    public float distance = 50f;

    void Start()
    {
        StartCoroutine(horde());
    }

    IEnumerator horde()
    {
        for (;;)
        {
            float timeToNext = 10f;

            float angle = Random.Range(-Mathf.PI, Mathf.PI);
            Vector3 position = new Vector3(Mathf.Sin(angle), 0f, Mathf.Cos(angle)) * distance;

           Zombie instance = Instantiate(zombie, position, Quaternion.identity) as Zombie;
           instance.BroadcastMessage("SetFace", faces[Random.Range(0, faces.Length)]);

            yield return new WaitForSeconds(timeToNext);
        }
    }
}
