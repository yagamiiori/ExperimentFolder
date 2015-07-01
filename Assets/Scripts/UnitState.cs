using UnityEngine;
using System.Collections;

public class UnitState : MonoBehaviour
{
    public int unitID = Defines.NON_VALUE;           // ユニットID
    public int classType = Defines.NON_VALUE;        // クラスタイプ
    public int abilityType = Defines.NON_VALUE;      // アビリティタイプ
    public int weaponType = Defines.NON_VALUE;       // 武器タイプ
    public int attribute = Defines.NON_VALUE;        // 属性
    public int sex = Defines.NON_VALUE;              // 性別
    public int color = Defines.NON_VALUE;            // カラーパレット（※とりあえず未使用）
    public int unitName = Defines.NON_VALUE;         // ユニット名
    public int hpValue = Defines.NON_VALUE;          // HP
    public int workType = Defines.NON_VALUE;         // 歩行タイプ
    public int expValue = Defines.NON_VALUE;         // 経験値
    public int wtValue = Defines.NON_VALUE;          // WT
    public int brave = Defines.NON_VALUE;            // Brave
    public int fath = Defines.NON_VALUE;             // Fath
    public int PysicsDef = Defines.NON_VALUE;        // 物理防御力
    public int MagicDef = Defines.NON_VALUE;         // 魔法防御力
    public bool promJud = false;                     // プロモーション可否判定フラグ

    // ----------------------------------------
    // Awakeメソッド
    // ----------------------------------------
    void Awake()
    {
        // 永続オブジェクトに設定
        DontDestroyOnLoad(this);
    }

}
