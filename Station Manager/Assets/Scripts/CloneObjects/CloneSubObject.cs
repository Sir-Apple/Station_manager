using UnityEngine;
using UnityEngine.UI;

namespace CloneNewObject
{
    public class CloneSubObject
    {
        public static void CloneObjectInList3(GameObject childObject3, GameObject parentObject2)
        {
            GameObject objectList = UnityEngine.Object.Instantiate(childObject3) as GameObject;
            objectList.transform.SetParent(parentObject2.transform);
            objectList.transform.localScale = new Vector3(1, -2, 1);
            objectList.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);
            //objectList.transform.Find("Top").GetComponentInChildren<Text>().text = objectContent3;
        }
    }
}

