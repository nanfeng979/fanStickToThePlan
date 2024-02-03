using UnityEngine;

public abstract class ConfirmGenerate : ButtonGenerate
{
    [SerializeField]
    protected AcceptFunction acceptFunction;
    [SerializeField]
    protected CancelFunction cancelFunction;
    
    protected override void Start()
    {
        // 注册“接受”函数。
        acceptFunction?.RegisterAcceptFunction(AcceptFunction);
        // 注册“取消”函数。
        cancelFunction?.RegisterCancelFunction(CancelFunction);

        base.Start();
    }

    protected virtual void AcceptFunction()
    {
        Debug.Log("AcceptFunction");
    }

    protected virtual void CancelFunction()
    {
        Debug.Log("CancelFunction");
    }
}