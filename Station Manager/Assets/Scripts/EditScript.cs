using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ConnectServer;
using TMPro;

public class EditScript : MonoBehaviour
{

    [SerializeField]
    private TMP_InputField _textInputField;

    public void ButtonClick()
    {
        Connect.UploadInfo("http://127.0.0.1/index.php", _textInputField.text);
    }
}
