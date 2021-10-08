using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;
using UnityEngine.UI;
using TMPro;

public class QRCodeGenerator : MonoBehaviour
{

    //public TextMeshProUGUI user_name;
    //public TMP_InputField

    [SerializeField]
    private RawImage _rawImageReceiver;
    [SerializeField]
    private RawImage _rawImageReceiverr;
    [SerializeField]
    private TMP_InputField _textInputField;

    private Texture2D _storeEncodedTexture;

    //public QRCodeEncodeController qrEncodeController;

    // Start is called before the first frame update
    void Start()
    {
        _storeEncodedTexture = new Texture2D(256, 256);
    }

    private Color32[] Encode(string textForEncoding, int width, int height)
    {
        BarcodeWriter writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };
        return writer.Write(textForEncoding);
    }
    public void OnClickEncode()
    {
        EncodeTextToQRCode();
        Debug.Log("QR Generated and Screenshot");
    }

    private void EncodeTextToQRCode()
    {
        string textWrite = string.IsNullOrEmpty(_textInputField.text) ? "You should write something" : "Station: " + _textInputField.text;

        Color32[] _convertPixelToTexture = Encode(textWrite, _storeEncodedTexture.width, _storeEncodedTexture.height);
        _storeEncodedTexture.SetPixels32(_convertPixelToTexture);
        _storeEncodedTexture.Apply();

        _rawImageReceiver.texture = _storeEncodedTexture;
        _rawImageReceiverr.texture = _storeEncodedTexture;
    }
}
