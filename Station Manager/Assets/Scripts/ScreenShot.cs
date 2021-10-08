using System.Collections;
using System.IO;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    public GameObject UI;
    public GameObject UI2;
    public GameObject UI3;
    public GameObject UI4;
    public GameObject UI5;
    public GameObject UI6;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private IEnumerator Screenshot()
    {
        yield return new WaitForEndOfFrame();
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();

        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(Application.persistentDataPath + "/QR.png", bytes);

        string name = "QR_EpicApp" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
        string pathToSave = name;
        ScreenCapture.CaptureScreenshot(pathToSave);

        //MOBILE
        //SaveImageToGallery(texture, "Myapp pictures", name);
        //NativeGallery.SaveImageToGallery(texture, "Myapp pictures", name);

        Destroy(texture);
        UI.SetActive(true);
        UI2.SetActive(true);
        UI3.SetActive(true);
        UI4.SetActive(true);
        UI5.SetActive(true);
        UI6.SetActive(true);
    }

    public void TakeScreenshot()
    {
        UI.SetActive(false);
        UI2.SetActive(false);
        UI3.SetActive(false);
        UI4.SetActive(false);
        UI5.SetActive(false);
        UI6.SetActive(false);
        StartCoroutine("Screenshot");
    } 
}
