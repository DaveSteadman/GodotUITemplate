using Godot;
using System;

public partial class PanelContainer : Godot.PanelContainer
{
    public override void _Ready()
    {
        // Create a Tree node
        var tree = new Tree();

        // Configure the Tree node
        // tree.SizeFlagsHorizontal = (int)Control.SizeFlags.Expand | (int)Control.SizeFlags.Fill;
        // tree.SizeFlagsVertical   = (int)Control.SizeFlags.Expand | (int)Control.SizeFlags.Fill;

        // Add the Tree as a child of the Panel
        AddChild(tree);

        // Populate the Tree with some example items
        PopulateTree(tree);
    }

    private void PopulateTree(Tree tree)
    {
        // Get the root of the Tree
        TreeItem root = tree.CreateItem();

        // Add child items to the root
        var child1 = tree.CreateItem(root);
        child1.SetText(0, "Item 1");

        var child2 = tree.CreateItem(root);
        child2.SetText(0, "Item 2");

        // Add sub-items to one of the children
        var subItem = tree.CreateItem(child1);
        subItem.SetText(0, "Sub-item 1.1");
    }
}
