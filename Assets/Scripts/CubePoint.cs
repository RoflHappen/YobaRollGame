using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePoint : MonoBehaviour
{
    [SerializeField][Range(1, 100)] int PointValue = 10;

    private void Awake()
    {
        gameObject.tag = "point";
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerInputControl.Instance.Score += PointValue;
        StartCoroutine(DestroySelf());
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerInputControl.Instance.Score += PointValue;
        StartCoroutine(DestroySelf());
    }

    private IEnumerator DestroySelf()
    {
        Debug.Log("bruh");
        Destroy(gameObject);
        yield return new WaitForEndOfFrame();
    }

}
