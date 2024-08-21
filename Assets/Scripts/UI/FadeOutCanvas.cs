using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutCanvas : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;  // フェードアウトさせたいCanvasGroup
    [SerializeField] private float fadeDuration;

    public IEnumerator FadeOut()
    {
        // 現在の透明度（アルファ値）を取得
        float startAlpha = canvasGroup.alpha;

        // フェードアウトの開始時刻を記録
        float startTime = Time.time;

        while (Time.time < startTime + fadeDuration)
        {
            // 経過時間に基づいて透明度を計算
            float t = (Time.time - startTime) / fadeDuration;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, t);
            yield return null;
        }

        // 完全に透明に設定
        canvasGroup.alpha = 0f;
    }
}
