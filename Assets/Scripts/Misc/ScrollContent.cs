using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using FactorySample;
public class ScrollContent : MonoBehaviour
{
    #region Public Properties

    /// <summary>
    /// How far apart each item is in the scroll view.
    /// </summary>
    public float ItemSpacing { get { return itemSpacing; } }

    /// <summary>
    /// How much the items are indented from left and right of the scroll view.
    /// </summary>
    public float HorizontalMargin { get { return horizontalMargin; } }

    /// <summary>
    /// How much the items are indented from top and bottom of the scroll view.
    /// </summary>
    public float VerticalMargin { get { return verticalMargin; } }

    /// <summary>
    /// The width of the scroll content.
    /// </summary>
    public float Width { get { return width; } }

    /// <summary>
    /// The height of the scroll content.
    /// </summary>
    public float Height { get { return height; } }

    /// <summary>
    /// The width for each child of the scroll view.
    /// </summary>
    public float ChildWidth { get { return childWidth; } }

    /// <summary>
    /// The height for each child of the scroll view.
    /// </summary>
    public float ChildHeight { get { return childHeight; } }

    #endregion

    #region Private Members

    /// <summary>
    /// The RectTransform component of the scroll content.
    /// </summary>
    private RectTransform rectTransform;

    /// <summary>
    /// The RectTransform components of all the children of this GameObject.
    /// </summary>
    private RectTransform[] rtChildren;

    /// <summary>
    /// The width and height of the parent.
    /// </summary>
    private float width, height;

    /// <summary>
    /// The width and height of the children GameObjects.
    /// </summary>
    private float childWidth, childHeight;

    /// <summary>
    /// How far apart each item is in the scroll view.
    /// </summary>
    [SerializeField]
    private float itemSpacing;

    /// <summary>
    /// How much the items are indented from the top/bottom and left/right of the scroll view.
    /// </summary>
    [SerializeField]
    private float horizontalMargin, verticalMargin;

    /// <summary>
    /// Is the scroll view oriented horizontall or vertically?
    /// </summary>
    [SerializeField]
    private bool horizontal, vertical;

    //[SerializeField]
    //private GameObject prefab;

    [SerializeField]
    private Button buttonPrefab;

    #endregion

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rtChildren = new RectTransform[30];

        int i2 = 0;
        foreach (string name in ItemFactory.GetItemNames())
        {

            var button = Instantiate(buttonPrefab, transform);
            button.name = "b"+i2.ToString();
            Item item = ItemFactory.GetItem(name);            
            
            button.onClick.AddListener(item.Build);            
            button.interactable = true;
            
            button.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + item.SpriteName);
            rtChildren[i2] = button.GetComponent<RectTransform>();
            i2++;

        }
        for (int i = i2; i < 30; i++)
        {
            var button = Instantiate(buttonPrefab, rectTransform);
            button.interactable = false;
            button.name = "b"+i2.ToString();
            rtChildren[i] = button.GetComponent<RectTransform>();
        }

        width = rectTransform.rect.width;
        height = rectTransform.rect.height;
        childWidth = rtChildren[0].rect.width;
        childHeight = rtChildren[0].rect.height;      
        InitializeContentVertical();
      

    }


    /// <summary>
    /// Initializes the scroll content if the scroll view is oriented vertically.
    /// </summary>
    private void InitializeContentVertical()
    {
        float originY = 0 + (height * 0.5f);
        float posOffset = childHeight * 0.5f;
        for (int i = 0; i < rtChildren.Length; i++)
        {
            Vector2 childPos = rtChildren[i].localPosition;
            
            if (i % 2 == 0) {
                childPos.x = -50;
                childPos.y = originY - posOffset - i/2f * (childHeight + itemSpacing);
            }
            else { 
                childPos.x = 50;
                childPos.y = originY - posOffset - (i-1)/2f * (childHeight + itemSpacing);
            }
            rtChildren[i].transform.Find("Text").GetComponent<Text>().text = "Button-" + i.ToString();
            rtChildren[i].transform.name = "Button-" + i.ToString();
            rtChildren[i].localPosition = childPos;
        }
    }
}
