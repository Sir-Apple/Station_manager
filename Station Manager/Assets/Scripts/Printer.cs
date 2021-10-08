using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SmartDLL;
using UnityEngine.UI;
using TMPro;

public class Printer : MonoBehaviour
{

    public SmartPrinter smartPrinter = new SmartPrinter();

    public string headerDirectory;

    public TMP_InputField user_inputField;
    public Button printButton;


    void OnEnable()
    {
        printButton.onClick.AddListener(delegate { PrintDocument(); });
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PrintDocument()
    {
        smartPrinter.PrintDocument(user_inputField.text, @headerDirectory);
    }
}
