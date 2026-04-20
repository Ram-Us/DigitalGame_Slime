using Unity.VisualScripting;
using UnityEngine;

public class ColliderTransform : MonoBehaviour
{
    BoxCollider box;
    private Animator anim;
    AnimatorStateInfo stateInfo;
    Vector3 NormalSize = new Vector3(-0.025f, 0.025f, -0.014f);
    Vector3 NormalCenter = new Vector3(0f, 0f, 0.0056f);
    Vector3 JumpSize = new Vector3(-0.025f, 0.026f, -0.024f);
    Vector3 JumpCenter = new Vector3(0, 0, 0.0069f);
    Vector3 SquashSize  = new Vector3(-0.025f,0.025f,0.006f);
    Vector3 SquashCenter = new Vector3(0,0,0.003f);
    Vector3 HorizontalSize = new Vector3(-0.025f,0.07f,-0.009f);
    Vector3 HorizontalCenter = new Vector3(0,0,0.004f);
    Vector3 VerticalSize = new Vector3(-0.02f,0.01f,0.057f);
    Vector3 VerticalCenter = new Vector3(0.007f,0,0.025f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider>();
        box.size = NormalSize;
        box.center = NormalCenter;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Slime_Jump") || stateInfo.IsName("Slime_RightJump") || stateInfo.IsName("Slime_LeftJump"))
        {
            box.size = Vector3.Lerp(box.size, JumpSize, 0.4f);
            box.center = Vector3.Lerp(box.center, JumpCenter, 0.4f);
            //Debug.Log(box.size + "ジャンプコリだー" + box.center);
            box.size = Vector3.Lerp(box.size, NormalSize, 0.8f);
            box.center = Vector3.Lerp(box.center, NormalCenter, 0.8f);
        }
        if (stateInfo.IsName("Slime_Squaze"))
        {
            box.size = Vector3.Lerp(box.size, SquashSize, 0.3f);
            box.center = Vector3.Lerp(box.center, SquashCenter, 0.3f);
            //Debug.Log(box.size + "しゃがみコリだー" + box.center);
        }
        if (stateInfo.IsName("Slime_HorizontalStretch"))
        {
            box.size = Vector3.Lerp(box.size, HorizontalSize, 0.3f);
            box.center = Vector3.Lerp(box.center, HorizontalCenter, 0.3f);
            //Debug.Log(box.size + "横伸びコリだー" + box.center);
        }
        if (stateInfo.IsName("Slime_VerticalStretch"))
        {
            box.size = Vector3.Lerp(box.size, VerticalSize, 0.4f);
            box.center = Vector3.Lerp(box.center, VerticalCenter, 0.4f);
            //Debug.Log(box.size + "縦伸びコリだー" + box.center);
        }
        if (stateInfo.IsName("Slime_Idle")||stateInfo.IsName("Slime_Back")||stateInfo.IsName("Slime_HorizontalStretch_Back")|| stateInfo.IsName("Slime_VerticalStretch_Back"))
        {
            box.size = Vector3.Lerp(box.size, NormalSize, 0.3f);
            box.center = Vector3.Lerp(box.center, NormalCenter, 0.3f);
            //Debug.Log(box.size + "もとどおりコリだー" + box.center);
        }
        
    }
}
