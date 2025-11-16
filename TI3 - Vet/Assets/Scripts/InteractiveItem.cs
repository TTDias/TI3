using UnityEditor;
using UnityEngine;

public abstract class InteractiveItem : MonoBehaviour
{
    protected Outline highlight;


    public void Focus()
    {
        UIRepairScript.Instance.Select(this);
        highlight.OutlineColor = Color.white;
    }

    public void Unfocus()
    {
        highlight.OutlineColor = Color.black;
    }

    public abstract void Use();
}
