using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleHashCode2019.ConsoleNET
{
	public class VerticalPhotoProcessor
	{
		public IEnumerable<ISlide> ProcessPhotos(ICollection<IPhoto> photos)
		{
			return SimpleGrouping(photos).Select(i => new Slide(i));
		}

		private IEnumerable<IEnumerable<IPhoto>> SimpleGrouping(ICollection<IPhoto> photos)
		{
			return photos
				.Select((x, i) => new { Index = i, Value = x })
				.GroupBy(x => x.Index / 2)
				.Select(x => x.Select(v => v.Value).ToList())
				.ToList();
		}
	}
}
