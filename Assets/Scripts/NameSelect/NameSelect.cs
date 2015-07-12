﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

public class NameSelect : MonoBehaviour
{
    private GameManager gameManager;                               // マネージャコンポ
    private GameObject canVas;                                     // ゲームオブジェクト"Canvas"
    private List<string> autoNameMale = new List<string>();        // オート（英男性名）
    private List<string> autoNameFemale = new List<string>();      // オート（英女性名）
    private List<string> autoNameKanjiMa = new List<string>();     // オート（漢男性名）
    private List<string> autoNameKanjiFe = new List<string>();     // オート（漢女性名）
    private List<string> autoNameKataMa = new List<string>();      // オート（カ男性名）
    private List<string> autoNameKataFe = new List<string>();      // オート（カ女性名）
    private List<string> autoNameKanjiDqnMa = new List<string>();  // オート（漢男性DQN名）
    private List<string> autoNameKanjiDqnFe = new List<string>();  // オート（漢女性DQN名）
    // クラス名表示用テキストフィールドリスト
    public List<Text> ClassNameList = new List<Text>();
    // ユニット名表示用テキストフィールドリスト
    public List<Text> UnitNameList = new List<Text>();

    // ----------------------------------------
    // Startメソッド
    // ----------------------------------------
    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // ゲームオブジェクト"Canvas"取得
        canVas = GameObject.FindWithTag("Canvas");

        // 全ユニット数分のクラス名表示用テキストコンポを取得し、リストに格納
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName0").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName1").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName2").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName3").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName4").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName5").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName6").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName7").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName8").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName9").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName10").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName11").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName12").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName13").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName14").GetComponent<Text>());
        ClassNameList.Add(GameObject.FindWithTag("Abl_ClassName15").GetComponent<Text>());

        // 全ユニット数分のユニット名表示用テキストコンポを取得し、リストに格納
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName0").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName1").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName2").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName3").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName4").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName5").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName6").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName7").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName8").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName9").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName10").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName11").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName12").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName13").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName14").GetComponent<Text>());
        UnitNameList.Add(GameObject.FindWithTag("Nam_UnitName15").GetComponent<Text>());

        // クラス名表示フィールドを初期化
        foreach (Text field in ClassNameList)
        {
            field.text = "？？？";
        }

        // ユニット名表示フィールドを初期化
        foreach (Text field in UnitNameList)
        {
            field.text = "GuestUnit";
        }

        // クラス名表示フィールド設定メソッドをコール
        ClassNameSet();

        // キャラクター画像表示フィールド設定メソッドをコール
        UnitSpriteSet();
    }

    // ------------------------
    // クラス名表示フィールド設定メソッド
    // ユニット名セレクトシーンにおいてクラス名を表示する
    // ------------------------
    void ClassNameSet()
    {
        // リスト内を最大ユニット数分ループ
        for (int i = 0; i < gameManager.unitStateList.Count; i++)
        {
            // クラスIDを読み出し
            switch (gameManager.unitStateList[i].classType)
            {
                // ソルジャーの場合
                case Defines.SOLDLER:
                    // クラス名テキストを設定
                    ClassNameList[i].text = "ソルジャー";
                    break;

                // ウィザードの場合
                case Defines.WIZARD:
                    // クラス名テキストを設定
                    ClassNameList[i].text = "ウィザード";
                    break;

                // ユニット空きの場合
                default:
                    // クラス名テキストを設定
                    ClassNameList[i].text = "？？？";
                    break;
            }
        }
    }


    // ------------------------
    // キャラクター画像表示フィールド設定メソッド
    // キャラクターの画像を表示する
    // ------------------------
    void UnitSpriteSet()
    {
        GameObject sprite;                              // スプライトprefab用フィールド1
        GameObject prefab;                              // スプライトprefab用フィールド2
        Vector3 vec = new Vector3(-368f, 183f, 0);      // スプライト表示位置
        int vecCor = 0;                                 // スプライト表示位置補正用フィールド

        // リスト内を最大ユニット数分ループ
        for (int i = 0; i < gameManager.unitStateList.Count; i++)
        {
            // 2段目(9人目以降)の場合
            if (8 == i)
            {
                // Y値の変更およびX値補正率を初期化
                vec.y = 20.3f;
                vecCor = 0;
            }

            // クラスIDを読み出し
            switch (gameManager.unitStateList[i].classType)
            {
                // ソルジャーの場合
                case Defines.SOLDLER:
                    // ソルジャーのスプライトを設定
                    sprite = Resources.Load("UnitSprite_NameSelect/Char_1") as GameObject;
                    // 位置を設定
                    vec.x = -368 + vecCor;
                    vec.z = 0;
                    // prefabを表示
                    prefab = Instantiate(sprite, vec, Quaternion.identity) as GameObject;
                    prefab.transform.SetParent(canVas.transform, false);
                    vecCor += 100;
                    break;

                // ウィザードの場合
                case Defines.WIZARD:
                    // ウィザードのスプライトを設定
                    sprite = Resources.Load("UnitSprite_NameSelect/Char_2") as GameObject;
                    // 位置を設定
                    vec.x = -368 + vecCor;
                    vec.z = 0;
                    // prefabを表示
                    prefab = Instantiate(sprite, vec, Quaternion.identity) as GameObject;
                    prefab.transform.SetParent(canVas.transform, false);
                    vecCor += 100;
                    break;

                // ユニット未設定の場合
                default:
                    break;
            }
        }
    }
}