using System.Collections.Generic;
using UnityEngine;

public class TransparencyCheck : MonoBehaviour
{
    public Transform player;

    public List<TransparentObject> caughtOnCamera;
    public List<TransparentObject> alreadyTransparent;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MakeThoseBuildingsTransparent();
        TransparentBuilding();
        UntransparentBuilding();
    }

    public void MakeThoseBuildingsTransparent()
    {
        caughtOnCamera.Clear();

        float cameraPlayerDistance = Vector3.Magnitude(transform.position - player.position);
        Ray rayForward = new Ray(transform.position, player.position - transform.position);
        Ray rayBackward = new Ray(player.position, transform.position - player.position);

        var hitForward = Physics.RaycastAll(rayForward, cameraPlayerDistance);
        var hitBackward = Physics.RaycastAll(rayBackward, cameraPlayerDistance);

        foreach (var hit in hitForward)
        {
            if (hit.collider.gameObject.TryGetComponent(out TransparentObject cameraTransparecy))
            {
                if (!caughtOnCamera.Contains(cameraTransparecy))
                {
                    caughtOnCamera.Add(cameraTransparecy);
                }
            }
        }
        foreach (var hit in hitBackward)
        {
            if (hit.collider.gameObject.TryGetComponent(out TransparentObject cameraTransparecy))
            {
                if (!caughtOnCamera.Contains(cameraTransparecy))
                {
                    caughtOnCamera.Add(cameraTransparecy);
                }
            }
        }
    }

    public void TransparentBuilding()
    {
        for (int i = 0; i < caughtOnCamera.Count; i++)
        {
            TransparentObject cameraTransparecy = caughtOnCamera[i];

            if (!alreadyTransparent.Contains(cameraTransparecy))
            {
                cameraTransparecy.SemiSolid();
                alreadyTransparent.Add(cameraTransparecy);
            }
        }
    }

    public void UntransparentBuilding()
    {
        for (int i = 0; i < alreadyTransparent.Count; i++)
        {
            TransparentObject cameraTransparecy = alreadyTransparent[i];

            if (!caughtOnCamera.Contains(cameraTransparecy))
            {
                cameraTransparecy.Solid();
                alreadyTransparent.Remove(cameraTransparecy);
            }
        }
    }
}
