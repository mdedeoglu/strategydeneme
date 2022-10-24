using UnityEngine;

/// <summary>
/// Controller responsible for game phase.
/// </summary>
public class GameController : SubController<UIGameRoot>
{
    // Reference to current game data.
    private GameData gameData;

    public override void EngageController()
    {
        // New game need fresh data.
        gameData = new GameData();

        // Attaching UI events.
        ui.GameView.OnFinishClicked += FinishGame;
        ui.GameView.OnMenuClicked += GoToMenu;

        // Restarting game time.
        ui.GameView.UpdateTime(0);

        base.EngageController();
    }

    public override void DisengageController()
    {
        base.DisengageController();

        // Detaching UI events.
        ui.GameView.OnMenuClicked -= GoToMenu;
        ui.GameView.OnFinishClicked -= FinishGame;
    }

    /// <summary>
    /// Unity method called each frame as game object is enabled.
    /// </summary>
    private void Update()
    {
        // Increasing time value.
        gameData.gameTime += Time.deltaTime;
        // Displaying current game time.
        ui.GameView.UpdateTime(gameData.gameTime);
    }

    /// <summary>
    /// Handling UI Finish Button Click.
    /// </summary>
    private void FinishGame()
    {
        // Assigning random score.
        gameData.gameScore = Mathf.CeilToInt(gameData.gameTime * Random.Range(0.0f, 10.0f));
        // Saving GameData in DataStorage.
        DataStorage.Instance.SaveData(Keys.GAME_DATA_KEY, gameData);

        // Chaning controller to Game Over Controller
        root.ChangeController(RootController.ControllerTypeEnum.GameOver);
    }

    /// <summary>
    /// Handling UI Menu Button Click.
    /// </summary>
    private void GoToMenu()
    {
        // Changing controller to Menu Controller.
        root.ChangeController(RootController.ControllerTypeEnum.Menu);
    }
}
