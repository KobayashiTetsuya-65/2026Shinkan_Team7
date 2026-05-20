using System.Collections.Generic;
using UnityEngine;
public enum SEType
{
    Whistle,
    Grab,
    Attack,
    Explosion
}
public enum BGMType
{
    Title,
    Nomal,
    Bonus,
    GameOver
}
[System.Serializable]
public class SEData
{
    public SEType type;      // SEの種類
    public AudioClip clip;   // 音データ
    public float volume = 1f;    // 音量（0.0f〜1.0f）
}
[System.Serializable]
public class BGMData
{
    public BGMType type;      // BGMの種類
    public AudioClip clip;   // 音データ
    public float volume = 1f;    // 音量（0.0f〜1.0f）
}
public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;
    // BGM用AudioSource
    private AudioSource _bgmSource;

    //インスペクターに表示する

    [SerializeField] private List<SEData> SeList = new List<SEData>();
    [SerializeField] private List<BGMData> BgmList = new List<BGMData>();

    private Dictionary<SEType, AudioClip> _seDictionary;
    private Dictionary<BGMType, AudioClip> _bgmDictionary;
    void Awake()
    {
        //一つだけ
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // 自分をInstanceにする
        Instance = this;

        // シーンをまたいでも消えないようにする
        DontDestroyOnLoad(gameObject);

        _seDictionary = new Dictionary<SEType, AudioClip>();
        _bgmDictionary = new Dictionary<BGMType, AudioClip>();

        foreach (SEData data in SeList)
        {
            _seDictionary[data.type] = data.clip;
        }


        // 自分についているAudioSourceを取得（BGM用）
        _bgmSource = GetComponent<AudioSource>();
    }
    /// <summary>
    /// BGMを再生するメソッド
    /// </summary>
    /// <param name="clip"></param>
    public void PlayBGM(AudioClip clip)
    {
        // もし同じ曲が流れていたら戻す
        if (_bgmSource.clip == clip) return;

        // 曲をセット
        _bgmSource.clip = clip;

        // ループON
        _bgmSource.loop = true;

        // 再生
        _bgmSource.Play();
    }
    /// <summary>
    /// BGMを止める
    /// </summary>
    public void StopBGM()
    {
        _bgmSource.Stop();
    }

    /// <summary>
    /// SEを再生してそのSEをけす。
    /// </summary>
    /// <param name="clip"></param>
    public void PlaySE(SEType type)
    {
        if (!_seDictionary.ContainsKey(type))
        {
            Debug.LogWarning($"{type}が登録されていません！");
            return;
        }
        AudioSource.PlayClipAtPoint(_seDictionary[type], Camera.main.transform.position);
    }
}