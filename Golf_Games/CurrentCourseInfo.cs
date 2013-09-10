using System;
using System.Collections;
using System.Xml;


namespace Golf_Games
{


	public class CurrentCourseInfo
	{
		//Data Members
		//General Information
		public string name;
		public string city;
		public int zip;

		//The index of the selected course at menu 2.
		public int courseIndex;

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

		public bool FindCourseByID(int entryID)
		{
			bool match_flag = false;
			//Read xml and fill the course using an entry ID number.
			XmlTextReader reader = new XmlTextReader ("Courses/Courses.xml");

			while (reader.Read() && match_flag == false) 
			{
				if (reader.NodeType == XmlNodeType.Element) 
				{
					if (reader.Name == "EntryID") 
					{
						reader.Read ();
						if(Convert.ToInt32(reader.Value) == entryID)
							BuildCourse (reader);

					}
				}
			}

			return true;
		}

		private bool BuildCourse(XmlTextReader reader)
		{
			int holeIndex = 0;
			while (reader.NodeType != XmlNodeType.EndElement || reader.Name !="Course") 
			{
				if (reader.NodeType == XmlNodeType.Element) 
				{
					switch (reader.Name) 
					{
					case "Name":
						reader.Read ();
						this.name = reader.Value;
						break;

					case "City":
						reader.Read ();
						this.city = reader.Value;
						break;

					case "Zip":
						reader.Read();
						this.zip = Convert.ToInt32(reader.Value);
						break;

					case "Hole":
						BuildHole (reader, holeIndex);
						holeIndex++;
						break;

					default:
						break;
					}

				}

				//Move to next element
				reader.Read ();
			}

			return true;
		}

		private void BuildHole(XmlTextReader reader, int holeIndex)
		{

			//Look for the information about the hole.
			while (reader.NodeType != XmlNodeType.EndElement || reader.Name != "Hole") 
			{
				//Move to the next element
				reader.Read ();

				if (reader.NodeType == XmlNodeType.Element) 
				{
					switch (reader.Name) {
					case "HoleNumber":
						reader.Read ();
						this.holes [holeIndex].holeNum = Convert.ToInt32 (reader.Value);
						break;

					case "Par":
						reader.Read ();
						this.holes [holeIndex].par = Convert.ToInt32 (reader.Value);
						break;

					case "Handicap":
						reader.Read ();
						this.holes [holeIndex].hole_handicap = Convert.ToInt32 (reader.Value);
						break;
					}
				}
			}
		}
	}
}

