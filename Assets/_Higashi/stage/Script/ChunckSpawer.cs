using System.Collections.Generic;
using UnityEngine;

public class ChunckSpawer : MonoBehaviour
{
    [Header("設定")]
    [SerializeField] private Transform _player;
    [SerializeField] private ChunkPool _chunkPool;
    // 生成するチャンクの数
    [SerializeField] private int _spawnCount = 5;
    // プレイヤーがチャンクの最遠い地点からにこの距離に近づいたら新しいチャンクを生成する
    [SerializeField] private float _spawnDistance = 50f;

    // 次にチャンクを生成するZ座標（初期値設定0f）
    private float _nextSpawnZ = 0f;
    // 生成されたチャンクとそのバイオームの情報を保持するキュー
    private Queue<(GameObject obj, StageType biome)> _activeChunks = new();
    private void Start()
    {
        // 初期チャンクの生成
        for (int i = 0; i < _spawnCount; i++)
        {
            SpawnChunk(GameManager.Instance.CurrentStageType);
        }
    }
    private void Update()
    {
        // プレイヤーが次のスポーンポイントに近づいたら新しいチャンクを生成
        while (_player.position.z + _spawnDistance > _nextSpawnZ)
        {
            SpawnChunk(GameManager.Instance.CurrentStageType);
        }

        //後ろのチャンクを回収
        while (_activeChunks.Count > 0)
        {
            var (obj, biome) = _activeChunks.Peek();
            if (obj.transform.position.z + _chunkPool.GetChunkLength(biome) < _player.position.z - _spawnDistance)
            {
                _chunkPool.ReleaseChunk(biome, obj);
                _activeChunks.Dequeue();
            }
            else break;
        }
    }
    /// <summary>
    /// 指定したバイオームを生成
    /// </summary>
    /// <param name="biome">生成するバイオームの種類</param>
    private void SpawnChunk(StageType biome)
    {
        var chunk = _chunkPool.GetChunk(biome);
        if (chunk == null) return;
        chunk.transform.position = new Vector3(0, 0, _nextSpawnZ);
        var chankLength = _chunkPool.GetChunkLength(biome);
        _nextSpawnZ += chankLength;
        _activeChunks.Enqueue((chunk, biome));
    }
}
