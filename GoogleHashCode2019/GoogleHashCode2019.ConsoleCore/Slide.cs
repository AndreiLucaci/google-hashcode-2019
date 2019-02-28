using System.Collections.Generic;
using System.Linq;

namespace GoogleHashCode2019.ConsoleNET
{
	public class Slide : ISlide
	{
		public List<IPhoto> Photos { get; }
		public HashSet<string> Tags { get; } = new HashSet<string>();

		public Slide(IEnumerable<IPhoto> photos)
		{
			Photos = photos.ToList();

			ProcessPhotos();
		}

		private void ProcessPhotos()
		{
			foreach (var photo in Photos)
			{
				// add tags
				foreach (var tag in photo.Tags)
				{
					Tags.Add(tag);
				}
			}
		}
	}
}
