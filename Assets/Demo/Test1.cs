using UnityEngine;

public class Test1 : MonoBehaviour
{
    public GameObject mapBlock;

    void Start()
    {
        Y9g.MapGenerate.GenerateMap(10, 10, mapBlock, 2.0f, true);
    }


    void Update()
    {
        
    }

    private void OnDrawGizmos() {
        Y9g.DrawGizmos drawGizmos = new Y9g.DrawGizmos();
        drawGizmos.DrawLine(Vector3.zero, Vector3.up, 3.0f);
    }

}