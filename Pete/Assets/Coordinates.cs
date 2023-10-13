using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coordinates : MonoBehaviour
{
    [SerializeField] private TMP_Text xCoo;
    [SerializeField] private TMP_Text yCoo;

    // Update is called once per frame
    void Update()
    {
        xCoo.text = "x: " + transform.position.x;
        yCoo.text = "y: " + transform.position.y;
    }
}
