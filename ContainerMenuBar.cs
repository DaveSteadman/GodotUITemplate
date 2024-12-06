using Godot;
using System;

public partial class ContainerMenuBar : Container
{
    private MenuBar _menuBar;

    public override void _Ready()
    {
        // Create MenuBar
        _menuBar = new MenuBar();
        AddChild(_menuBar);
        ApplyStyle(_menuBar);

        // Apply "Top Wide" anchor preset to make the MenuBar span the top width
        //_menuBar.SetAnchorPreset(Control.LayoutPreset.Wide, Control.LayoutPresetMode.KeepPosition);
        //_menuBar.AnchorBottom = 0; // Ensure it's only at the top
        //_menuBar.OffsetTop = 0;

        // Enable horizontal expansion
        //_menuBar.SizeFlagsHorizontal = (int)Control.SizeFlags.Expand | (int)Control.SizeFlags.Fill;

        // Create menus
        FileMenuSetup();
        WindowMenuSetup();
    }

    // --------------------------------------------------------------------------------------------
    // MARK: Style
    // --------------------------------------------------------------------------------------------

    private void ApplyStyle(MenuBar menuBar)
    {
        menuBar.AnchorBottom = 0; // Ensure it's only at the top
        menuBar.OffsetTop = 0;

        // Set the style to include vertical lines
        menuBar.Theme = GD.Load<Theme>("res://Themes/MenuTheme.tres");
    }


    // --------------------------------------------------------------------------------------------
    // MARK: File Menu
    // --------------------------------------------------------------------------------------------

    private void FileMenuSetup()
    {
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
        fileMenu.Connect("id_pressed", new Callable(this, nameof(OnFileMenuItemPressed)));

    }

    private void OnFileMenuItemPressed(int id)
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

    // --------------------------------------------------------------------------------------------
    // MARK: Window Menu
    // --------------------------------------------------------------------------------------------

    private void WindowMenuSetup()
    {
        var windowMenu = new PopupMenu();
        windowMenu.Name = "Window";
        windowMenu.AddItem("Settings", 1);
        windowMenu.AddItem("Network", 2);
        windowMenu.AddItem("Command Line", 3);

        // Add the submenu to the MenuBar
        _menuBar.AddChild(windowMenu);

        // Connect signal for menu item pressed
        windowMenu.Connect("id_pressed", new Callable(this, nameof(OnWindowMenuItemPressed)));

    }

    private void OnWindowMenuItemPressed(int id)
    {
        switch (id)
        {
            case 1:
                GD.Print("Settings");
                break;
            case 2:
                GD.Print("Network");
                break;
            case 3:
                GD.Print("Command Line");
                break;
        }
    }

}
