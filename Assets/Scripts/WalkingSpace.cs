using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using NUnit.Framework;
using Unity.Multiplayer.Center.Common;
using UnityEngine;

public class WalkingSpace : MonoBehaviour
{
    [Header("移動範囲（直接座標指定）")]
    [SerializeField] private Vector3 pointA = new Vector3(0, 0.33f, 0.58f);
    [SerializeField] private Vector3 pointB = new Vector3(0, 0.33f, 0.73f);
    [SerializeField] private float speed = 2f;

    private Vector3 target;
    [SerializeField] private bool isMoving = false;

    public bool IsMoving => isMoving;
    private bool reachedEnd = false;
    private GameObject player;
    private SlimeController slimeController;

    void Start()
    {
        // 初期位置を pointA に置き、最初のターゲットを pointB にする
        transform.position = pointA;
        target = pointB;
    }

    void Update()
    {
        if (isMoving && !reachedEnd)
        {
            // target を使って移動（MoveTowards と到達判定を一致させる）
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target) < 0.01f)
            {
                    reachedEnd = true;
                    isMoving = false;
                    player.transform.SetParent(null);
                    Debug.Log("足場が終点に到達し、停止しました");
                
            }
        }
        //Debug.Log("これはWalkingSpce"+isMoving);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
            player = collision.gameObject;

            if (!reachedEnd)
            {
                isMoving = true;
            }
            Debug.Log("足場が動き始めました");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            Debug.Log("足場から離れました");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pointA, 0.05f);
        Gizmos.DrawWireSphere(pointB, 0.05f);
        Gizmos.DrawLine(pointA, pointB);
    }

    public void PositionReset()
    {
        transform.position = pointA;
        reachedEnd = false;
        isMoving = false;
        isMoving = false;
        Debug.Log("リセットッ！");
    }
}
