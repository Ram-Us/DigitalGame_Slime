using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ImageButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("拡大設定")]
    [SerializeField] private float scaleUpSize = 1.1f; // 拡大倍率
    [SerializeField] private float scaleSpeed = 8f;    // 拡大スピード

    [Header("ボタン番号設定")]
    [SerializeField] private int number = 0; // 0=タイトル, 1=メイン, 2=スコア など

    private RectTransform rectTransform;
    private Vector3 originalScale;
    private bool isHovered = false;
    private bool isSenninng = false;
    private float SenniSpeed = 3f;
    [SerializeField] private Volume v;
    private ColorAdjustments ca;
    [SerializeField] private AudioClip click;
    private AudioSource audioSource;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        v.profile.TryGet(out ca);
    }
    void Update()
    {
        Debug.Log(ca.postExposure.value + ""+isSenninng);

        if (isSenninng)
        {
            
            ca.postExposure.value = Mathf.Lerp(ca.postExposure.value, -10f,  Time.deltaTime*SenniSpeed);

            if(ca.postExposure.value < -9f)
            {
                
                switch (number)
                {
                    case 0:
                        SceneManager.LoadScene("Title");
                        break;
                    case 1:
                        SceneManager.LoadScene("Main");
                        break;
                    case 2:
                        SceneManager.LoadScene("Score");
                        break;


                }
                
            }
        }
        // 目標スケールを設定
        Vector3 targetScale = isHovered ? originalScale * scaleUpSize : originalScale;

        // スムーズに補間
        rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, targetScale, Time.unscaledDeltaTime * scaleSpeed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        audioSource.PlayOneShot(click);
        // クリック時の効果音やアニメ演出などを追加してもOK
        Debug.Log("こんにちは");
        isSenninng = true;
        Time.timeScale = 1f;
    }
}
