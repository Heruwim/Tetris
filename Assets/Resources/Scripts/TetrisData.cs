using UnityEngine;

public enum TetrisFigures
{
    L,
    Z,
    I,
    O,
    T,
}

public class TetrisData : MonoBehaviour
{
    private TetrisFigures _type;
    private GameObject _prefabCube;
    private GameObject[] _tetrisFigures;
    private int _rotation;

    public GameObject[] GetTetrisFigures {  get { return _tetrisFigures; } }

    private void Awake()
    {
        _rotation = 0;
        _tetrisFigures = new GameObject[4];

        _prefabCube = Resources.Load("Prefabs/Prefabcube") as GameObject;
    }

    public void Initialize(TetrisFigures figureType)
    {
        for (int index = 0; index < transform.childCount; index++)
        {
            Destroy(transform.GetChild(index).gameObject);
        }

        switch (figureType)
        {
            case TetrisFigures.L:
                CreateFigure(figureType, new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(0, -1, 0), new Vector3(1, -1, 0));
                break;
            case TetrisFigures.Z:
                CreateFigure(figureType, new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(-1, 1, 0), new Vector3(1, 0, 0));
                break;
            case TetrisFigures.I:
                CreateFigure(figureType, new Vector3(0, 0, 0), new Vector3(0, -1, 0), new Vector3(0, 1, 0), new Vector3(0, 2, 0));
                break;
            case TetrisFigures.O:
                CreateFigure(figureType, new Vector3(0, 0, 0), new Vector3(-1, 0, 0), new Vector3(-1, -1, 0), new Vector3(0, -1, 0));  
                break;
            case TetrisFigures.T:
                CreateFigure(figureType, new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(-1, 0, 0), new Vector3(0, 1, 0));
                break;
            default:
                break;
        }

    }

    private void CreateFigure(TetrisFigures figureType, Vector3 segmentPosition1, Vector3 segmentPosition2, Vector3 segmentPosition3, Vector3 segmentPosition4)
    {
        _type = figureType;
        GameObject segment1 = Instantiate(_prefabCube, segmentPosition1, Quaternion.identity);
        segment1.AddComponent<TetrisFigureSegmetn>();
        segment1.transform.SetParent(transform, false);

        GameObject segment2 = Instantiate(_prefabCube, segmentPosition2, Quaternion.identity);
        segment2.AddComponent<TetrisFigureSegmetn>();
        segment2.transform.SetParent(transform, false);

        GameObject segment3 = Instantiate(_prefabCube, segmentPosition3, Quaternion.identity);
        segment3.AddComponent<TetrisFigureSegmetn>();
        segment3.transform.SetParent(transform, false);

        GameObject segment4 = Instantiate(_prefabCube, segmentPosition4, Quaternion.identity);
        segment4.AddComponent<TetrisFigureSegmetn>();
        segment4.transform.SetParent(transform, false);

        for (int i = 0; i < _tetrisFigures.Length; i++)
        {
            _tetrisFigures[i] = transform.GetChild(i).gameObject;
        }
    }

    public void DirectionRotation(bool isPositive)
    {
        if (isPositive)
        {
            _rotation++;
            _rotation %= 4;
        }
        else
        {
            _rotation--;
            if (_rotation < 0)
            {
                _rotation = 3;
            }
        }

        FigureRotation(_type, _rotation);
    }

    private void FigureRotation(TetrisFigures figures, int rotation)
    {
        switch (rotation)
        {
            case 0:
                if(figures == TetrisFigures.L)
                {
                    _tetrisFigures[0].transform.localPosition = new Vector3(0, 0, 0);
                    _tetrisFigures[1].transform.localPosition = new Vector3(0, 1, 0);
                    _tetrisFigures[2].transform.localPosition = new Vector3(0, -1, 0);
                    _tetrisFigures[3].transform.localPosition = new Vector3(1, -1, 0);
                }
              
                else if(figures == TetrisFigures.Z)
                {
                    _tetrisFigures[0].transform.localPosition = new Vector3(0, 0, 0);
                    _tetrisFigures[1].transform.localPosition = new Vector3(0, 1, 0);
                    _tetrisFigures[2].transform.localPosition = new Vector3(-1, 1, 0);
                    _tetrisFigures[3].transform.localPosition = new Vector3(1, 0, 0);
                }

                else if (figures == TetrisFigures.I)
                {
                    _tetrisFigures[0].transform.localPosition = new Vector3(0, 0, 0);
                    _tetrisFigures[1].transform.localPosition = new Vector3(0, -1, 0);
                    _tetrisFigures[2].transform.localPosition = new Vector3(0, 1, 0);
                    _tetrisFigures[3].transform.localPosition = new Vector3(0, 2, 0);
                }

                else if (figures == TetrisFigures.O)
                {
                    _tetrisFigures[0].transform.localPosition = new Vector3(0, 0, 0);
                    _tetrisFigures[1].transform.localPosition = new Vector3(-1, 0, 0);
                    _tetrisFigures[2].transform.localPosition = new Vector3(-1, -1, 0);
                    _tetrisFigures[3].transform.localPosition = new Vector3(0, -1, 0);
                }

                else if (figures == TetrisFigures.T)
                {
                    _tetrisFigures[0].transform.localPosition = new Vector3(0, 0, 0);
                    _tetrisFigures[1].transform.localPosition = new Vector3(1, 0, 0);
                    _tetrisFigures[2].transform.localPosition = new Vector3(-1, 0, 0);
                    _tetrisFigures[3].transform.localPosition = new Vector3(0, 1, 0);
                }

                break; 

            case 1:
                if(figures == TetrisFigures.L)
                {
                    _tetrisFigures[0].transform.localPosition = new Vector3(0, 0, 0);
                    _tetrisFigures[1].transform.localPosition = new Vector3(1, 0, 0);
                    _tetrisFigures[2].transform.localPosition = new Vector3(-1, 0, 0);
                    _tetrisFigures[3].transform.localPosition = new Vector3(-1, -1, 0);
                }

                else if (figures == TetrisFigures.Z)
                {
                    _tetrisFigures[0].transform.localPosition = new Vector3(0, 0, 0);
                    _tetrisFigures[1].transform.localPosition = new Vector3(1, 0, 0);
                    _tetrisFigures[2].transform.localPosition = new Vector3(1, 1, 0);
                    _tetrisFigures[3].transform.localPosition = new Vector3(0, -1, 0);
                }

                else if (figures == TetrisFigures.I)
                {
                    _tetrisFigures[0].transform.localPosition = new Vector3(0, 0, 0);
                    _tetrisFigures[1].transform.localPosition = new Vector3(-1, 0, 0);
                    _tetrisFigures[2].transform.localPosition = new Vector3(1, 0, 0);
                    _tetrisFigures[3].transform.localPosition = new Vector3(2, 0, 0);
                }

                else if (figures == TetrisFigures.O)
                {
                    _tetrisFigures[0].transform.localPosition = new Vector3(0, 0, 0);
                    _tetrisFigures[1].transform.localPosition = new Vector3(-1, 0, 0);
                    _tetrisFigures[2].transform.localPosition = new Vector3(-1, -1, 0);
                    _tetrisFigures[3].transform.localPosition = new Vector3(0, -1, 0);
                }

                else if (figures == TetrisFigures.T)
                {
                    _tetrisFigures[0].transform.localPosition = new Vector3(0, 0, 0);
                    _tetrisFigures[1].transform.localPosition = new Vector3(1, 0, 0);
                    _tetrisFigures[2].transform.localPosition = new Vector3(0, -1, 0);
                    _tetrisFigures[3].transform.localPosition = new Vector3(0, 1, 0);
                }

                break;

            case 2:
                if(figures == TetrisFigures.L)
                {
                    _tetrisFigures[0].transform.localPosition = new Vector3(0, 0, 0);
                    _tetrisFigures[1].transform.localPosition = new Vector3(0, 1, 0);
                    _tetrisFigures[2].transform.localPosition = new Vector3(0, -1, 0);
                    _tetrisFigures[3].transform.localPosition = new Vector3(-1, 1, 0);
                }

                else if (figures == TetrisFigures.Z)
                {
                    _tetrisFigures[0].transform.localPosition = new Vector3(0, 0, 0);
                    _tetrisFigures[1].transform.localPosition = new Vector3(0, 1, 0);
                    _tetrisFigures[2].transform.localPosition = new Vector3(-1, 1, 0);
                    _tetrisFigures[3].transform.localPosition = new Vector3(1, 0, 0);
                }

                else if (figures == TetrisFigures.I)
                {
                    _tetrisFigures[0].transform.localPosition = new Vector3(0, 0, 0);
                    _tetrisFigures[1].transform.localPosition = new Vector3(0, -1, 0);
                    _tetrisFigures[2].transform.localPosition = new Vector3(0, 1, 0);
                    _tetrisFigures[3].transform.localPosition = new Vector3(0, 2, 0);
                }

                else if (figures == TetrisFigures.O)
                {
                    _tetrisFigures[0].transform.localPosition = new Vector3(0, 0, 0);
                    _tetrisFigures[1].transform.localPosition = new Vector3(-1, 0, 0);
                    _tetrisFigures[2].transform.localPosition = new Vector3(-1, -1, 0);
                    _tetrisFigures[3].transform.localPosition = new Vector3(0, -1, 0);
                }

                else if (figures == TetrisFigures.T)
                {
                    _tetrisFigures[0].transform.localPosition = new Vector3(0, 0, 0);
                    _tetrisFigures[1].transform.localPosition = new Vector3(1, 0, 0);
                    _tetrisFigures[2].transform.localPosition = new Vector3(-1, 0, 0);
                    _tetrisFigures[3].transform.localPosition = new Vector3(0, -1, 0);
                }

                break;

            case 3:
                if(figures == TetrisFigures.L)
                {
                    _tetrisFigures[0].transform.localPosition = new Vector3(0, 0, 0);
                    _tetrisFigures[1].transform.localPosition = new Vector3(1, 0, 0);
                    _tetrisFigures[2].transform.localPosition = new Vector3(-1, 0, 0);
                    _tetrisFigures[3].transform.localPosition = new Vector3(1, 1, 0);
                }

                else if (figures == TetrisFigures.Z)
                {
                    _tetrisFigures[0].transform.localPosition = new Vector3(0, 0, 0);
                    _tetrisFigures[1].transform.localPosition = new Vector3(1, 0, 0);
                    _tetrisFigures[2].transform.localPosition = new Vector3(1, 1, 0);
                    _tetrisFigures[3].transform.localPosition = new Vector3(0, -1, 0);
                }

                else if (figures == TetrisFigures.I)
                {
                    _tetrisFigures[0].transform.localPosition = new Vector3(0, 0, 0);
                    _tetrisFigures[1].transform.localPosition = new Vector3(-1, 0, 0);
                    _tetrisFigures[2].transform.localPosition = new Vector3(1, 0, 0);
                    _tetrisFigures[3].transform.localPosition = new Vector3(2, 0, 0);
                }

                else if (figures == TetrisFigures.O)
                {
                    _tetrisFigures[0].transform.localPosition = new Vector3(0, 0, 0);
                    _tetrisFigures[1].transform.localPosition = new Vector3(-1, 0, 0);
                    _tetrisFigures[2].transform.localPosition = new Vector3(-1, -1, 0);
                    _tetrisFigures[3].transform.localPosition = new Vector3(0, -1, 0);
                }

                else if (figures == TetrisFigures.T)
                {
                    _tetrisFigures[0].transform.localPosition = new Vector3(0, 0, 0);
                    _tetrisFigures[1].transform.localPosition = new Vector3(0, 1, 0);
                    _tetrisFigures[2].transform.localPosition = new Vector3(-1, 0, 0);
                    _tetrisFigures[3].transform.localPosition = new Vector3(0, -1, 0);
                }

                break;

            default:
                break;
            
           
        }
    }
}
