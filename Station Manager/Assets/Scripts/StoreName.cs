using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreName : MonoBehaviour
{
    public TextMeshProUGUI station_name;
    public TextMeshProUGUI station_namee;
    public TMP_InputField user_inputField;

    public void setName()
    {
        station_name.text = user_inputField.text.ToUpper();
        station_namee.text = user_inputField.text.ToUpper();
    }

}

//theStation = _textInputField.GetComponent<TMPro.TextMeshProUGUI>().text;
//textDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "Station: " + theStation;
