using UnityEngine;
using UnityEngine.UI;

namespace CloneNewObject
{
    public class CloneObject2
    {
        public static void CloneObjectInList2(GameObject childObject2, GameObject parentObject2, string objectContent2)
        {
            GameObject objectList = UnityEngine.Object.Instantiate(childObject2) as GameObject;
            objectList.transform.SetParent(parentObject2.transform);
            objectList.transform.localScale = new Vector3(1, 1, 1);
            objectList.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);
            objectList.transform.Find("Top").GetComponentInChildren<Text>().text = objectContent2;
        }
    }
}

