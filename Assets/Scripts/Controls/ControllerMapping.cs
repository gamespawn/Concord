using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LightJson;
using LightJson.Serialization;

public static class ControllerMapping
{
    private class Keys
    {
        public const string HorizontalAxis = "HorizontalAxis";
        public const string VerticalAxis = "VerticalAxis";

        public const string Select = "Select";
        public const string Cancel = "Cancel";
        public const string Attack = "Attack";
        public const string Dodge = "Dodge";
        public const string Menu = "Menu";
    }

    public const string PlayerControlsPath = "ControlsLayout/";
    public const string PlayerControlsJSON = "PlayerControls";

    public static KeyBinds GetKeyBinds(int id)
    {
        switch(id)
        {
            case -1:
                JsonObject json = JsonReader.Parse(Resources.Load<TextAsset>($"{PlayerControlsPath}{PlayerControlsJSON}").text);
                return new KeyBinds
                    (
                    new KeyBinds.Menu(
                        new Axis(json[Keys.HorizontalAxis]),
                        new Axis(json[Keys.VerticalAxis]),
                        (KeyCode)json[Keys.Select].AsInteger,
                        (KeyCode)json[Keys.Cancel].AsInteger),

                    new KeyBinds.InGame(
                        new Axis(json[Keys.HorizontalAxis]),
                        new Axis(json[Keys.VerticalAxis]),
                        (KeyCode)json[Keys.Attack].AsInteger,
                        (KeyCode)json[Keys.Dodge].AsInteger,
                        (KeyCode)json[Keys.Menu].AsInteger)
                    );
            default:
                return new KeyBinds(new KeyBinds.Menu(), new KeyBinds.InGame());
        }
    }
}
