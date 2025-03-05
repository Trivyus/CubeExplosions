using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int _minCount = 2;
    private int _maxCount = 6;

    public Cube[] Spawn(Cube cube)
    {
        int count = Random.Range(_minCount, _maxCount + 1);
        Vector3 cubePosition = cube.transform.position;
        cube.Destroy();

        Cube[] cubes = new Cube[count];

        for (int i = 0; i < count; i++)
        {
            cubes[i] = Instantiate(cube, GetRandomPosition(cubePosition), Quaternion.identity);
            cubes[i].ChangeParameters();
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
