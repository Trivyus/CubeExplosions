using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Spreader _spreader = new Spreader();

    private int _minCount = 2;
    private int _maxCount = 6;

    public Cube[] Spawn(Cube cube)
    {
        int count = Random.Range(_minCount, _maxCount + 1);

        Cube[] cubes = new Cube[count];

        for (int i = 0; i < count; i++)
        {
            cubes[i] = Instantiate(cube, GetRandomPosition(cube.transform.position), Quaternion.identity);
            cubes[i].ReduceParameters();
            _spreader.Explode(cubes[i], cube.transform.position);
        }

        return cubes;
    }

    private Vector3 GetRandomPosition(Vector3 position)
    {
        float x = position.x + Random.Range(-1f, 1f);
        float y = position.y + Random.Range(0f, 1f);
        float z = position.z + Random.Range(-1f, 1f);

        return new Vector3(x, y, z);
    }
}
