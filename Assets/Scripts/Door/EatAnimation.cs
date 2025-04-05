using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatAnimation : MonoBehaviour
{
    [SerializeField] private GameObject mouth;
    private float startingScale;
    [SerializeField] private float big;
    [SerializeField] private float small;

    private void Start()
    {
        startingScale = mouth.transform.localScale.z;
    }

    public void Eat()
    {
        StartCoroutine(Scale());
    }


    //private IEnumerator Scale()
    //{
    //    mouth.transform.localScale = new Vector3(mouth.transform.localScale.x, mouth.transform.localScale.y, 2.5f);
    //    yield return new WaitForSeconds(0.2f);
    //    mouth.transform.localScale = new Vector3(mouth.transform.localScale.x, mouth.transform.localScale.y, 2.5f);
    //    yield return new WaitForSeconds(0.2f);
    //    mouth.transform.localScale = new Vector3(mouth.transform.localScale.x, mouth.transform.localScale.y, 2.5f);
    //}
    private IEnumerator Scale()
    {
        float time = 0f;
        while (time < 0.2f)
        {
            float t = time / 0.2f;
            transform.localScale = Vector3.Lerp(new Vector3(mouth.transform.localScale.x, mouth.transform.localScale.y, startingScale), new Vector3(mouth.transform.localScale.x, mouth.transform.localScale.y, big), t);
            time += Time.deltaTime;
            yield return null;
        }
        time = 0f;
        while (time < 0.2f)
        {
            float t = time / 0.2f;
            transform.localScale = Vector3.Lerp(new Vector3(mouth.transform.localScale.x, mouth.transform.localScale.y, big), new Vector3(mouth.transform.localScale.x, mouth.transform.localScale.y, small), t);
            time += Time.deltaTime;
            yield return null;
        }
        time = 0f;
        while (time < 0.2f)
        {
            float t = time / 0.2f;
            transform.localScale = Vector3.Lerp(new Vector3(mouth.transform.localScale.x, mouth.transform.localScale.y, small), new Vector3(mouth.transform.localScale.x, mouth.transform.localScale.y, startingScale), t);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localScale = new Vector3(mouth.transform.localScale.x, mouth.transform.localScale.y, startingScale);
    }
}
