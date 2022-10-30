using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FormSubmitter : MonoBehaviour
{

    [SerializeField] private InputField Login; 
    [SerializeField] private InputField Password; 

    public void Submit()
    {
        GetAuthAPIResponce();
    }


    private void GetAuthAPIResponce()
    {
        StartCoroutine(LoadingScreen.Instance.LoadScene(0));
    }

}
