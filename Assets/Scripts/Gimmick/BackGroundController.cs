using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// https://tech.pjin.jp/blog/2017/04/18/unity_background_scroll/
/// 【背景のコントロール用クラス】
///     背景は3枚、カメラから見切れたら回り込む
/// </summary>

public class BackGroundController : MonoBehaviour
{

    // 背景の枚数
    public int spriteCount = 3;
    // 背景が回り込み
    float rightOffset = 1.5f;
    float leftOffset = -1.5f;

    Transform bgTfm;
    SpriteRenderer mySpriteRndr;
    float width;

    public Camera camera;

    public float delay;

    void Start()
    {
        bgTfm = transform;
        mySpriteRndr = GetComponent<SpriteRenderer>();
        width = mySpriteRndr.bounds.size.x;
        
    }


    void Update()
    {
        Debug.Log(width);
        // 座標変換
        //Vector3 myViewport = Camera.main.WorldToViewportPoint(bgTfm.position);
        Vector3 myViewport = camera.WorldToViewportPoint(bgTfm.position);
        // 背景の回り込み(カメラがX軸プラス方向に移動時)
        if (myViewport.x < leftOffset)
        {
            bgTfm.position += Vector3.right * ((width-delay) * spriteCount);
        }
        // 背景の回り込み(カメラがX軸マイナス方向に移動時)
        else if (myViewport.x > rightOffset)
        {
            // bgTfm.position -= Vector3.right * (width * spriteCount);
        }
    }
}
