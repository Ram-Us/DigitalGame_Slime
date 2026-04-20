using System;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Vector3 cameraRotation;
    private float cameraXRotation, cameraYRotation;

    [Header("Camera Rotation Limits")]
    [SerializeField] float minXRotation = -60f;  // 縦回転の最小値（上方向）
    [SerializeField] float maxXRotation = 60f;   // 縦回転の最大値（下方向）
    [SerializeField] float rotationSpeed = 3f;   // 回転の速度調整用
    [SerializeField] float distanceFromPlayer = 5f;  // カメラのプレイヤーからの距離

    void Start()
    {
        cameraRotation = transform.eulerAngles;
        cameraXRotation = cameraRotation.x;
        cameraYRotation = cameraRotation.y;
    }

    void Update()
    {
        if (SlimeController.Instance.IsMoving)
        {
            // マウスの移動量を取得
            float mx = Input.GetAxis("Mouse X");
            float my = Input.GetAxis("Mouse Y");

            // 横回転（Y軸）
            if (Mathf.Abs(mx) > 0.001f)
            {
                // 横回転を反映
                cameraYRotation += mx * rotationSpeed;
                cameraYRotation = cameraYRotation % 360f;  // Y回転は360度で循環するように
                
            }

            // 縦回転（X軸）
            if (Mathf.Abs(my) > 0.001f)
            {
                // 縦回転を反映
                cameraXRotation -= my * rotationSpeed;
                cameraXRotation = Mathf.Clamp(cameraXRotation, minXRotation, maxXRotation);  // 回転制限
            }

            // プレイヤーの周りを回転させるための位置計算
            Quaternion rotation = Quaternion.Euler(cameraXRotation, cameraYRotation, 0f);
            Vector3 direction = rotation * Vector3.back;  // カメラの向きを計算（後方方向）
            transform.position = player.transform.position + direction * distanceFromPlayer;  // プレイヤーから指定距離だけ離す

            // カメラが常にプレイヤーを向くようにする
            transform.LookAt(player.transform);

        }
    }

    /// <summary>
    /// カメラの横回転角度を取得（Y軸の回転）
    /// </summary>
    public float GetCameraYRotation()
    {
        return cameraYRotation;
    }

    /// <summary>
    /// カメラが向いている方向を取得
    /// </summary>
    public Vector3 GetCameraForwardDirection()
    {
        Quaternion rotation = Quaternion.Euler(0, cameraYRotation, 0);
        return rotation * Vector3.forward;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(this.transform.position, player.transform.position);
    }
}
