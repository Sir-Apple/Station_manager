using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CloneNewObject;

public class ButtonUI2 : MonoBehaviour
{
    public string theName;

    public GameObject inputField;
    public GameObject childObject2;
    public GameObject parentObject2;
    public string textOnObject;


    public void AddMask2()
    {
        CloneObject2.CloneObjectInList2(childObject2, parentObject2, inputField.GetComponent<TMPro.TextMeshProUGUI>().text);
        //Debug.Log("Here");
    }
}