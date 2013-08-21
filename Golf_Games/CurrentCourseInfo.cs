using System;
using System.Collections;

namespace Golf_Games
{


	public class CurrentCourseInfo
	{
		//Data Members
		//General Information
		public string name;
		public string city;
		public int zip;

		//Scorecard info
		public CurrentHole[] holes = new CurrentHole[18];

	
		//Methods
		//Default Constructor
		public CurrentCourseInfo ()
		{
			name = "abc";
			city = "New York";
			zip = 99999;

			//Instantiate holes
			for (int i = 0; i < holes.Length; i++)
				holes [i] = new CurrentHole ();
			
		}
	}
}

