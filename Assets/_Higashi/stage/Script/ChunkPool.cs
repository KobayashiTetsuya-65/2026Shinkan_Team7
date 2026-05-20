using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using static TestEnum;
public class ChunkPool : MonoBehaviour
{
    [SerializeField] private StageConfig[] _stageConfigs;

    private Dictionary<TestBiomeType, ObjectPool<GameObject>> _chunkPool = new();

    private void Awake()
    {
        foreach (var config in _stageConfigs)
        {
            var pool = new ObjectPool<GameObject>(
                createFunc: () => Instantiate(config.stagePrefab),
                actionOnGet: obj => obj.SetActive(true),
                actionOnRelease: obj => obj.SetActive(false),
                actionOnDestroy: obj => Destroy(obj),
                defaultCapacity: 10
            );
            _chunkPool[config.biomeType] = pool;
        }
    }
}
