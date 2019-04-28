using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLoadingScript : MonoBehaviour
{
    Text text;
    bool active;
    void Start()
    {
        text = GetComponent<Text>();
        active = true;

        StartCoroutine("AddDot");
    }

    IEnumerator AddDot()
    {
        while (active)
        {
            yield return new WaitForSeconds(0.1f);
            text.text += ".";
        }
    }

    public void Disable()
    {
        active = false;
    }
}
