using System;
using UnityEngine;

public enum DirectionFigure: int { LEFT = -1,  RIGHT = 1, DOWN };

public class TetrisFigure : MonoBehaviour
{
    // script my_tetrino_figure
    public void DropTetrisFigure(bool isPositive)
    {
        if (isPositive)
        {
            transform.Translate(Vector3.down);
        }
        else
        {
            transform.Translate(Vector3.up);
        }
    }

    public TetrisFigureSegmetn[] GetSegmetns()
    {
        return GetComponentsInChildren<TetrisFigureSegmetn>();
    }

    public void SetDirectionFigure(DirectionFigure direction)
    {
        transform.Translate((int)direction, 0 , 0);
    }
}
