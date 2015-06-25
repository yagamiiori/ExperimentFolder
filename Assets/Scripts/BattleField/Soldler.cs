using UnityEngine;
using System.Collections;

// ==========================================================================================
// メソッド名：ソルジャークラス on Battle Field
// 
// 
// 
// 
// ==========================================================================================
public class Soldler :
    MonoBehaviour,
    IBattleField                        // バトルIF
{
    private GameManager gameManager;    // マネージャコンポ

    public int id;                      // ユニットID
    public int classID;                 // クラスID
    public int abilityID;               // アビリティID
    public int atribute;                // 属性ID
    public int sex;                     // 性別ID
    public string[] name;               // ユニット名
    public int promotionJud;            // プロモーション可否判定フラグ
    public int hp;                      // HP
    public int attackDamage;            // 基本攻撃ダメージ
    public int type;                    // タイプ（軽歩/鈍歩/飛行）
    public int weapon;                  // 武器（未使用フィールド）
    public int anotherSkill;            // 固有スキル（未使用の予定？）
    public int exp;                     // 経験値
    public float wt;                    // WT
    public float brave;                 // Brave - 物理回避率
    public float fath;                  // Fath - 魔法回避率
    public float seikouRitsu;           // 攻撃成功率
    public float correct_W;             // ユニット固有ダメージ補正率 - 武器
    public float correct_M;             // ユニット固有ダメージ補正率 - 魔法

//    public int myPanelType;                // 自分が立っているパネルのタイプ
//    public int targetPanelType;            // 敵が立っているパネルのタイプ

    // ----------------------------------------
    // Startメソッド
    // ----------------------------------------
    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // パラメータ設定メソッドをコール
        SettingParams();
	}

    // ----------------------------------------
    // Updateメソッド
    // ----------------------------------------
    void Update()
    {
	
	}

    // -----------------------------
    // ユニットパラメータ設定メソッド
    // 機能：各ユニットの固有パラメータを設定する
    // -----------------------------
    public void SettingParams()
    {
        id = Defines.ID_1;                        // ユニットID
        classID = Defines.SOLDLER;                // クラスID
        abilityID = 0;                            // アビリティID
        atribute = Random.Range(1,5);             // 属性ID
        sex = Defines.UNT_MALE;                   // 性別ID
        promotionJud = Defines.BTL_PROMO_OFF;     // プロモーション可否判定フラグ
        hp = 500+Random.Range(0,201);             // HP
        attackDamage = Defines.BTL_DMG_SOL;       // 基本攻撃ダメージ
        type = Defines.BTL_KEIHO;                 // タイプ（軽歩/鈍歩/飛行）
        wt = 50.0f;                               // WT
        brave = 50.0f + (Random.Range(0f,31f));   // Brave - 物理回避率
        fath = 20.0F + (Random.Range(0f, 31f));   // Fath - 魔法回避率
        correct_W = 0f;                           // ユニット固有ダメージ補正率 - 武器
        correct_M = 0f;                           // ユニット固有ダメージ補正率 - 魔法
    }

    // -----------------------------
    // ダメージメソッド
    // 機能：攻撃された場合、相手から呼び出される
    // 　　　ダメージを受けた時の食らいアニメを表示する
    // 　　　なお、ダメージ処理自体は攻撃側が行う
    // -----------------------------
    public void ApplyDamage()
    {
    }

    // -----------------------------
    // 通常攻撃メソッド
    // 機能：たたかうコマンドによる通常攻撃を行う
    // 　　　与えるダメージを算出した後、相手ユニットの
    // 　　　ApplyDamageメソッドをコールする
    // -----------------------------
    public void NormalAttack()
    {
        // クリティカル判定（クリティカル発生率1/10）
        int criticalDamage = 0;
        int critical = Random.Range(1, 11);

        // クリティカル成立時はダメージに+150
        if (3 == critical) criticalDamage = 150;

        // 最終ダメージ値決定
        // 基本ダメージ + クリティカルダメージ
        attackDamage = attackDamage + criticalDamage;
    }

}
