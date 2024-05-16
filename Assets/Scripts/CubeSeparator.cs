using UnityEngine;

public class CubeSeparator : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private int _lowCount;
    [SerializeField] private int _highCount;
    [SerializeField] private int _highChance;

    private int _spawnChance = 100;
    private int _coefficient = 2;

    private void Start()
    {
        Instantiate(_prefab).transform.SetParent(transform);
    }

    public void TrySplitCube(Cube cube)
    {
        int failChance = Random.Range(0, _highChance);

        if (failChance < _spawnChance)
        {
            _spawnChance /= _coefficient;
            CreateCubes(cube);
        }
        else
        {
            cube.Blow();
        }
    }

    public void CreateCubes(Cube cube)
    {
        int cubesCount = Random.Range(_lowCount, _highCount + 1);

        for (int i = 0; i < cubesCount; i++)
        {
            Cube newCube = Instantiate(cube, cube.transform.position, Quaternion.identity);
            newCube.Init(transform);
        }
    }
}
