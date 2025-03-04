using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 300;
    [SerializeField] private float _explosionRadius = 650;

    private Rigidbody _rigidbody;
    private ColorChanger _colorChanger = new ColorChanger();

    private int _spawnChance = 100;
    private int _maxSpawnChance = 100;
    private int _spawnChanceLowering = 2;
    private int _scaleLowering = 2;

    public float ExplosionForce => _explosionForce;
    public float ExplosionRadius => _explosionRadius;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _colorChanger.SetRandomColor(GetComponent<Renderer>());
    }

    public Rigidbody ReturnRigibody =>
        _rigidbody;

    public bool CanSplitUp()
    {
        return Random.Range(0, _maxSpawnChance + 1) <= _spawnChance;
    }

    public void ReduceParameters()
    {
        Vector3 scale = transform.localScale;

        _spawnChance /= _spawnChanceLowering;
        scale /= _scaleLowering;
        transform.localScale = scale;
    }
}
