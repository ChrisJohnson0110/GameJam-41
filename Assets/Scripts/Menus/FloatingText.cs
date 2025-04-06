using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    GameObject textObject;

    // Start is called before the first frame update
    void Start()
    {
        CreateFloatingText(this.gameObject, "Press E");
    }


    public void CreateFloatingText(GameObject parent, string textContent)
    {
        textObject = new GameObject("FloatingText");
        textObject.transform.SetParent(parent.transform);
        textObject.transform.localPosition = new Vector3(0, 0.0067f, 0.00632f);
        textObject.transform.rotation = Quaternion.Euler(0, 90, 0);

        TextMeshPro textMesh = textObject.AddComponent<TextMeshPro>();
        textMesh.text = textContent;
        textMesh.fontSize = 9;
        textMesh.alignment = TextAlignmentOptions.Center;
        textMesh.color = Color.magenta;
        textMesh.richText = true; // Enables color formatting
    }

    public void DestroyFloatingText()
    {
        Destroy(textObject);
    }
}
