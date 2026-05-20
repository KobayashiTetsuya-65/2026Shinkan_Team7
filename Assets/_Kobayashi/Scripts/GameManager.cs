using UnityEngine;
public enum StageType
{
    Normal,
    Desert,
    Wetland,
    Wasteland
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public StageType CurrentStageType { get; private set; }
    public bool IsDead { get; private set; }

    [SerializeField] public FuelObjectPool FuelObjectPool;
    [SerializeField] public Canvas Canvas;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentStageType = StageType.Normal;
        IsDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsDead)
        {

        }
        else
        {

        }
    }

    public void StageChange(StageType nextStage)
    {
        CurrentStageType = nextStage;
    }
}
