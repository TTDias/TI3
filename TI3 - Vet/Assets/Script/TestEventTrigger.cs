using UnityEngine;
using UnityEngine.EventSystems;

public class TesteClique : MonoBehaviour, IPointerDownHandler
{
    public MeshRenderer mesh;
    public CatItens item;
    public Material broken, repaired;

    public void Broke()
    {
        mesh.material = broken;
        item.broken = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        mesh.material = repaired;
        item.broken = false;
    }
    private void OnMouseDown()
    {
        mesh.material = repaired;
        item.broken = false;
    }
}