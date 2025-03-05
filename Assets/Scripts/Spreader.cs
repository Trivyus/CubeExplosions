using UnityEngine;

public class Spreader
{
    public void Scatter(Cube[] cubes, Vector3 explodePosition)
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            Rigidbody rigidbody = cubes[i].Rigidbody;
            rigidbody.AddExplosionForce(cubes[i].ScatterForce, explodePosition, cubes[i].ScatterRadius);
        }
    }
}
