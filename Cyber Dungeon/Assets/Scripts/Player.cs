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
        // マウス位置座標取得
        Vector3 mousePositon = Input.mousePosition;

        // マウスのスクリーン座標からレイを飛ばす
        Ray ray = Camera.main.ScreenPointToRay(mousePositon);
        RaycastHit hit;

        int mask = 1 << 9;

        // レイと床の当たり判定
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
        {
            obj.transform.position = hit.point;
        }

        // 床にレイがぶつかった方向を向く
        this.transform.LookAt(hit.point);
    }
}
