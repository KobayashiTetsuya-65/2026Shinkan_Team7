using System.Collections.Generic;
using UnityEngine;
using static TestEnum;

public class ChunckSpawer : MonoBehaviour
{
    [Header("設定")]
    [SerializeField] private Transform _player;
    [SerializeField] private float _chunkLength = 5f;
    [SerializeField] private ChunkPool _chunkPool;
    // 生成するチャンクの数
    [SerializeField] private int _spawnCount = 5;
    // プレイヤーがチャンクの最遠い地点からにこの距離に近づいたら新しいチャンクを生成する
    [SerializeField] private float _spawnDistance = 50f;

    // 現在のバイオームタイプ（外部から変更可能）
    public TestBiomeType CurrentBiome { get; set; } = TestBiomeType.Forest;

    private float _nextSpawnZ;
    private void Start()
    {
        // 初期チャンクの生成
        for (int i = 0; i < _spawnCount; i++)
        {
            SpawnChunk(CurrentBiome); // 最初は現在のバイオームからスタート
        }
    }
    private void Update()
    {
        // プレイヤーが次のスポーンポイントに近づいたら新しいチャンクを生成
        if (_player.position.z + _spawnDistance > _nextSpawnZ)
        {
            SpawnChunk(CurrentBiome);
        }
    }
    // 生成されたチャンクとそのバイオームの情報を保持するキュー
    private Queue<(GameObject obj, TestBiomeType biome)> _activeChunks = new();
    private void SpawnChunk(TestBiomeType biome)
    {
        var chunk = _chunkPool.GetChunk(biome);
        if (chunk == null) return;
        chunk.transform.position = new Vector3(0, 0, _nextSpawnZ);
        _nextSpawnZ += _chunkLength;
        _activeChunks.Enqueue((chunk, biome));
    }
}
