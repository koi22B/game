using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextWriter : MonoBehaviour
{
    public UIText uitext;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Cotest");
    }
    
    // クリック待ちのコルーチン
    IEnumerator Skip()
    {
        while (uitext.playing) yield return 0;//一フレーム分待つ。yield return null とは何かが違うらしい
        while (!uitext.IsClicked()) yield return 0;
    }
    
    // 文章を表示させるコルーチン
    IEnumerator Cotest()
    {
        uitext.DrawText("ナレーションだったらこのまま書けばOK");
        yield return StartCoroutine("Skip");

        uitext.DrawText("名前","人が話すのならこんな感じ");
        yield return StartCoroutine("Skip");

        uitext.DrawText("キーンコーンカーンコーン");
        yield return StartCoroutine("Skip");

        uitext.DrawText("愚民どもが授業を受けている中、優々と昼寝をしていたというのに、この耳障りなチャイムがいつも俺の眠りを妨げる。");
        yield return StartCoroutine("Skip");
        
        uitext.DrawText("俺は夜型なんだ。普通の学生のように昼間から真面目に授業など受けていられるか。");
        yield return StartCoroutine("Skip");

        uitext.DrawText("最悪の目覚めでぼやけた視界を正すように目をこする。");
        yield return StartCoroutine("Skip");
        
        uitext.DrawText("あい", "おはよー！ゆうくん！またお昼寝してたの？");
        yield return StartCoroutine("Skip");
        
        uitext.DrawText("またこいつか…。ここに来てからというもの、昼休みになると毎日現れる。");
        yield return StartCoroutine("Skip");
        
        uitext.DrawText("あい", "今日もゆうくんのためにお弁当作って来たんだよ！はい、どうぞ！");
        yield return StartCoroutine("Skip");
        
        
    }
}