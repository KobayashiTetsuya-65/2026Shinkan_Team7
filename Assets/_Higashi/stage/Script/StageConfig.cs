using UnityEngine;

[CreateAssetMenu(fileName = "StageConfig", menuName = "Stage/StageConfig")]
public class StageConfig : ScriptableObject
{
    public TestEnum.TestBiomeType biomeType;
    public GameObject stagePrefab;
    public float chunkLength = 20f;
}
