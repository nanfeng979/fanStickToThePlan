using UnityEngine;

public abstract class Page : MonoBehaviour, Y9g.IMove
{
    public virtual GameObject GetCurrentObject()
    {
        return null;
    }

    public virtual void OnMove(Y9g.Move4Direction direction) { }
}