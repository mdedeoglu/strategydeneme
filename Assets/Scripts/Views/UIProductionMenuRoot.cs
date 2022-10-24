using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIProductionMenuRoot : UIRoot
{
    // Reference to menu view class.
    [SerializeField]
    private UIProductionMenuView menuView;
    public UIProductionMenuView MenuView => menuView;

    public override void ShowRoot()
    {
        base.ShowRoot();

        menuView.ShowView();
    }

    public override void HideRoot()
    {
        menuView.HideView();

        base.HideRoot();
    }
}
