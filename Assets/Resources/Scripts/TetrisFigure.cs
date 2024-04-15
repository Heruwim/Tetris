using UnityEngine;

public class TetrisFigure : MonoBehaviour
{
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
}
