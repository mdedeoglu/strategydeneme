using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInformationPanelRoot : UIRoot
{
    // Reference to menu view class.
    [SerializeField]
    private UIInformationPanelView menuView;
    public UIInformationPanelView MenuView => menuView;

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
