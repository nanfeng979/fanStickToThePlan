using UnityEngine;
using Y9g;

public class Demo7_2_Player : MonoBehaviour, IMove
{
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnMove(Move4Direction direction)
    {
        switch (direction)
        {
            case Move4Direction.Up:
                rectTransform.Translate(Vector3.up);
                break;
            case Move4Direction.Down:
                rectTransform.Translate(Vector3.down);
                break;
            case Move4Direction.Left:
                rectTransform.Translate(Vector3.left);
                break;
            case Move4Direction.Right:
                rectTransform.Translate(Vector3.right);
                break;
        }
    }
}