using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractDisplay : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI customText;

    private string fullText;
    // Start is called before the first frame update
    void Start()
    {
        fullText = "Press E to\n" + customText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
