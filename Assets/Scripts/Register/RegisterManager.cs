using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;
using System;

public class RegisterManager :
    MonoBehaviour,
    IMessageWriteToMW,                                // メッセージウィンドウ書き込みIF
    IOnMessageWindowOK                                // OKボタンクリックIF（メッセージウィンドウ専用）
{
    private GameManager gameManager;                  // マネージャコンポ
    private GameObject messageWindow;                 // メッセージウィンドウCanvas
    private InputField messageText;                   // メッセージウィンドウのTextコンポ
    public InputField nameField;                      // 名前のインプットフィールド
    public InputField guidField;                      // GUIDインプットフィールド
    public GameObject guidFieldGO;                    // GUID表示用オブジェクト
    private string nextScene = "Login";               // 遷移先シーン名
    private string loginName = "Login";               // 遷移先シーン名
    private bool IsWindow = false;                    // メッセージウィンドウ表示有無判定フラグ

    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // 名前入力フィールド取得
        nameField = GameObject.FindWithTag("Login_InputField_Name").GetComponent<InputField>();

        // メッセージウィンドウのCanvasとTextコンポを取得し、非アクティブ化
        messageWindow = GameObject.FindWithTag("Canvas_MW");
        messageText = GameObject.FindWithTag("TextField_MW").GetComponent<InputField>();
        messageWindow.SetActive(false);

    }

    // -------------------------------------------------------------------
    // OKボタンがクリックした時にOKボタンのOnClickからコールされ、
    // メッセージウィンドウを開きGUIDを表示する
    // -------------------------------------------------------------------
    public void OnClickOK()
    {
        // メッセージウィンドウ未表示の場合
        if (!IsWindow)
        {
            // インプットフィールドにNameLess以外の文字が入力されている場合
            if ("" != nameField.text && "NameLess" != nameField.text)
            {
                // GUIDを生成
                Guid guidValue = Guid.NewGuid();

                // ユーザ名とGUIDをGMのフィールドに格納
                gameManager.userName = nameField.text;
                gameManager.userGuid = guidValue.ToString();

                // 生成したGUIDをメッセージウィンドウで表示
                MessageWriteToWindow("Complete!!\n" + "UserID was generated, copy here.：\n" + gameManager.userGuid);
            }
        }
    }

    // -------------------------------------------------------------------
    // メッセージウィンドウのOKボタンからコールされ、
    // メッセージウィンドウを非アクティブ化する。
    // -------------------------------------------------------------------
    public void OnMessageWindowOK()
    {
        // シーン遷移メソッドコール
        NextScene();
    }

    // =====================================
    // メッセージウィンドウ書き込みIF
    // メッセージウィンドウのTextコンポに文字を書き込む
    // =====================================
    public void MessageWriteToWindow(string a)
    {
        // メッセージウィンドウをアクティブ化
        messageWindow.SetActive(true);

        // メッセージウィンドウ表示有無判定フラグを変更
        IsWindow = true;

        // メッセージ表示
        messageText.text = a;
    }

    // -------------------------------------------------------------------
    // Return Loginボタンからコールされ
    // ログインシーンへ遷移する。
    // -------------------------------------------------------------------
    public void OnClickLogin()
    {
        // メッセージウィンドウ未表示の場合
        if (!IsWindow)
        {
            // シーン遷移実施
            Application.LoadLevel(loginName);
        }
    }

    // -------------------------------
    // シーン遷移メソッド
    // -------------------------------
    public void NextScene()
    {
        // Scene遷移
        // ﾌｪｰﾄﾞｱｳﾄ時間、ﾌｪｰﾄﾞ中待機時間、ﾌｪｰﾄﾞｲﾝ時間、ｶﾗｰ、遷移先Pos情報(Vector3)、遷移先ｼｰﾝ
        gameManager.GetComponent<FadeToScene>().FadeOut(0.1f, 0.4f, 0.1f, Color.black, nextScene);
    }


}
