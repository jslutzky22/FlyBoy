using UnityEngine;

public class TransparentObject : MonoBehaviour
{
    public Material solid;
    public Material transparent;
    private MeshRenderer meshRenderer;
    public bool workAround;

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
        if (workAround)
        {
            meshRenderer.enabled = true;
        }
        else
        {
            meshRenderer.material = solid;
        }
    }

    public void SemiSolid()
    {
        if (workAround)
        {
            meshRenderer.enabled = false;
        }
        else
        {
            meshRenderer.material = transparent;
        }
    }
}
