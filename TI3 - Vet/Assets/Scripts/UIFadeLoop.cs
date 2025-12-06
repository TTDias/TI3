using UnityEngine;
using UnityEngine.UI;

public class UIFadeLoop : MonoBehaviour
{
    void Start()
    {
        LeanTween.alphaText(GetComponent<RectTransform>(), 0, 0.6f).setLoopPingPong().setEaseInBack();
    }

}
