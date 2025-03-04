using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spreader
{
    public void Explode(Cube cube, Vector3 explodePosition)
    {
        Rigidbody rigidbody = cube.ReturnRigibody;

        rigidbody.AddExplosionForce(cube.ExplosionForce, explodePosition, cube.ExplosionRadius);
    }
}
