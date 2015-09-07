using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;   // コレクションクラスの定義に必要
using System.Linq;

////////////////////////////////////////////////////////////////////////////////////////
//　関数名：カメラパン機能実施クラス
//　機能：指定したオブジェクトに対してカメラをパンする
//　継承：MonoBehaviour
//　種別：通常クラス
//　アタッチ先：カメラオブジェクト
//　保持メソッド：Start()、Update()
//
//　詳細：
//　　　　
//
//  呼び出し例：
//
//　履歴：
//
////////////////////////////////////////////////////////////////////////////////////////
public class CameraPan : MonoBehaviour
{
    /// <summary>パンする対象のゲームオブジェクトの位置</summary>
	public Vector3 targetPosition = Vector3.zero;
    /// <summary>パンする対象のゲームオブジェクトの位置（補正済み）</summary>
	public Vector3 targetPositionCor = Vector3.zero;
    /// <summary>パンする速度の基準値</summary>
    public float panSpeed = 2.0f;
    /// <summary>補正するZ値</summary>
    public float correctVal = 60.0f;
    /// <summary>パン有無</summary>
	public bool isEnable = true;
    /// <summary>停止処理種別判定（true：手動停止　false：自動停止）</summary>
	public bool isManual = false;
	
    public void Start()
    {
		// パンするターゲットオブジェクトの位置を取得しz軸を補正する
		targetPosition = GameObject.FindWithTag("xxx").transform.position;
		targetPositionCor.x = targetPosition.x;
		targetPositionCor.y = targetPosition.y;
        targetPositionCor.z = targetPosition.z - correctVal;
    }

    public void Update()
    {
		// 自動停止の場合はカメラの位置がターゲットオブジェクトに到達したら処理を停止
		if(this.transform.position == targetPosition && !isManual) isEnable = false;
		
		if(isEnable)
		{
			// 現在のカメラの位置からターゲットオブジェクトの位置へパンニングを実施
			this.transform.position=Vector3.MoveTowards(this.transform.position, targetPositionCor, panSpeed*Time.deltaTime);
		}
    }
    
    public void CameraPanStop()
    {
		// パンを停止する
		isEnable = false;
	}
}

