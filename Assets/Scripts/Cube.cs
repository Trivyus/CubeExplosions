using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [field: SerializeField] public float ScatterForce { get; private set; } = 300;
    [field: SerializeField] public float ScatterRadius { get; private set; } = 650;
    [field: SerializeField] public float ExplosionForce { get; private set; } = 150;
    [field: SerializeField] public float ExplosionRadius { get; private set; } = 350;

    private ColorChanger _colorChanger = new ColorChanger();

    private int _spawnChance = 100;
    private int _maxSpawnChance = 100;
    private int _spawnChanceLowering = 2;
    private int _scaleLowering = 2;
    private int _explosionForceIncrease = 2;
    private int _explosionRadiusIncrease = 2;

    public Rigidbody Rigidbody {  get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        _colorChanger.SetRandomColor(GetComponent<Renderer>());
    }

    public void Destroy() => Destroy(gameObject);

    public bool CanSplitUp()
    {
        return Random.Range(0, _maxSpawnChance + 1) <= _spawnChance;
    }

    public void ChangeParameters()
    {
        Vector3 scale = transform.localScale;

        _spawnChance /= _spawnChanceLowering;
        scale /= _scaleLowering;
        transform.localScale = scale;
        ExplosionForce *= _explosionForceIncrease;
        ExplosionRadius *= _explosionRadiusIncrease;
    }
}