using Godot;
using System;

public partial class PanelContainer : Godot.PanelContainer
{
    public override void _Ready()
    {
        // Create a Tree node
        var tree = new Tree();

        // Configure the Tree node
        tree.SizeFlagsHorizontal = Control.SizeFlags.Expand | Control.SizeFlags.Fill;
        tree.SizeFlagsVertical   = Control.SizeFlags.Expand | Control.SizeFlags.Fill;
        tree.Columns = 2; // Add an extra column for the toggle icon
        tree.SetColumnExpand(0, true); // Expand the first column
        tree.SetColumnExpand(1, false); // Do not expand the second column

        // Add the Tree to the Panel
        AddChild(tree);

        // Set the style to include vertical lines
        ApplyExplorerStyle(tree);

        // Populate the Tree with items and icons
        PopulateTree(tree);
    }

    private void PopulateTree(Tree tree)
    {
        // Get the root of the Tree
        TreeItem root = tree.CreateItem();
        root.SetText(0, "Root");

        // Add child items with toggleable icons
        var child1 = CreateItemWithToggle(tree, root, "Item 1");
        var child2 = CreateItemWithToggle(tree, root, "Item 2");
        var child3 = CreateItemWithToggle(tree, root, "Item 3");
        var child4 = CreateItemWithToggle(tree, root, "Item 4");
        var child5 = CreateItemWithToggle(tree, root, "Item 5");

        // Add a sub-item with a toggleable icon
        var subItem1 = CreateItemWithToggle(tree, child1, "Sub-item 1.1");
        var subItem3 = CreateItemWithToggle(tree, child3, "Sub-item 3.1");
    }

    private TreeItem CreateItemWithToggle(Tree tree, TreeItem parent, string text)
    {
        var item = tree.CreateItem(parent);
        item.SetText(0, text);

        // Set the initial "eye" icon in the second column
        var visibleIcon = GetIcon("Visible");
        item.SetIcon(1, visibleIcon);

        // Align the icon to the right in the second column
        //item.SetTextAlign(1, TreeItem.TextAlign.Right);

        return item;
    }

    private Texture2D GetIcon(string iconName)
    {
        // Load icons from Godot's built-in theme or custom resources
        var iconPath = iconName == "Visible" ? "res://Icons/eye_open.png" : "res://Icons/eye_closed.png";

        // Load the original texture
        var original = GD.Load<Texture2D>(iconPath);
        if (original == null)
        {
            GD.PrintErr($"Failed to load texture at path: {iconPath}");
            return null;
        }

        // Get the Image from the original texture
        var image = original.GetImage();
        if (image == null)
        {
            GD.PrintErr("Failed to retrieve image from texture.");
            return original; // fallback
        }

        // Resize the image down to 20x20 using linear interpolation
        image.Resize(20, 20, Image.Interpolation.Bilinear);

        // Create a new ImageTexture from the resized image
        var resizedTexture = ImageTexture.CreateFromImage(image);

        return resizedTexture;
    }

    private void ApplyExplorerStyle(Tree tree)
    {
        // Create a custom theme for the Tree
        var theme = new Theme();

        // Create a StyleBoxLine for vertical lines
        var verticalLineStyle = new StyleBoxLine();
        verticalLineStyle.Color = new Color(0.7f, 0.7f, 0.7f); // Light gray
        verticalLineStyle.Thickness = 1;

        // Set the custom style for "lines" in the Tree
        theme.SetStylebox("lines", "Tree", verticalLineStyle);

        // Apply the theme to the Tree
        tree.Theme = theme;

        tree.FocusMode = FocusModeEnum.None;

    }
}



