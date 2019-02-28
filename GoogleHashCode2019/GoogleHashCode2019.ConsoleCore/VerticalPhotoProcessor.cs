using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace GoogleHashCode2019.ConsoleNET
{
	public class VerticalPhotoProcessor
	{
		public IEnumerable<ISlide> ProcessPhotos(ICollection<IPhoto> photos)
		{
			return SimpleGrouping(photos).Select(i => new Slide(i));
		}

		private IEnumerable<IEnumerable<T>> Combinations<T>(ICollection<T> list, int length) 
			where T : IComparable
		{
			return
				length == 1
					? list.Select(t => new[] {t})
					: Combinations(list, length - 1).SelectMany(t => list.Where(o => o.CompareTo(t.Last()) > 0),
						(t1, t2) => t1.Concat(new T[] {t2}));
		}

		private IEnumerable<IEnumerable<T>> Combinations1<T>(ImmutableStack<T> source, int k) 
			where T : IComparable
		{
			if (k == 0 || source.IsEmpty)
				return Enumerable.Repeat(Enumerable.Empty<T>(), 1);
			if (k < 0 || source.IsEmpty)
				return Enumerable.Empty<IEnumerable<T>>();

			var haveNots = Combinations1(source.Pop(), k);
			var element = source.Take(1);
			var smallerHaveNots = Combinations1(source.Pop(), k - 1);
			var haves = smallerHaveNots.Select(set => element.Concat(set));
			return haves.Concat(haveNots);
		}

		private IEnumerable<IEnumerable<IPhoto>> Process(ICollection<IPhoto> photos)
		{
			if (photos.Count() == 2)
			{
				yield return photos;
			}
			else
			{
				for (var i = 0; i < photos.Count / 2 - 1; i++)
				{
					
				}
			}

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
