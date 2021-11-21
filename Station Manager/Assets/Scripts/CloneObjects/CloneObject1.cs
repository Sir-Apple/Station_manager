using UnityEngine;
using UnityEngine.UI;

namespace CloneNewObject
{
    public class CloneObject1
    {
        public static void CloneObjectInList1(GameObject childObject, GameObject parentObject, string objectContent)
        {
            GameObject objectList = UnityEngine.Object.Instantiate(childObject) as GameObject;
            objectList.transform.SetParent(parentObject.transform);
            objectList.transform.localScale = new Vector3(1, 1, 1);
            objectList.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);
            objectList.transform.Find("inactive (1)").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = objectContent;
            objectList.transform.Find("inactive").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = objectContent;
        }
    }
}

