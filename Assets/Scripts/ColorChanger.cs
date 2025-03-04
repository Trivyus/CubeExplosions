using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger
{
    public void SetRandomColor(Renderer renderer)
    {
        renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}
