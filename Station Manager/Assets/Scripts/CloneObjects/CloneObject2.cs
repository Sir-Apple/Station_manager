using UnityEngine;
using UnityEngine.UI;

namespace CloneNewObject
{
    public class CloneObject2
    {
        public static void CloneObjectInList2(GameObject childObject2, GameObject childObject3, GameObject parentObject2, string objectContent2)
        {
            GameObject objectList = UnityEngine.Object.Instantiate(childObject2) as GameObject;
            objectList.transform.SetParent(parentObject2.transform);
            objectList.transform.localScale = new Vector3(1, 1, 1);
            objectList.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);
            objectList.transform.Find("Top View").GetComponentInChildren<Text>().text = objectContent2;
            GameObject objectList2 = UnityEngine.Object.Instantiate(childObject3) as GameObject;
            objectList2.transform.SetParent(parentObject2.transform);
            objectList2.transform.localScale = new Vector3(1, 0, 1);
            objectList2.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);
        }
    }
}

