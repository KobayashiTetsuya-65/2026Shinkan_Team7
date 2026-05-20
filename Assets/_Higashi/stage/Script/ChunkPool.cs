using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
/// <summary>
/// 地面のチャンクのプールを管理するクラス
/// </summary>
public class ChunkPool : MonoBehaviour
{
    [SerializeField] private StageConfig[] _stageConfigs;

    private Dictionary<StageType, ObjectPool<GameObject>> _chunkPool = new();

    private void Awake()
    {
        foreach (var config in _stageConfigs)
        {
            var loalConfig = config; 
            var pool = new ObjectPool<GameObject>(
                createFunc: () => Instantiate(loalConfig.stagePrefab),
                actionOnGet: obj => obj.SetActive(true),
                actionOnRelease: obj => obj.SetActive(false),
                actionOnDestroy: obj => Destroy(obj),
                defaultCapacity: 10
            );
            _chunkPool[config.biomeType] = pool;
        }
    }
    public GameObject GetChunk(StageType biome)
    {
        if (_chunkPool.TryGetValue(biome, out var pool))
        {
            return pool.Get();
        }
        Debug.LogWarning($"Biome type {biome} のチャンクプールが見つかりませんでした。");
        return null;
    }
    /// <summary>通常チャンクを取得</summary>
    public void ReleaseChunk(StageType biome, GameObject chunk)
    {
        if (_chunkPool.TryGetValue(biome, out var pool))
        {
            pool.Release(chunk);
        }
        else
        {
            Debug.LogWarning($"Biome type {biome} のチャンクプールが見つかりませんでした。");
            Destroy(chunk);
        }
    }
    /// <summary>チャンクの長さを取得</summary>
    public float GetChunkLength(StageType biome)
    {
        foreach (var config in _stageConfigs)
            if (config.biomeType == biome) return config.chunkLength;
        return 0f;
    }
}
