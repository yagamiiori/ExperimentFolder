using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

public class UnitSelectButtonSol : 
    MonoBehaviour,
    IUnitSelect,                            //  ユニットセレクトIF
    IPointerEnterHandler,
    IPointerExitHandler
{
    private GameManager gameManager;        // マネージャコンポ
    public int mouseOverJug = 0;            // マウスオーバー判定フラグ
    public AudioSource audioCompo;          // オーディオコンポ
    public AudioClip clickSE;               // クリックSE
    public Text counterUnitValue;           // ユニット数表示Textコンポ

    // ----------------------------------------
    // Startメソッド
    // ----------------------------------------
    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // オーディオコンポを取得
        audioCompo = gameObject.GetComponent<AudioSource>();

        // ユニット数表示Textコンポ取得
        counterUnitValue = GameObject.FindWithTag("Unit_CounterSold").GetComponent<Text>();

        // クリックSEを設定
        clickSE = (AudioClip)Resources.Load("Sounds/SE/UnitSelect_Decided");
        audioCompo.clip = clickSE;
    }

    // -----------------------------------
    // カーソルエントリーメソッド
    // -----------------------------------
    public void OnPointerEnter(PointerEventData eventData)
    {
        // マウスオーバー判定フラグをON
        mouseOverJug = 1;

        // マウスクリック用イベントハンドラをコール
        StartCoroutine("MouseClickHandler");
    }

    // -----------------------------------
    // カーソルエスケープメソッド
    // -----------------------------------
    public void OnPointerExit(PointerEventData eventData)
    {
        // マウスオーバー判定フラグをOFF
        mouseOverJug = 0;

        // マウスクリック用イベントハンドラを停止
        StopCoroutine("MouseClickHandler");
    }

    // -----------------------------------
    // マウスクリック判定メソッド
    // -----------------------------------
    public IEnumerator MouseClickHandler()
    {
        // 永続ループ（ただし、マウスオーバーを抜けたらreturnする）
        while (1 == mouseOverJug)
        {
            // マウス左クリックされた場合
            if (Input.GetMouseButtonDown(0))
            {
                // 現選択ユニット数がオプションで決定したユニット数以下の場合
                if (gameManager.opt_unitNum > gameManager.unt_NowAllUnits)
                {
                    // クリックSEを鳴らす
                    audioCompo.Play();

                    // ソルジャー数をインクリメント
                    gameManager.unt_Sodler += 1;

                    // 現在選択されている選択参加ユニットの総数をインクリメント
                    gameManager.unt_NowAllUnits += 1;

                    // ユニット数表示Textコンポに現ユニット数を表示
                    counterUnitValue.text = gameManager.unt_Sodler.ToString();
                }
            }
            // マウス右クリックされた場合
            else if (Input.GetMouseButtonDown(1))
            {
                // ソルジャーが1以上選択されている場合
                if (1 <= gameManager.unt_Sodler)
                {
                    // クリックSEを鳴らす
                    audioCompo.Play();

                    // ソルジャー数をデクリメント
                    gameManager.unt_Sodler -= 1;

                    // 現在選択されている選択参加ユニットの総数をデクリメント
                    gameManager.unt_NowAllUnits -= 1;

                    // ユニット数表示Textコンポに現ユニット数を表示
                    counterUnitValue.text = gameManager.unt_Sodler.ToString();
                }
            }

            // コルーチンを抜ける
            yield return null;
        }
    }
}
