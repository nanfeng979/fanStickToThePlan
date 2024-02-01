using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Y9g;

public class Demo8_2_Player : MonoBehaviour, IMoveDown
{
    private List<List<int>> mapIndex;
    private Vector2Int playerIndex;

    public void OnMoveDown(Move4Direction direction)
    {
        switch (direction)
        {
            case Move4Direction.Up:
                if (Utils.IsCrossTheBorderBy2DArray(ref mapIndex, playerIndex, (int)Move4Direction.Up - 1))
                {
                    Debug.Log("Up can move");
                }
                break;
            case Move4Direction.Down:
                if (Utils.IsCrossTheBorderBy2DArray(ref mapIndex, playerIndex, (int)Move4Direction.Down - 1))
                {
                    Debug.Log("Down can move");
                }
                break;
            case Move4Direction.Left:
                if (Utils.IsCrossTheBorderBy2DArray(ref mapIndex, playerIndex, (int)Move4Direction.Left - 1))
                {
                    Debug.Log("Left can move");
                }
                break;
            case Move4Direction.Right:
                if (Utils.IsCrossTheBorderBy2DArray(ref mapIndex, playerIndex, (int)Move4Direction.Right - 1))
                {
                    Debug.Log("Right can move");
                }
                break;
        }
    }

    public void SetMapIndex(List<List<int>> mapIndex)
    {
        this.mapIndex = mapIndex;
    }

    public void SetPlayerIndex(Vector2Int playerIndex)
    {
        this.playerIndex = playerIndex;
    }

}