using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;       // コレクションクラスの定義に必要
using System.Linq;

// ================================================================================
// オブジェクト発光クラス
// 
// ================================================================================
[RequireComponent(typeof(Renderer))]    // 属性付与（自動でRendererコンポを追加）
public class MaterialFlash : MonoBehaviour
{
    private Renderer _renderer;             // レンダラーコンポ
    private Material originalMaterial;      // シェーダー変更前のマテリアル

    // ----------------------------------------
    // Startメソッド
    // ----------------------------------------
    void Start()
    {
        // レンダラーコンポ取得
        _renderer = GetComponent<Renderer>();

        // 変更前のマテリアルのコピーを保存
        originalMaterial = new Material(_renderer.material);

        // キーワードの有効化
        _renderer.material.EnableKeyword("_EMISSION");

    }

    // -----------------------------------
    // カーソルエントリーメソッド
    // -----------------------------------
    public void OnPointerEnter(PointerEventData eventData)
    {
        // 発光カラーを赤色に設定
        _renderer.material.SetColor("_EmissionColor", new Color(1, 0, 0));
    }

    // -----------------------------------
    // カーソルエスケープメソッド
    // -----------------------------------
    public void OnPointerExit(PointerEventData eventData)
    {
        // 発光カラーを元に戻す
        _renderer.material = originalMaterial;
    }
}