using UnityEngine;

[CreateAssetMenu(fileName = "StageConfig", menuName = "Stage/StageConfig")]
public class StageConfig : ScriptableObject
{
    public StageType biomeType;
    public GameObject stagePrefab;
    public float chunkLength = 20f;
}
