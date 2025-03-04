using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Spawner _spawner;

    private void Update()
    {
        ClickOnCube();
    }

    private void ClickOnCube()
    {
        RaycastHit hit;

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
            if (hit.transform.TryGetComponent<Cube>(out Cube cube))
            {
                if (cube.CanSplitUp())
                {
                    _spawner.Spawn(cube);
                }

                Destroy(cube.gameObject);
            }
    }
}
