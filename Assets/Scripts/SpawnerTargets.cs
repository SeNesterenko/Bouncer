using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerTargets : MonoBehaviour
{
    [SerializeField] private DestroyingTarget _destroyingTarget;
    [SerializeField] private int _countDestroyingTargets;
    
    [SerializeField] private RecoloringTarget _recoloringTarget;


    [SerializeField] private int _startPosition;
    [SerializeField] private int _finishPosition;

    [SerializeField] private Material[] _colors;
    

    private const float TargetYPosition = 6f;

    private void Start()
    {
        SpawnObjects(_recoloringTarget);

        for (var i = 0; i < _countDestroyingTargets; i++)
        {
            SpawnObjects(_destroyingTarget);
        }
    }

    private void SpawnObjects(MonoBehaviour gameObject)
    {
        var numberColor = Random.Range(0, _colors.Length);
        var obj = Instantiate(gameObject);
        obj.transform.position = new Vector3(Random.Range(_startPosition, _finishPosition), TargetYPosition, Random.Range(_startPosition, _finishPosition));
        obj.GetComponent<Renderer>().material.color = _colors[numberColor].color;
    }

    private void Update()
    {
        var recoloringTarget = FindObjectOfType<RecoloringTarget>();
        
        if (recoloringTarget == null)
        {
            SpawnObjects(_recoloringTarget);
        }
    }
}
