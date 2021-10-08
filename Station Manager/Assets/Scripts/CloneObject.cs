using UnityEngine;
using UnityEngine.UI;

namespace CloneNewObject
{
    public class CloneObject
    {
        public static void CloneObjectInList(GameObject childObject, GameObject parentObject, string objectContent)
        {
            GameObject objectList = UnityEngine.Object.Instantiate(childObject) as GameObject;
            objectList.transform.SetParent(parentObject.transform);
            objectList.transform.localScale = new Vector3(1, 1, 1);
            objectList.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);
            objectList.transform.Find("Top View").GetComponentInChildren<Text>().text = objectContent;
        }
    }
}

