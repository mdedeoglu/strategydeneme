using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionItem : MonoBehaviour
{
    private string itemName;
    private Sprite sprite;
    private int dimensionX;
    private int dimensionY;

    public int DimensionX {
        get { return dimensionX; }        
        set { dimensionX = value; }                    
    }
    public int DimensionY { 
        get { return dimensionY; }
        set { dimensionY = value; }        
    }
    /*
    private Grid.DropType type;
    public Grid.DropType Type
    {
        get { return type;  }
        
    }*/
    /*
    private Grid grid;
    public Grid GridRef
    {
        get { return grid; }
    }

    private MoveableDrop moveableComponent;
    public MoveableDrop MoveableComponent {
        get { return moveableComponent; }
    }

    private ColorDrop colorComponent;
    public ColorDrop ColorComponent
    {
        get { return colorComponent; }
    }

    */

    private void Awake()
    {
       // moveableComponent = GetComponent < MoveableDrop >();
      //  colorComponent = GetComponent<ColorDrop>();
    }

    public void Init(int _dimensionX, int _dimensionY, string _itemName,Sprite _sprite, Grid _grid)//, Grid.DropType _type) 
    {
        dimensionX = _dimensionX;
        dimensionY = _dimensionY;
       // grid = _grid;
        itemName = _itemName;
        sprite = _sprite;
      //  type = _type;
    }
    /*
    public bool IsMovable() {
        return moveableComponent != null;
    }

    public bool IsColored()
    {
        return colorComponent != null;
    }
    */
    
}


