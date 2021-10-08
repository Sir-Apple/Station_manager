using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CloneNewObject;

public class ButtonUI : MonoBehaviour
{
    public string theName;

    public GameObject inputField;
    public GameObject childObject;
    public GameObject parentObject;
    public string textOnObject;


    public void AddMask()
    {
        CloneObject.CloneObjectInList(childObject, parentObject, inputField.GetComponent<TMPro.TextMeshProUGUI>().text);
        //Debug.Log("Here");
    }
}
