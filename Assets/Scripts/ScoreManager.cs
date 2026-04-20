using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Data.SqlTypes;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class ScoreManager : MonoBehaviour
{

    [SerializeField] private TextMeshPro allSc;
    [SerializeField] private Volume GlovalVolume;
    [SerializeField] private GameObject canvas,clImage,nclImage;
    private Bloom bloom;
    private bool BloomTrigger = false;
    private float MaxIntensity = 2063f;
    private float NormalIntensity = 0f;
    [SerializeField] private float BloomSpeed;
    private float elapsedTime = 0f;
    private bool isReducing = true;
    private int sc,ad=0;
    private float cd;
    [SerializeField] private AudioClip cl, ncl, dr;
    private AudioSource audioSource;


    void Start()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        GlovalVolume.profile.TryGet(out bloom);
        bloom.intensity.value = MaxIntensity;
        sc = GameManager.Instance.Score;
        cd = CountdownTsimer.Instance.TimeRemain;
        canvas.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        clImage.SetActive(false);
        nclImage.SetActive(false);
        audioSource.PlayOneShot(dr);
        
        allSc.text = "";

    }
    void Update()
    {
        Debug.Log(CountdownTsimer.Instance.IsClearing);
        if (isReducing)
        {
            bloom.intensity.value = Mathf.Lerp(bloom.intensity.value, NormalIntensity, Time.deltaTime * BloomSpeed);
            elapsedTime += Time.deltaTime;
            //Debug.Log(bloom.intensity.value + "  " + elapsedTime.ToString("F2") + "だよ"+isReducing);
            if (bloom.intensity.value < 0.1f)
            {
                bloom.intensity.value = 0f;
                isReducing = false;
            }
            
        }
        
    }
    
    public void Result()
    {
        

        if (cd < 60f)//1分以下
        {
            ad = 50;
        }
        else if (cd < 120f)//2分以下
        {
            ad = 100;
        }
        else if (cd < 180f)//3分以下
        {
            ad = 150;
        }
        else if (cd < 240f)//4分以下
        {
            ad = 200;
        }
        else if (cd < 300f)//5分以下
        {
            ad = 250;
        }
        allSc.text = $"{sc + ad}";
        if (CountdownTsimer.Instance.IsClearing)
        {
            clImage.SetActive(true);
            audioSource.PlayOneShot(cl);
        }
        else
        {
            nclImage.SetActive(true);
            audioSource.PlayOneShot(ncl);
        }
        canvas.SetActive(true);
        Cursor.visible = true;
    }
}
