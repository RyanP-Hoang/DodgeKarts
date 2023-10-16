using UnityEngine;

public class BGScroller : MonoBehaviour
{
    [Range(-1f, 10f)]
    public float scrollSpeed = 5f;
    private float offset;
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
