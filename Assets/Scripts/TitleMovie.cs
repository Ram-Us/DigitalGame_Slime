using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Playables;
using System.Collections;

public class TitleMovie : MonoBehaviour
{
    private bool isStarting = false;
    private bool isInputting = false;
    private bool isAnimating = false;
    [SerializeField] private PlayableDirector playableDirector;
    [SerializeField] private TextMeshProUGUI ps;
    [SerializeField] private Volume volume;
    private ColorAdjustments colorAdjustments;
    [SerializeField] private float fadeSpeed = 1f;
    [SerializeField] private GameObject Logo;
    
    [SerializeField] private AudioClip click;
    private AudioSource audioSource;



    void Start()
    {
        Cursor.visible = true;
        ps.enabled = false;
        volume.profile.TryGet(out colorAdjustments);
        playableDirector.Stop();
        Logo.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        

        if(isStarting && Input.anyKey)
        {
            audioSource.PlayOneShot(click);
            isInputting = true;
        }
        if (isStarting && isInputting)
        {
            colorAdjustments.postExposure.value = Mathf.Lerp(colorAdjustments.postExposure.value, -10f, Time.deltaTime * fadeSpeed);

            if (colorAdjustments.postExposure.value <= -9f)
            {
                
                SceneManager.LoadScene("Main");
            }
        }
        if (isAnimating)
        {
            playableDirector.Play();
            //playableDirector.playableGraph.GetRootPlayable(0).SetSpeed(0.6f);
        }
        else
        {
            playableDirector.Stop();
        }
    }
    public void Title()
    {
        Logo.SetActive(true);
        isStarting = true;
        ps.enabled = true;
        isAnimating = true;
    }

    IEnumerator Taiki()
    {
        yield return new WaitForSeconds(1f);//１秒待つ
    }
}
