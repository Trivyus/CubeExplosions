using UnityEngine;

public class Exploder
{
    public void Explode(Cube[] cubes, Vector3 explodePosition)
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            Rigidbody rigidbody = cubes[i].Rigidbody;
            rigidbody.AddExplosionForce(cubes[i].ExplosionForce, explodePosition, cubes[i].ExplosionRadius);
        }
    }
}
