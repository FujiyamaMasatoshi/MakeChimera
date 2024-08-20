using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Select : MonoBehaviour
{ 
    [Header("ドラッグ有効範囲")] public float dragRange;

    private Vector3 offset;  // マウスの位置とオブジェクトの位置との差分
    private bool isDrag = false;  // ドラッグ可能か
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseDown();
        }

        if (Input.GetMouseButton(0))
        {
            MouseDrag();
        }
        else
        {
            MouseUp();
        }
    }

    // マウスを押したとき
    void MouseDown()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - mousePosition;
        float offsetSize = math.sqrt(offset.x * offset.x + offset.y * offset.y);
        if (offsetSize < dragRange)
        {
            isDrag = true;
        }
    }

    // ドラッグしているとき
    void MouseDrag()
    {
        if(isDrag)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition + offset;
        }
    }

    // マウスを離したとき
    void MouseUp()
    {
        isDrag = false;
    }
}
