using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogoController : MonoBehaviour
{
    Image alpha;
    int nextScene;
    private Animator k;
    // Start is called before the first frame update
    void Start()
    {
     
    GameObject logoFind = GameObject.Find("Logo");
    
    
    k = GameObject.Find("Logo").GetComponent<Animator>();
        alpha = logoFind.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(alpha.color.a);
        if(alpha.color.a == 0)
        {
            
            SceneManager.LoadScene("MainTitleScene");
        }

    }
}
