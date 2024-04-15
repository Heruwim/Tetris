using UnityEngine;

public class MainTetris : MonoBehaviour
{
    private const int Height = 21;
    private const int Width = 13;
    private float _step = 1;
    private GameObject _prefabTetrisFigure;
    private TetrisFigure _tetrisFigure;

    private void Start()
    {
        _prefabTetrisFigure = Resources.Load("Prefabs/TetrisFigure") as GameObject;
        CreateFigure(TetrisFigures.Z);
    }

    private void CreateFigure(TetrisFigures figures)
    {
        _tetrisFigure = Instantiate(_prefabTetrisFigure, new Vector3(_step * 6, _step * (Height - 2)), Quaternion.identity).GetComponent<TetrisFigure>();
        _tetrisFigure.GetComponentInChildren<TetrisData>().Initialize(figures);
    }
}
