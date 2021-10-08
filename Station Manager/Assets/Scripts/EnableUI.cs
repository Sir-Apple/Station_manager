using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableUI : MonoBehaviour
{
    [SerializeField] GameObject label;

    // Start is called before the first frame update
    void Start()
    {
        label.gameObject.SetActive(false);
    }
    private void Onclick()
    {
        label.gameObject.SetActive(true);
    }
}
