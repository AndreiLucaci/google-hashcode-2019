using System;
using System.Collections.Generic;

namespace GoogleHashCode2019.ConsoleNET
{
	public interface IPhoto : IEquatable<Photo>, IComparable
	{
		int Id { get; set; }
		int NumberOfTags { get; set; }
		Orientation Orientation { get; set; }
		HashSet<string> Tags { get; set; }
	}
}