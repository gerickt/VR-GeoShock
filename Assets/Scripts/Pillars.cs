using UnityEngine;
using System.Collections;

public class Pillars : MonoBehaviour 
{
    public Transform pillar;
    public int width = 4;
    public int depth = 4;

    public float spacing = 20f;
    public float height = 5f;

    void Start()
    {
        float halfWidth = ((width + 1) * spacing) / 2f;
        float halfDepth = ((depth + 1) * spacing) / 2f;
 
        for (int i = 1; i <= width; ++i)
        {
            for (int j = 1; j <= depth; ++j)
            {
                Vector3 position = new Vector3(spacing * i - halfWidth, height, spacing * j - halfDepth);
                Instantiate(pillar, position, Quaternion.identity);
            }
        }
    }
}
