using UnityEngine;

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
}
