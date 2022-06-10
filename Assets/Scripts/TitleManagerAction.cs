using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManagerAction : MonoBehaviour
{
    Image fadeIn;
    int startBtn;
    private Animator fadeIO;
    // Start is called before the first frame update
    void FadeInOut()//타이틀화면 진입시 페이드아웃 위한 세팅
    {
        GameObject fadeInFind = GameObject.Find("FadeIn");
        fadeIO = GameObject.Find("FadeIn").GetComponent<Animator>();
        fadeIn = fadeInFind.GetComponent<Image>();
    }

    private void Start()
    {
        FadeInOut();

    }


    // Update is called once per frame
    void Update()
    {
      
    }
}
