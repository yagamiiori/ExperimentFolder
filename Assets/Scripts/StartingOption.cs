using UnityEngine;
using System.Collections;

public class StartingOption : MonoBehaviour
{

    private GameManager gameManager;                // マネージャコンポ
    private string nextScene = "UnitSelect";        // スタートボタンプッシュ時遷移先シーン
    private int isStarted = 0;                      // スタートボタンプッシュ判定フラグ

    // ----------------------------------------
    // Startメソッド
    // ----------------------------------------
    void Start()
    {
        // マネージャコンポ取得
        gameManager = this.gameObject.GetComponent<GameManager>();
	}

    // ----------------------------------------
    // チェックボックス判定メソッド - ユニット数
    // ----------------------------------------
    public void SetUnits(int value)
    {
        // スタートボタン未プッシュの場合、ユニット数を設定
        if (0 == isStarted) gameManager.opt_unitNum = value;
    }

    // ----------------------------------------
    // チェックボックス判定メソッド - TIME
    // ----------------------------------------
    public void SetHaveTime(float value)
    {
        // スタートボタン未プッシュの場合、持ち時間を設定
        if (0 == isStarted) gameManager.opt_haveTime = value;
    }

    // ----------------------------------------
    // チェックボックス判定メソッド - Ability（廃止）
    // ----------------------------------------
    public void SetAbility(int value)
    {
        // スタートボタン未プッシュの場合、アビリティ有無判定フラグを設定
        if (0 == isStarted) gameManager.opt_abilityJud = value;
    }

    // ----------------------------------------
    // チェックボックス判定メソッド - GIFT
    // ----------------------------------------
    public void SetGift(int value)
    {
        // スタートボタン未プッシュの場合、ギフト有無判定フラグを設定
        if (0 == isStarted) gameManager.opt_giftJud = value;
    }

    // ----------------------------------------
    // チェックボックス判定メソッド - ゲーム言語
    // ----------------------------------------
    public void SetLanguage(int value)
    {
        // スタートボタン未プッシュの場合、ユニット数を設定
        if (0 == isStarted) gameManager.opt_lang = value;
    }

    // ----------------------------------------
    // ゲームスタートボタン判定メソッド
    //
    // Startボタンが押されたらユニットセレクトシーンに遷移する。
    // ----------------------------------------
    public void OnButtonStart()
    {
        // スタートボタン未プッシュの場合
        if (0 == isStarted)
        { 
            // スタートボタンプッシュ判定フラグをONにしてスタートボタンプッシュ後に
            // オプションが変更されたりスタートボタン連打を抑止する。
            isStarted = 1;

            // オプション設定完了フラグを設定
            gameManager.opt_compJud = true;

            // Scene遷移実施
            // ﾌｪｰﾄﾞｱｳﾄ時間、ﾌｪｰﾄﾞ中待機時間、ﾌｪｰﾄﾞｲﾝ時間、ｶﾗｰ、遷移先Pos情報(Vector3)、遷移先ｼｰﾝ
            GameObject.FindWithTag("GameManager").GetComponent<FadeToScene>().FadeOut(0.1f, 0.6f, 0.1f, Color.black, nextScene);
        }
   }
}
