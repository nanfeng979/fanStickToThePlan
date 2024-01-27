using UnityEngine;

public abstract class Page : MonoBehaviour, Y9g.IMove, Y9g.IMoveDown
{
    // public event System.Action<int> OnPlaySound;
    private void OnEnable() {
        if (InputManager.Instance != null)
        {
            InputManager.Instance.AddNewPage(this);
        }
    }

    private void OnDisable() {
        if (InputManager.Instance != null)
        {
            InputManager.Instance.DeleteLastPage(this);
            Init();
        }
    }

    protected virtual void Init() { }

    public virtual GameObject GetCurrentObject()
    {
        return null;
    }

    public virtual void OnMove(Y9g.Move4Direction direction) { }
    public virtual void OnMoveDown(Y9g.Move4Direction direction) { }
}