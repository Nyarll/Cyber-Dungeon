using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject HitPointObject;

    GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        obj = (GameObject)Instantiate(HitPointObject,
                Vector3.zero,
                Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        TurnMousePosition();
    }

    void Movement()
    {
        float speed = 0.005f;

        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            move.z = 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            move.z = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            move.x = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            move.x = 1f;
        }

        move.Normalize();
        move *= speed;

        this.transform.position += move;
    }

    void TurnMousePosition()
    {
        // �}�E�X�ʒu���W�擾
        Vector3 mousePositon = Input.mousePosition;

        // �}�E�X�̃X�N���[�����W���烌�C���΂�
        Ray ray = Camera.main.ScreenPointToRay(mousePositon);
        RaycastHit hit;

        int mask = 1 << 9;

        // ���C�Ə��̓����蔻��
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
        {
            obj.transform.position = hit.point;
        }

        // ���Ƀ��C���Ԃ���������������
        this.transform.LookAt(hit.point);
    }
}
