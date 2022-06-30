using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private GameObject display;
    private TextMesh displayText;
    private float first_numb;
    private float second_numb;
    private string param;

    void Start() => displayText = display.GetComponent<TextMesh>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 20))
            {
                if(display.activeSelf) 
                {
                    if (hit.transform.tag == Names.Off)
                    {
                        display.SetActive(false);

                    }
                    if(hit.transform.tag == Names.Numb && displayText.text.Length < 7) 
                    {
                        displayText.text = (displayText.text == "0") ? hit.transform.name : (displayText.text + hit.transform.name);
                    }

                    if(hit.transform.tag == Names.Add || hit.transform.tag == Names.Subtract || hit.transform.tag == Names.Multiply || hit.transform.tag == Names.Divide) 
                    {
                        param = hit.transform.tag;
                        first_numb = float.Parse(displayText.text);
                        displayText.text = "0";
                    }
                    if(hit.transform.tag == Names.Calculate) 
                    {
                        second_numb = float.Parse(displayText.text);
                        
                        displayText.text = Calculator.Calculate(first_numb, second_numb, param, out int Error).ToString();
                        if (Error == 1) displayText.text = "can't";
                    }
                    if (hit.transform.tag == Names.C) displayText.text = "0";
                }
                else 
                {
                    if(hit.transform.tag == Names.On) 
                    {
                        display.SetActive(true);
                    }
                }
            }
        }
    }
}