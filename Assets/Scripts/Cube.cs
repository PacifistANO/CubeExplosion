using UnityEngine;

[RequireComponent(typeof(Renderer), typeof(Explosion))]
public class Cube : MonoBehaviour
{
    private const string Color = "_Color";

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
        CubeSeparator splitter = GetComponentInParent<CubeSeparator>();

        if (splitter != null)
            splitter.TrySplitCube(this);

        Destroy(gameObject);
    }

    public void Init(Transform parent)
    {
        _renderer.material.SetColor(Color, Random.ColorHSV());
        transform.localScale /= _separator;
        transform.SetParent(parent);
    }

    public void Blow()
    {
        _explosion.Explode();
    }
}
