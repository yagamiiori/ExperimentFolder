﻿
////////////////////////////////////////////////////////////////////////////////////////
// 定数定義クラス
////////////////////////////////////////////////////////////////////////////////////////
public static class Defines
{
    // ユニットID（シーン無所属）
    public const int ID_1 = 1;     // ID 1
    public const int ID_2 = 2;     // ID 2
    public const int ID_3 = 3;     // ID 3
    public const int ID_4 = 4;     // ID 4
    public const int ID_5 = 5;     // ID 5
    public const int ID_6 = 6;     // ID 6
    public const int ID_7 = 7;     // ID 7
    public const int ID_8 = 8;     // ID 8
    public const int ID_9 = 9;     // ID 9
    public const int ID_10 = 10;   // ID 10
    public const int ID_11 = 11;   // ID 11
    public const int ID_12 = 12;   // ID 12
    public const int ID_13 = 13;   // ID 13
    public const int ID_14 = 14;   // ID 14
    public const int ID_15 = 15;   // ID 15
    public const int ID_16 = 16;   // ID 16

    // 全シーン共通
    public const int NON_VALUE = 0;     // 設定なし
    public const int SOLDLER   = 1;     // ソルジャー
    public const int WIZARD    = 2;     // ウィザード
    public const int KNIGHT    = 3;     // ナイト
    public const int ARCHER    = 4;     // アーチャー
    public const int DRAGOON   = 5;     // ドラグーン
    public const int RICH      = 6;     // リッチ
    public const int CLERIC    = 7;     // クレリック
    public const int FAERY     = 8;     // フェアリー
    public const int WITCH     = 9;     // ウィッチ
    public const int ANGEL     = 10;    // エンジェルナイト
    public const int LORD      = 11;    // ロード（プロモーション）
    public const int NECKRO    = 12;    // ネクロマンサー（プロモーション）
    public const int PALADIN   = 13;    // パラディン（プロモーション）
    public const int EMPEROR   = 14;    // 雷帝（プロモーション）
    public const int WARRIOR   = 15;    // ウォリアー（プロモーション）
    public const int DELEMENT  = 16;    // ダークエレメント（プロモーション）
    public const int PRINCESS  = 17;    // プリンセス（プロモーション）
    public const int BANGY     = 18;    // バンジー（プロモーション）
    public const int ARCWITCH  = 19;    // アークウィッチ（プロモーション）
    public const int FALLDOWN  = 20;    // 堕天使（プロモーション）

    // ユニット数（オプションセレクトシーン）
    public const int OPT_UNITS_5   = 5;     // ユニット数5
    public const int OPT_UNITS_8   = 8;     // ユニット数8
    public const int OPT_UNITS_10  = 10;    // ユニット数10
    public const int OPT_UNITS_14  = 14;    // ユニット数14
    public const int OPT_UNITS_16  = 16;    // ユニット数16
    public const int OPT_UNITS_MAX = 16;    // 最大ユニット数（16固定）

    // 持ち時間（オプションセレクトシーン）
    public const int OPT_HAVETIME_10 = 10;   // 10秒
    public const int OPT_HAVETIME_20 = 20;   // 20秒
    public const int OPT_HAVETIME_30 = 30;   // 30秒
    public const int OPT_HAVETIME_40 = 40;   // 40秒
    public const int OPT_HAVETIME_50 = 50;   // 50秒
    public const int OPT_HAVETIME_60 = 60;   // 60秒

    // 性別（ユニットセレクトシーン）
    public const int UNT_MALE    = 1;        // 男性
    public const int UNT_FEMALE  = 2;        // 女性
    public const int UNT_UNKNOWN = 3;        // 未定

    // 設定なし（アビリティセレクトシーン限定）
    public const int ABL_NON_VALUE = 100;    // 設定なし

    // 属性（バトルフィールドシーン）
    public const int BTL_FIRE     = 1;       // 炎
    public const int BTL_WIND     = 2;       // 風
    public const int BTL_EARTH    = 3;       // 土
    public const int BTL_WATER    = 4;       // 水
    public const int BTL_DIVINE   = 5;       // 神聖
    public const int BTL_DARKNESS = 6;       // 暗黒

    // アビリティ（アビリティセレクトシーン）
    public const int ABL_NO_ABILITY = 0;   // アビリティなし
    public const int ABL_ON_ABILITY = 1;   // アビリティあり

    // アビリティID（アビリティセレクトシーン）
    public const int ABL_POWERUP    = 1;   // 攻撃力Up
    public const int ABL_DIFFENCEUP = 2;   // 防御力Up
    public const int ABL_MOVEPLUS   = 3;   // ムーブプラス
    public const int ABL_HCOUNTER   = 4;   // 見切り青眼
    public const int ABL_TEREPORT   = 5;   // ダテレポ

    // タイプ（バトルフィールドシーン）
    public const int BTL_KEIHO = 1;     // 軽歩
    public const int BTL_DONPO = 2;     // 鈍歩
    public const int BTL_HIKOU = 3;     // 飛行
    public const int BTL_WORP  = 4;     // ワープ

    // 武器タイプ（バトルフィールドシーン）※未使用
    public const int BTL_SWORD = 1;     // 剣
    public const int BTL_SPIRE = 2;     // 槍
    public const int BTL_ALLOW = 3;     // 弓
    public const int BTL_STAFF = 4;     // 杖
    public const int BTL_MEISE = 5;     // メイス
    public const int BTL_SUDE  = 6;     // 素手

    // プロモーション判定（バトルフィールドシーン）
    public const int BTL_PROMO_OFF = 0;     // プロモーション未実施
    public const int BTL_PROMO_ON = 1;     // プロモーション実施済み

    // クラス毎の基本ダメージ値（バトルフィールドシーン）
    public const int BTL_DMG_SOL = 300;     // ソルジャー
    public const int BTL_DMG_WIZ = 100;     // ウィザード
    public const int BTL_DMG_KNT = 300;     // ナイト
    public const int BTL_DMG_ARC = 230;     // アーチャー
    public const int BTL_DMG_DRG = 200;     // ドラグーン
    public const int BTL_DMG_RIC = 100;     // リッチ
    public const int BTL_DMG_CLR = 50;      // クレリック
    public const int BTL_DMG_FAE = 160;     // フェアリー
    public const int BTL_DMG_WIT = 150;     // ウィッチ
    public const int BTL_DMG_ANG = 250;     // エンジェルナイト

    // パネルタイプ（バトルフィールドシーン）
    public const int BTL_PANEL_KUSA  = 1;     // 草
    public const int BTL_PANEL_KONK  = 2;     // コンクリート
    public const int BTL_PANEL_TUCHI = 3;     // 土
    public const int BTL_PANEL_KI    = 4;     // 木
    public const int BTL_PANEL_MIZU  = 5;     // 水
    public const int BTL_PANEL_ISI   = 6;     // 石
    public const int BTL_PANEL_DAIRI = 7;     // 大理石
    public const int BTL_PANEL_NUNO  = 8;     // 布
    public const int BTL_PANEL_YUKI  = 9;     // 雪


}

