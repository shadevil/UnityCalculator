using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private GameObject display;
    private float value;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
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
