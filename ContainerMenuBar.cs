using Godot;
using System;

public partial class ContainerMenuBar : PanelContainer
{
    private MenuBar _menuBar;

    public override void _Ready()
    {
        // Create MenuBar
        _menuBar = new MenuBar();
        AddChild(_menuBar);

        // Apply "Top Wide" anchor preset to make the MenuBar span the top width
        //_menuBar.SetAnchorPreset(Control.LayoutPreset.Wide, Control.LayoutPresetMode.KeepPosition);
        _menuBar.AnchorBottom = 0; // Ensure it's only at the top
        _menuBar.OffsetTop = 0;

        // Enable horizontal expansion
        //_menuBar.SizeFlagsHorizontal = (int)Control.SizeFlags.Expand | (int)Control.SizeFlags.Fill;

        // Create "File" menu
        var fileMenu = new PopupMenu();
        fileMenu.Name = "File";
        fileMenu.AddItem("New", 1);
        fileMenu.AddItem("Open", 2);
        fileMenu.AddSeparator();
        fileMenu.AddItem("Save", 3);
        fileMenu.AddItem("Exit", 4);

        // Add the submenu to the MenuBar
        _menuBar.AddChild(fileMenu);

        // Connect signal for menu item pressed
        fileMenu.Connect("id_pressed", new Callable(this, nameof(OnMenuItemPressed)));
    }

    private void OnMenuItemPressed(int id)
    {
        switch (id)
        {
            case 1:
                GD.Print("New File");
                break;
            case 2:
                GD.Print("Open File");
                break;
            case 3:
                GD.Print("Save File");
                break;
            case 4:
                GetTree().Quit();
                break;
        }
    }
}
