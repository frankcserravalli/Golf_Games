using System;

namespace Golf_Games
{
	public class CurrentHole
	{
		//Data members
		public int holeNum;
		public int par;
		public int hole_handicap;
		public SideBetInfo sideBetInfo;

		public CurrentHole ()
		{
			holeNum = 1;
			par = 4;
			hole_handicap = 1;
			sideBetInfo = new SideBetInfo (); 
		}
	}
}

