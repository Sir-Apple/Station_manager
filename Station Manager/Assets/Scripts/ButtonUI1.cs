using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CloneNewObject;
using TMPro;

public class ButtonUI1 : MonoBehaviour
{
    public string theName;

    [SerializeField] public TMP_InputField _textInputField;
    public GameObject childObject;
    public GameObject parentObject;
    public string textOnObject;

    public void AddMaskk()
    {
        CloneObject.CloneObjectInList(childObject, parentObject, _textInputField.GetComponent<TMPro.TextMeshProUGUI>().text);
    }
}
