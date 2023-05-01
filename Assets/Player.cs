using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public GameObject GridObject;
    private Grid _grid;
    private Vector3Int _managedGridPosition;
    private Vector3Int _gridPosition
    {
        get => _managedGridPosition;
        set
        {
            _managedGridPosition = value;
            var worldPosition = _grid.CellToWorld(value);
            gameObject.transform.position = worldPosition;
        }
    }
    void Start()
    {
        _grid = GridObject.GetComponent<Grid>();
        _gridPosition = new Vector3Int(0, 0, 0);
    }

    void Update()
    {
        Vector3Int intendedPosition;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            intendedPosition = _gridPosition + new Vector3Int(0, 1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            intendedPosition = _gridPosition + new Vector3Int(0, -1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            intendedPosition = _gridPosition + new Vector3Int(-1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            intendedPosition = _gridPosition + new Vector3Int(1, 0, 0);
        }
        else
        {
            return;
        }

        var objects = GridObject.transform.Find("ObjectsTilemap").gameObject.GetComponent<Tilemap>();
        var tile = objects.GetTile(intendedPosition);
        Debug.Log(intendedPosition);
        Debug.Log(tile);
        if (tile == null)
        {
            _gridPosition = intendedPosition;
            // https://gamedev.stackexchange.com/questions/188676/effective-solution-for-showing-the-outline-of-the-player-sprite-when-behind-obje
            // render outline of player when behind an object
        }
    }
}
