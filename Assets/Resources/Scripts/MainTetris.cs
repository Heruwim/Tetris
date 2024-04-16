using System.Collections;
using UnityEngine;

public class MainTetris : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;

    private const int Height = 21;
    private const int Width = 13;
    private float _step = 1;
    private float _currentTime;
    private GameObject _prefabTetrisFigure;
    private Object _prefabTetrisCell;
    private TetrisFigure _tetrisFigure;
    private TetrisFieldElement[,] _fieldCells;

    private void Start()
    {
        _currentTime = 0;
        _fieldCells = new TetrisFieldElement[Width, Height];
        _prefabTetrisFigure = Resources.Load("Prefabs/TetrisFigure") as GameObject;
        _prefabTetrisCell = Resources.Load("Prefabs/CellPrefab");

        CreateTetrisField();

        CreateFigure(TetrisFigures.Z);
        StartCoroutine(UpdateCoroutine(_speed));
    }

    private void Update()
    {
        InputPress(0.05f);
    }

    private void InputPress( float time)
    {
        _currentTime += Time.deltaTime;
        if(_currentTime >= time)
        {
            _currentTime = 0;
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            if (horizontalInput < 0)
            {
                _tetrisFigure.SetDirectionFigure(DirectionFigure.LEFT);
                if (CheckIntersect(_tetrisFigure))
                {
                    _tetrisFigure.SetDirectionFigure(DirectionFigure.RIGHT);
                }

            }
            else if (horizontalInput > 0)
            {
                _tetrisFigure.SetDirectionFigure(DirectionFigure.RIGHT);
                if (CheckIntersect(_tetrisFigure))
                {
                    _tetrisFigure.SetDirectionFigure(DirectionFigure.LEFT);
                }
            }
            else if (verticalInput < 0)
            {
                _tetrisFigure.DropTetrisFigure(true);
                if (CheckIntersect(_tetrisFigure))
                {
                    _tetrisFigure.DropTetrisFigure(false);
                }
            }

        }
    }

    private void CreateFigure(TetrisFigures figures)
    {
        _tetrisFigure = Instantiate(_prefabTetrisFigure, new Vector3(_step * 6, _step * (Height - 2)), Quaternion.identity).GetComponent<TetrisFigure>();
        _tetrisFigure.GetComponentInChildren<TetrisData>().Initialize(figures);
    }

    private IEnumerator UpdateCoroutine(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            _tetrisFigure.DropTetrisFigure(true);

            if(CheckPreIntersect(_tetrisFigure))
            {
                break;
            }
        }
    }

    private void CreateTetrisField()
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                GameObject cell = Instantiate(_prefabTetrisCell, new Vector3(x * _step, y * _step, 0), Quaternion.identity) as GameObject;
                _fieldCells[x, y] = cell.GetComponent<TetrisFieldElement>();
            }
        }
    }

    private bool IsIntersect(int x, int y)
    {
        try
        {
            if (_fieldCells[x, y].GetIsCellActive())
            {
                return true;
            }
        }
        catch (System.Exception)
        {

            return true;
        }
        
        return false;
    }

    private bool CheckPreIntersect(TetrisFigure figure)
    {
        for (int i = 0; i < figure.GetSegmetns().Length; i++)
        {
            int x = (int)figure.GetSegmetns()[i].transform.position.x;
            int y = (int)figure.GetSegmetns()[i].transform.position.y;

            bool isIntersect = IsIntersect(x, y);
            if (isIntersect)
            {
                figure.DropTetrisFigure(false);
                return isIntersect;
            }
        }

        return false;
    }private bool CheckIntersect(TetrisFigure figure)
    {
        for (int i = 0; i < figure.GetSegmetns().Length; i++)
        {
            int x = (int)figure.GetSegmetns()[i].transform.position.x;
            int y = (int)figure.GetSegmetns()[i].transform.position.y;

            bool isIntersect = IsIntersect(x, y);
            if (isIntersect)
            {
                return isIntersect;
            }
        }

        return false;
    }
}
