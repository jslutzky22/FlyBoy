using UnityEngine;

public class TransparentObject : MonoBehaviour
{
    public Material solid;
    public Material transparent;
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Solid()
    {
        meshRenderer.material = solid;
    }

    public void SemiSolid()
    {
        meshRenderer.material = transparent;
    }
}
