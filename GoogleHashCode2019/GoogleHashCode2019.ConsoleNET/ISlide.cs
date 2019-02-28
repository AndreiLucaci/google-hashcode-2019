using System.Collections.Generic;

namespace GoogleHashCode2019.ConsoleNET
{
	public interface ISlide
	{
		List<Photo> Photos { get; }
		HashSet<string> Tags { get; }
	}
}