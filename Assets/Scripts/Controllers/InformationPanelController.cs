using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Controller responsible for production menu
/// </summary>
public class InformationPanelController : SubController<UIInformationPanelRoot>
{
    public override void EngageController()
    {
        // Attaching UI events.
        ui.MenuView.OnPlayClicked += StartGame;
        ui.MenuView.OnQuitClicked += QuitGame;

        base.EngageController();
    }

    public override void DisengageController()
    {
        base.DisengageController();

        // Detaching UI events.
        ui.MenuView.OnQuitClicked -= QuitGame;
        ui.MenuView.OnPlayClicked -= StartGame;
    }

    /// <summary>
    /// Handling UI Start Button Click.
    /// </summary>
    private void StartGame()
    {
        // Changing controller to Game Controller.
        root.ChangeController(RootController.ControllerTypeEnum.Game);
    }

    /// <summary>
    /// Handling UI Quit Button Click.
    /// </summary>
    private void QuitGame()
    {
        // Closing the game.
        Application.Quit();
    }
}
