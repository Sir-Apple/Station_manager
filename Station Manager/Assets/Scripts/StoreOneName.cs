using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreOneName : MonoBehaviour
{
    public TextMeshProUGUI station_name;
    public TMP_InputField user_inputField;

    public void setName()
    {
        station_name.text = user_inputField.text.ToUpper();
    }

}
