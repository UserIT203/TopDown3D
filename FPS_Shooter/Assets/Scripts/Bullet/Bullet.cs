using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;

    private Vector3 _targetPosition;



    public void SetTargetPosition(Vector3 position) => _targetPosition = position;
}
