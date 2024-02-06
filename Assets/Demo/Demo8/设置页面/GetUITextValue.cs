using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public abstract class GetUITextValue : MonoBehaviour
{
    protected Text text;

    void Start()
    {
        text = GetComponent<Text>();
        SetTextValue();
    }

    protected virtual void SetTextValue() { }
}