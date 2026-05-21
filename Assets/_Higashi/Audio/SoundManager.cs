using System.Collections.Generic;
using UnityEngine;
public enum SEType
{
    Whistle,
    Grab,
    Attack,
    Explosion,
    Button,
    InFule,
}
public enum BGMType
{
    Title,
    Nomal,
    Bonus,
    Result
}
[System.Serializable]
public class SEData
{
    public SEType type;      // SEの種類
    public AudioClip clip;   // 音データ
    [SerializeField, Range(0, 1)]
    public float volume = 1f;    // 音量（0.0f〜1.0f）
}
[System.Serializable]
public class BGMData
{
    public BGMType type;      // BGMの種類
    public AudioClip clip;   // 音データ
    [SerializeField, Range(0, 1)]
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

    private Dictionary<SEType, (AudioClip clip, float volume)> _seDictionary;
    private Dictionary<BGMType, (AudioClip clip, float volume)> _bgmDictionary;
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

        _seDictionary = new Dictionary<SEType, (AudioClip clip, float volume)>();
        _bgmDictionary = new Dictionary<BGMType, (AudioClip clip, float volume)>();

        foreach (SEData data in SeList)
        {
            _seDictionary[data.type] = (data.clip, data.volume);
        }
        foreach (BGMData data in BgmList)
        {
            _bgmDictionary[data.type] = (data.clip, data.volume);
        }


        // 自分についているAudioSourceを取得（BGM用）
        _bgmSource = GetComponent<AudioSource>();
    }
    /// <summary>
    /// BGMを再生するメソッド
    /// </summary>
    /// <param name="clip"></param>
    public void PlayBGM(BGMType type)
    {
        if (!_bgmDictionary.ContainsKey(type))
        {
            Debug.LogWarning($"{type}が登録されていません！");
            return;
        }

        var (clip, volume) = _bgmDictionary[type];

        // もし同じ曲が流れていたら戻す
        if (_bgmSource.clip == clip) return;
        // 音量をセット
        _bgmSource.volume = volume;
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
        // 新しくAudioSourceを作る
        AudioSource seSource = gameObject.AddComponent<AudioSource>();

        // 辞書から再生する音をセットする
        var (clip, volume) = _seDictionary[type];

        seSource.clip = clip;
        // 音量をセット
        seSource.volume = volume;

        // ループしない
        seSource.loop = false;

        // 再生
        seSource.Play();

        // 再生が終わったら削除
        Destroy(seSource, seSource.clip.length);
    }
}