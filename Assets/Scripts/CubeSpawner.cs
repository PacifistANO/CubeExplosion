using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private int _lowCount;
    [SerializeField] private int _highCount;
    [SerializeField] private int _highChance;

    private int _cubesCount;
    private int _spawnChance = 100;
    private int _failChance;
    private int _separator = 2;

    public bool IsSpawned { get; private set; }

    public void SpawnCube(Cube cube)
    {
        _failChance = Random.Range(0, _highChance);

        if (_failChance < _spawnChance)
        {
            IsSpawned = true;
            _spawnChance /= _separator;
            _cubesCount = Random.Range(_lowCount, _highCount + 1);

            for (int i = 0; i < _cubesCount; i++)
            {
                Cube newCube = Instantiate(cube, cube.transform.position, Quaternion.identity);
                newCube.InitCube(transform);
            }
        }
        else
        {
            IsSpawned = false;
        }
    }
}
