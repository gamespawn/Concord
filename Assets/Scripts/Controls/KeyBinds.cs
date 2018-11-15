using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBinds
{
    public struct Menu
    {
        public Axis Horizontal { private set; get; }
        public Axis Vertical { private set; get; }

        public KeyCode Select { private set; get; }
        public KeyCode Cancel { private set; get; }

        public Menu(Axis Horizontal, Axis Vertical, KeyCode Select, KeyCode Cancel)
        {
            this.Horizontal = Horizontal;
            this.Vertical = Vertical;

            this.Select = Select;
            this.Cancel = Cancel;
        }
    }

    public struct InGame
    {
        public Axis Horizontal { private set; get; }
        public Axis Vertical { private set; get; }

        public KeyCode Attack { private set; get; }
        public KeyCode Dodge { private set; get; }
        public KeyCode OpenMenu { private set; get; }

        public InGame(Axis Horizontal, Axis Vertical, KeyCode Attack, KeyCode Dodge, KeyCode OpenMenu)
        {
            this.Horizontal = Horizontal;
            this.Vertical = Vertical;

            this.Attack = Attack;
            this.Dodge = Dodge;
            this.OpenMenu = OpenMenu;
        }
    }

    public KeyBinds(Menu MenuKeys, InGame InGameKeys)
    {
        this.MenuKeys = MenuKeys;
        this.InGameKeys = InGameKeys;
    }

    public Menu MenuKeys;
    public InGame InGameKeys;
}
