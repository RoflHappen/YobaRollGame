using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField][Range(-100, 100)] private float angleVelocity = 20;
    [SerializeField] private Image Loading;
    [SerializeField] private Image LoadingBar;

    public static LoadingScreen Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Instance.gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Loading.rectTransform.Rotate(0, 0, angleVelocity * Time.fixedDeltaTime);
    }

    public void SetComplete(float val)
    {
        LoadingBar.fillAmount = val;
    }

    public IEnumerator LoadScene(int id = 0)
    {
        gameObject.SetActive(true);
        var ao = SceneManager.LoadSceneAsync(id);
        ao.allowSceneActivation = false;
        ao.completed += (e) => { Debug.LogError("BRUH DUDE IT WORKS"); };
        do
        {
            SetComplete(ao.progress);
            yield return null;
        }
        while (ao.progress < 0.9f); 


        ao.allowSceneActivation = true;
        gameObject.SetActive(false);
    }

}
