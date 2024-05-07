using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    public GameObject PrefabCard;
    public Transform parentHandCard;
    void Generator()
    {
        GameObject CurrentCard = Instantiate(PrefabCard);
        CurrentCard.transform.SetParent(parentHandCard);        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Generator();
        }
    }
}
