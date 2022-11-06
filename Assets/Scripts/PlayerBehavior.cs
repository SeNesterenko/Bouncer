using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _target;
    private const float StoppingDistance = 0.1f;
    private bool _isMoving;

    private void Update()
    {
        if (!_isMoving)
        {
            return;
        }

        var distanceToDestination = Vector3.Distance(_target, transform.position);
        var shouldStop = distanceToDestination < StoppingDistance;

        if (shouldStop)
        {
            _isMoving = false;
            return;
        }

        var step = Time.deltaTime * _speed;
        transform.position = Vector3.MoveTowards(transform.position, _target, step);
    }

    public void StartMove(Vector3 target)
    {
        _isMoving = true;
        _target = target;
    }
}
