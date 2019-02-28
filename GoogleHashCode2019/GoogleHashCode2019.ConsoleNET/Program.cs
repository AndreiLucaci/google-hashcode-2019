using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickGraph;

namespace GoogleHashCode2019.ConsoleNET
{
	class Program
	{
		static void Main(string[] args)
		{
			var photos = new List<IPhoto>();

			using (var streamReader = new StreamReader("e_shiny_selfies.txt"))
			{
				string headerLine = streamReader.ReadLine();
				var numberOfPhotos = long.Parse(headerLine);

				string line;
				int counter = 1;
				while ((line = streamReader.ReadLine()) != null)
				{
					var splits = line.Split(' ');
					var orientation = splits[0];
					var numberOfTags = splits[1];
					var tags = new HashSet<string>();
					foreach (var split in splits.Skip(2))
					{
						tags.Add(split);
					}

					photos.Add(new Photo
					{
						Orientation = orientation == "H" ? Orientation.Horizontal : Orientation.Vertical,
						NumberOfTags = int.Parse(numberOfTags),
						Tags = tags,
						Id = counter++
					});
				}
			}

			var vP = new VerticalPhotoProcessor();

			var horizontalPhotos = photos.Where(i => i.Orientation == Orientation.Horizontal).ToList();
			var verticalPhotos = photos.Except(horizontalPhotos).ToList();

			var horizontalSlides = horizontalPhotos.Select(x => new Slide(new[] {x}));
			var verticalSlides = vP.ProcessPhotos(verticalPhotos.ToList());

			var slides = horizontalSlides.Concat(verticalSlides);

			var graph = slides.ToUndirectedGraph<>();
		}
	}
}
