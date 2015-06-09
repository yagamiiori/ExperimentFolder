using UnityEngine;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

public class UnitSelectButtonOK : MonoBehaviour
{
    private GameManager gameManager;                    // マネージャコンポ
    private string nextScene = "AbilitySelect";         // スタートボタンプッシュ時遷移先シーン
    private int isStarted = 0;                          // スタートボタンプッシュ判定フラグ

    // ----------------------------------------
    // Startメソッド
    // ----------------------------------------
    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // -------------------------------
    // OKボタンクリック判定メソッド（ユニットセレクトシーン）
    // ユニットセレクトシーンにてOKボタンが押された場合（ユニット確定した場合）にコールされ
    // 選択したユニットをユニットリストに格納、アビリティシステム有無フラグを確認し
    // アビリティセレクトシーンまたはポジションセレクトシーンに遷移する。
    // -------------------------------
    public void OnClick()
    {
        // スタートボタン未プッシュの場合、かつオプションで選択したユニット数と選択済みユニット数が同じ場合
        if (0 == isStarted && (gameManager.unt_NowAllUnits == gameManager.opt_unitNum))
        {
            // スタートボタンプッシュ判定フラグをONにしてスタートボタンプッシュ後に
            // オプションが変更されたりスタートボタン連打を抑止する。
            isStarted = 1;

            // 確定済み全ユニットリスト生成メソッドをコール
            MyUnitListConst();

            // Scene遷移実施
            // ﾌｪｰﾄﾞｱｳﾄ時間、ﾌｪｰﾄﾞ中待機時間、ﾌｪｰﾄﾞｲﾝ時間、ｶﾗｰ、遷移先Pos情報(Vector3)、遷移先ｼｰﾝ
            GameObject.FindWithTag("GameManager").GetComponent<FadeToScene>().FadeOut(0.1f, 0.6f, 0.1f, Color.black, nextScene);
        }
    }

    // ---------------------------------
    // 確定済み全ユニットリスト生成メソッド
    // ユニットセレクトシーンで確定したユニットのリストを生成する。
    // ---------------------------------
    public void MyUnitListConst()
    {
        int listCnt = 0;    // ブランクインデックス埋め用カウンター

        // ソルジャーがいる場合
        if (0 < gameManager.unt_Sodler)
        {
            // ソルジャー数分ループ
            for (int j = 0; j < gameManager.unt_Sodler; j++)
            {
                // CA対応リストにソルジャーを追加
                gameManager.C_List.Add(Defines.SOLDLER);

                // ランクインデックス埋め用カウンターを加算
                listCnt += 1;
            }
        }

        // ウィザードがいる場合
        if (0 < gameManager.unt_Wizard)
        {
            // ウィザード数分ループ
            for (int j = 0; j < gameManager.unt_Wizard; j++)
            {
                // CA対応リストにウィザードを追加
                gameManager.C_List.Add(Defines.WIZARD);

                // ランクインデックス埋め用カウンターを加算
                listCnt += 1;
            }
        }

        // 空きKey数を設定
        int blankKeyArea = Defines.OPT_UNITS_MAX - listCnt;

        // 空いているKeyを最大ユニット数の16まで設定（クリアしておく）
        for (int i = 0; i < blankKeyArea; i++)
        {
            //valueは設定なしで埋める
            gameManager.C_List.Add(Defines.NON_VALUE);
        }
    }
}
