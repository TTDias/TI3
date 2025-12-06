using UnityEditor;
using UnityEngine;

public abstract class InteractiveItem : MonoBehaviour
{
    protected Outline highlight;


    public void Focus()
    {
        BuildButton.Instance.Select(this);
        highlight.OutlineColor = Color.white;
    }

    public void Unfocus()
    {
        BuildButton.Instance.Deselect();
        highlight.OutlineColor = Color.black;
    }

    public abstract void Use();
}
