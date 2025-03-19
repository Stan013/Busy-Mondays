using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenText : MonoBehaviour
{
    [SerializeField] private GameObject textButton;

    public void SetActive()
    {
        if(textButton.activeSelf == true)
        {
            textButton.SetActive(false);
        }
        else
        {
            textButton.SetActive(true);
        }
    }
}
