using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ConnectServer;
using TMPro;

public class InsertScript : MonoBehaviour
{

    [SerializeField]
    private TMP_InputField _textInputField;
    [SerializeField]
    private TMP_InputField _newValue;

    public void ButtonClick()
    {
        Connect.UploadInfo("http://127.0.0.1/index.php", _textInputField.text);
        //Connect.UpdateInfo("http://127.0.0.1/update.php", _textInputField.text, "dark");
    }

    public void UpdateButtonClick()
    {
        //Connect.UploadInfo("http://127.0.0.1/index.php", _textInputField.text);
        Connect.UpdateInfo("http://127.0.0.1/update.php", _newValue.text, _textInputField.text);
    }
}
