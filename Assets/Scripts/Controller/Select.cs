using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    [Header("芝の座標")] public float greenRegion;

    private Vector3 offset;  // マウスの位置とオブジェクトの位置との差分
    private Vector3 previousPosition = Vector3.zero;
    private bool isDrag = false;  // ドラッグ可能か
    private bool isSet = false;  // セット可能か
    
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
        previousPosition = transform.position;

        if (IsMouseOnAnimal())
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
        
        if (transform.position.y >= greenRegion && !isSet)
        {
            transform.position = previousPosition;
        }
    }

    // マウスが動物の上にあるかどうか
    private bool IsMouseOnAnimal()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.transform.position == transform.position)
        {
            return true;
        }

        return false;
    }

    public bool GetIsDrag()
    {
        return isDrag;
    }

    public void SetIsSet(bool newIsSet)
    {
        isSet = newIsSet;
    }
}
