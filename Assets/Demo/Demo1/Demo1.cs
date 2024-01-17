using UnityEngine;

public class Demo1 : MonoBehaviour
{
    public GameObject mapBlock;

    void Start()
    {
        Y9g.MapGenerate.GenerateMap(10, 10, mapBlock, 0.5f, true);
    }


    void Update()
    {
        
    }

    private void OnDrawGizmos() {
        Y9g.DrawGizmos drawGizmos = new Y9g.DrawGizmos();
        drawGizmos.DrawLineXYZ(3.0f);
    }

}