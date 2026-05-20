using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections;

public class GetComponentCaller : MonoBehaviour
{
    /// <summary>
    /// シーン遷移
    /// </summary>
    public void Change_button()
    {
        StartCoroutine(ChangeSceneCoroutine());
    }

    private IEnumerator ChangeSceneCoroutine()
    {
        // 2秒待機
        yield return new WaitForSeconds(2f);

        // シーン遷移
       // ChangeScene.Instance.SceneLoad();
    }
}

