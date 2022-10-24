using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FactorySample;

public class ButtonPanel : MonoBehaviour
{
    [SerializeField]
    private Button buttonPrefab;
    void Start()
    {

        foreach (string name in ItemFactory.GetItemNames())
        {
           
            var button = Instantiate(buttonPrefab,transform);
            button.name = name + "Button";
            //Item item = ItemFactory.GetItem(name);
            Item item = ItemFactory.GetItem(name);

            button.onClick.AddListener(item.Build);
            button.interactable = true;
            button.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + item.SpriteName);
            
        }
    }
}
