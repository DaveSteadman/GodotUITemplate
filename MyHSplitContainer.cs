using Godot;

public partial class MyHSplitContainer : HSplitContainer
{
    [Export] public bool  FixLeftSize { get; set; } = true;
    [Export] public float LeftSize    { get; set; } = 200.0f;

    private float _recordedLeftWidth = 200f;

    // --------------------------------------------------------------------------------------------
    // MARK: Node functions
    // --------------------------------------------------------------------------------------------

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        this.Connect(Control.SignalName.Resized,        new Callable(this, nameof(OnResized)));
        this.Connect(SplitContainer.SignalName.Dragged, new Callable(this, nameof(OnDragged)));
    }

    public override void _Process(double delta)
    {
        // Per-frame logic if needed
    }

    // --------------------------------------------------------------------------------------------
    // MARK: User Interaction
    // --------------------------------------------------------------------------------------------

    private void OnResized()
    {
        // Ensure sizing logic is enforced immediately after layout updates
        EnforceSizingLogic();
    }

    private void OnDragged(int offset)
    {
        // Record the new size immediately after dragging
        RecordLeftSize();
    }

    // --------------------------------------------------------------------------------------------
    // MARK: Resize functions
    // --------------------------------------------------------------------------------------------

    private void RecordLeftSize()
    {
        // If the container has at least two children, print their sizes
        if (this.GetChildCount() >= 2)
        {
            Control leftChild  = this.GetChild<Control>(0);
            //Control rightChild = this.GetChild<Control>(1);

            _recordedLeftWidth  = leftChild.Size.X;
        }
    }

    private void EnforceSizingLogic()
    {
        if (FixLeftSize)
        {
            // If the container has at least two children, print their sizes
            if (this.GetChildCount() >= 2)
            {
                Control leftChild  = this.GetChild<Control>(0);
                Control rightChild = this.GetChild<Control>(1);

                // Get the overall width of the HSplitContainer
                float newLeftWidth  = leftChild.Size.X;
                float newRightWidth = rightChild.Size.X;
                float newTotalWidth = newLeftWidth + newRightWidth;

                // Determine the new split offset to re-establish the split offset
                float newSplitOffset = _recordedLeftWidth - (newTotalWidth / 2f);

                this.SplitOffset = (int)newSplitOffset;

                GD.Print($"Enforcing Left Child Width: {(int)newSplitOffset}");
            }
        }
    }
}
