using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Select : MonoBehaviour
{
    [Header("�h���b�O�L���͈�")] public float dragRange;

    private Vector3 offset;  //�}�E�X�̈ʒu�ƃI�u�W�F�N�g�̈ʒu�Ƃ̍���
    private bool isDrag = false;  //�h���b�O�\��

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

    //�}�E�X���������Ƃ�
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

    //�h���b�O���Ă���Ƃ�
    void MouseDrag()
    {
        if (isDrag)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition + offset;
        }
    }

    //�}�E�X�𗣂����Ƃ�
    void MouseUp()
    {
        isDrag = false;
    }
}