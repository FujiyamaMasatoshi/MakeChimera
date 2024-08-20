using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{ 
    private Vector3 offset;  // マウスの位置とオブジェクトの位置との差分
    private bool isDrag = false;  // ドラッグ可能か
    private string animalTag = "Animal";
    
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
    }

    // マウスが動物の上にあるかどうか
    private bool IsMouseOnAnimal()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.tag == animalTag)
        {
            return true;
        }

        return false;
    }

    public bool GetIsDrag()
    {
        return isDrag;
    }
}
