using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    [SerializeField] private PlayerBehavior _player;
    [SerializeField] private LayerMask _layer;
    [SerializeField] private float _force = 1f;
    [SerializeField] private Vector3 _startPosition;
    
    private const int MaxDistance = int.MaxValue;
    private Rigidbody _playerRigidbody;

    private void Start()
    {
        _playerRigidbody = _player.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_player.transform.position.y < -1)
        {
            _player.transform.position = _startPosition;
        }
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, MaxDistance, _layer))
        {
            if (Input.GetMouseButtonDown(0))
            {
                var destination = hitInfo.point - _player.transform.position;
                _playerRigidbody.AddForce(destination * _force);
            }
        }
    }


}
