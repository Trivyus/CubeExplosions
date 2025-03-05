using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder
{
    public void Explode(Cube cube, Vector3 explodePosition)
    {
        cube.Destroy();
        foreach (var explodableObject in GetExplodableObjects(explodePosition, cube.ExplosionRadius))
            explodableObject.AddExplosionForce(cube.ExplosionForce, explodePosition, cube.ExplosionRadius);
    }

    private List<Rigidbody> GetExplodableObjects(Vector3 explodePosition, float explosionRadius)
    {
        Collider[] colliders = Physics.OverlapSphere(explodePosition, explosionRadius);

        List<Rigidbody> explodableObjects = new List<Rigidbody>();

        foreach (var collider in colliders)
            if(collider.attachedRigidbody != null)
                explodableObjects.Add(collider.attachedRigidbody);

        return explodableObjects;
    }
}
