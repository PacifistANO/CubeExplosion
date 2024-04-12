using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private Cube _cube;
    private int _cubesCount;
    private int _lowCount = 2;
    private int _highCount = 4;
    private int _spawnChance = 100;
    private int _highChance = 100;
    private int _lowChance = 0;
    private int _failChance;
    private int _separator = 2;

    public void SpawnCube(GameObject cube)
    {
        _cube = cube.GetComponent<Cube>();
        _failChance = Random.Range(_lowChance, _highChance);

        if (_failChance < _spawnChance)
        {
            _spawnChance /= _separator;
            _cubesCount = Random.Range(_lowCount, _highCount + 1);

            for (int i = 0; i < _cubesCount; i++)
            {
                Cube newCube = Instantiate(_cube, _cube.transform.position, Quaternion.identity);
                newCube.InitCube(transform);
            }
        }
    }
}
