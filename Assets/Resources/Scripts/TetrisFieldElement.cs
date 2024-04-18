using UnityEngine;

public class TetrisFieldElement : MonoBehaviour
{
    //Parent element of the field cell(my_tetrino_element)
    private FieldCell _fieldCell;

    private void Awake()
    {
        _fieldCell = GetComponentInChildren<FieldCell>();
        _fieldCell.gameObject.SetActive(false);
    }

    public bool GetIsCellActive() 
    {
        return _fieldCell.gameObject.activeSelf;
    }

    public void SetCellActive(bool active)
    {
        _fieldCell.gameObject.SetActive(active);
    }

    public void SetCellColor(Color color)
    {
        _fieldCell.GetComponent<SpriteRenderer>().color = color;
        // _fieldCell.GetComponent <SpriteRenderer>().material.color = color;
    }
}
