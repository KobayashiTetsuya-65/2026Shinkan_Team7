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
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _correctNeedle;

    private FireMeter _fireMeter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _warningText.gameObject.SetActive(false);
        _panel.SetActive(false);
        _correctNeedle.SetActive(false);
        _fireMeter = GetComponent<FireMeter>();
    }

    public void StartMission(MissionType missionType)
    {
        MissionData mission = _missionDatas.GetCardData(missionType);
        GameObject obj = Instantiate(mission.Prefab,
            _player.transform.position + new Vector3(0f, 3f, mission.FowerdMeter),
            Quaternion.identity);

        //UIâÊñ ë§Ç…ââèo
        _warningText.gameObject.SetActive(true);
        _panel.SetActive(true);
        _warningText.text = mission.MissionName;
        _correctNeedle.SetActive(true);
        _fireMeter.ChangeMeter(mission.Prefab.GetComponent<MissionObjectBase>().CorrentValue);
    }

    public void EndMission()
    {
        _warningText.gameObject.SetActive(false);
        _panel.SetActive(false);
        _correctNeedle.SetActive(false);
    }
}
