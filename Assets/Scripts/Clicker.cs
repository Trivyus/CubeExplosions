using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Spawner _spawner;

    private Spreader _spreader = new Spreader();
    private Exploder _exploder = new Exploder();

    private void Update()
    {
        ClickOnCube();
    }

    private void ClickOnCube()
    {
        RaycastHit hit;

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
            if (Physics.Raycast(ray, out hit) && hit.transform.TryGetComponent(out Cube cube))
                if (cube.CanSplitUp())
                    _spreader.Scatter(_spawner.Spawn(cube), cube.transform.position);
                else 
                    _exploder.Explode(cube, cube.transform.position);
    }
}
