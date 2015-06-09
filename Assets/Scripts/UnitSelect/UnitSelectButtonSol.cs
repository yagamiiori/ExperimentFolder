using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UnitSelectButtonSol : 
    MonoBehaviour,
    IUnitSelect,                                    //  ユニットセレクトIF
    IPointerEnterHandler,
    IPointerExitHandler
{

    private GameManager gameManager;        // マネージャコンポ
    public int mouseOverJug = 0;            // マウスオーバー判定フラグ
    public AudioSource audioCompo;          // オーディオコンポ
    public AudioClip clickSE;               // クリックSE

    // ----------------------------------------
    // Startメソッド
    // ----------------------------------------
    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // オーディオコンポを取得
        audioCompo = gameObject.GetComponent<AudioSource>();

        // クリックSEを設定
        clickSE = (AudioClip)Resources.Load("Sounds/SE/UnitSelect_CountUp");
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
                }
            }

            // コルーチンを抜ける
            yield return null;
        }
    }
}
