using UnityEngine;
using System.Collections;

public class Face : MonoBehaviour
{
    Material face;

    void Awake()
    {
        Renderer renderer = GetComponent<Renderer>();
        face = new Material(renderer.material);
        renderer.material = face;
    }

    void SetFace(Texture texture)
    {
        face.mainTexture = texture;
    }
}
