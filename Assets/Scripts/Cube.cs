using UnityEngine;

public class Cube : MonoBehaviour
{
    private const string Color = "_Color";

    private CubeSpawner _spawner;
    private Renderer _renderer;
    private Explosion _explosion;
    private int _separator = 2;

    private void OnEnable()
    {
        _renderer = GetComponent<Renderer>();
        _explosion = GetComponent<Explosion>();
    }

    private void OnMouseUpAsButton()
    {
        _explosion.Explode();
        _spawner = GetComponentInParent<CubeSpawner>();
        _spawner.SpawnCube(gameObject);
        Destroy(gameObject);
    }

    public void InitCube(Transform parent)
    {
        transform.localScale /= _separator;
        transform.SetParent(parent);
        _renderer.material.SetColor(Color,Random.ColorHSV());
    }
}
