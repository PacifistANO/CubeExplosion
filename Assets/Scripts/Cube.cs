using UnityEngine;

[RequireComponent(typeof(Renderer), typeof(Explosion))]
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
        _spawner = GetComponentInParent<CubeSpawner>();
        _spawner.SpawnCube(this);

        if (_spawner.IsSpawned == false)
            _explosion.Explode();

        Destroy(gameObject);
    }

    public void InitCube(Transform parent)
    {
        transform.localScale /= _separator;
        transform.SetParent(parent);
        _renderer.material.SetColor(Color, Random.ColorHSV());
    }
}
