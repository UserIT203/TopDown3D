using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    public float Speed;
    public Transform AllPlacesPoint;

    private Transform[] _arrayPlaces;
    private int _numberOfPlace;

    private void Start()
    {
        _arrayPlaces = new Transform[AllPlacesPoint.childCount];

        for (int i = 0; i < AllPlacesPoint.childCount; i++)
            _arrayPlaces[i] = AllPlacesPoint.GetChild(i).GetComponent<Transform>();
    }

    public void Update()
    {
        var point = _arrayPlaces[_numberOfPlace];
        transform.position = Vector3.MoveTowards(transform.position, point.position, Speed * Time.deltaTime);

        if (transform.position == point.position) 
            NextPlace();
    }

    public Vector3 NextPlace()
    {
        _numberOfPlace++;

        if (_numberOfPlace == _arrayPlaces.Length)
            _numberOfPlace = 0;

        var pointVector = _arrayPlaces[_numberOfPlace].transform.position;
        transform.forward = pointVector - transform.position;

        return pointVector;
    }
}