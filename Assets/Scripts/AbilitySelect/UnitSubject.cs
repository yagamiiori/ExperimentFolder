using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

// ================================================================================================
// サブジェクトとしてユニットクリック判定がONになった場合に
// 全オブサーバ(ユニットスプライト)に通知し、ユニットスプライトは透明化する
//
// ================================================================================================
public class UnitSubject :
    MonoBehaviour,
    ISubject                                                        // サブジェクトIF
{
    private List<IObserver> obServers = new List<IObserver>();      // 管理オブサーバリスト
    private GameObject abilityArea;                                 // アビリティエリア統括オブジェクト
    private GameObject unitArea;                                    // ユニットエリア統括オブジェクト
    public AudioSource audioCompo;                                  // オーディオコンポ
    public AudioClip clickSE;                                       // クリックSE

    // サブジェクトのステータス
    // ここに変更があったら各オブサーバへ変更内容を通知するNotify();
    // が起動する
    private bool _status = false;
    public bool status
    {
        get
        {
            return _status;
        }
        set
        {
            _status = value;
            Notify();
        }
    }

    // ----------------------------------------
    // Startメソッド
    // ----------------------------------------
    void Start()
    {
        // アビリティエリア統括オブジェクトを取得し、非アクティブ化
        abilityArea = GameObject.FindWithTag("Abl_AbilityArea");
        if (abilityArea) abilityArea.SetActive(false);

        // ユニットエリア統括オブジェクト取得
        unitArea = GameObject.FindWithTag("Abl_UnitArea");

        // オーディオコンポを取得
        audioCompo = this.gameObject.GetComponent<AudioSource>();

        // クリックSEを設定
        clickSE = (AudioClip)Resources.Load("Sounds/SE/UnitSelect_CountUp");
        audioCompo.clip = clickSE;
    }

    // --------------------------------------------
    // オブサーバ追加メソッド
    // サブジェクトが管理するオブサーバリストにオブサーバを追加
    // --------------------------------------------
    public void Attach(IObserver observer)
    {
        obServers.Add(observer);
    }

    // --------------------------------------------
    // オブサーバ削除メソッド
    // サブジェクトが管理するオブサーバリストからオブサーバを削除
    // --------------------------------------------
    public void Detach(IObserver observer)
    {
        obServers.Remove(observer);
    }

    // --------------------------------------------
    // オブサーバへの通知メソッド
    // statusセッター内からコールされ、オブサーバ内Notifyへ変更を通知する
    // --------------------------------------------
    public void Notify()
    {

        // ユニットが左クリックされた場合（アビリティ選択）
        if (true == this.status)
        {
            // クリックSEを鳴らす
            audioCompo.Play();

            // アビリティエリアアクティブ化 / ユニットエリア非アクティブ化
            abilityArea.SetActive(true);
            unitArea.SetActive(false);

        }
        // ユニットが右クリックされた場合（キャンセル）
        else
        {
            // クリックSEを鳴らす
            audioCompo.Play();

            // アビリティエリアアクティブ非化 / ユニットエリアアクティブ化
            abilityArea.SetActive(false);
            unitArea.SetActive(true);
        }

        // オブサーバクラス内の通知メソッドをコール
        obServers.ForEach(observer => observer.Notify(this.status));
    }
}
