using System;

public class Step
{

	public Step(StepAction a)
	{
       
	}

    enum StepAction
    {
        OverlapFill, BackkFill, FrontFill, GapFill
    }

    public int TableIndex { get; }
    public SegmentLayout Layout { get; }

    public StepAction Action { get; }
    public string Before { get; }
    public string After { get; }
}
