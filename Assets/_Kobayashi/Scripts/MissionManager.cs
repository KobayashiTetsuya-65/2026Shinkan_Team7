using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    [Header("-----éQè∆-----")]
    [SerializeField] private MissionDataBase _missionDatas;
    [SerializeField] private GameObject _player;
    [SerializeField] private TextMeshProUGUI _warningText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _warningText.gameObject.SetActive(false);
    }

    public void StartMission(MissionType missionType)
    {
        MissionData mission = _missionDatas.GetCardData(missionType);
        GameObject obj = Instantiate(mission.Prefab,
            _player.transform.position + new Vector3(0f, 3f, mission.FowerdMeter),
            Quaternion.identity);

        //UIâÊñ ë§Ç…ââèo
        _warningText.gameObject.SetActive(true);
        _warningText.text = mission.MissionName;
    }

    public void EndMission()
    {
        _warningText.gameObject.SetActive(false);
    }
}
