using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GoogleHashCode2019.ConsoleNET;
using QuickGraph;

namespace GoogleHashCode2019.ConsoleCore
{
    class Program
    {
        static void Main(string[] args)
        {
	        var inputData = new[]
	        {
		        "a_example.txt", "b_lovely_landscapes.txt", "c_memorable_moments.txt", "d_pet_pictures.txt",
				"e_shiny_selfies.txt"
			};

	        foreach (var fileName in inputData)
	        {
		        GenerateSolution(fileName);
			}
		}

	    private static void GenerateSolution(string fileName)
	    {
		    var photos = new List<IPhoto>();

		    using (var streamReader = new StreamReader(fileName))
		    {
			    string headerLine = streamReader.ReadLine();
			    var numberOfPhotos = long.Parse(headerLine);

			    string line;
			    int counter = 0;
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

		    var slides = horizontalSlides.Concat(verticalSlides).ToList();

			var shuffleScores = new Dictionary<int, List<ISlide>>();

			var slideShowProcessor = new SlideShowProcessor();

			var interestProcessor = new InterestFactorProcessor();

		    var noShuffleGrouping = slideShowProcessor.SimpleGrouping(slides).ToList();
			var noShuffleScore = noShuffleGrouping.Select(x => interestProcessor.InterestFactor(x.First(), x.Last())).Sum();

		    shuffleScores[noShuffleScore] = slides;

			for (var i = 0; i < 50; i++)
		    {
			    slides.Shuffle();

			    var tempSlides = slides.ToList();

			    var groups = slideShowProcessor.SimpleGrouping(tempSlides);

			    var score = groups.Select(x => interestProcessor.InterestFactor(x.First(), x.Last())).Sum();

			    shuffleScores[score] = tempSlides;
		    }

		    var maxKey = shuffleScores.Keys.Max();

		    ToOutput(shuffleScores[maxKey], "out_" + fileName);
	    }

	    private static void ToOutput(ICollection<ISlide> slides, string outFileName)
	    {
		    using (var sw = new StreamWriter(outFileName))
		    {
			    sw.WriteLine(slides.Count());
			    foreach (var i in slides)
			    {
				    sw.WriteLine(string.Join(" ", i.Photos.Select(x => x.Id)));
			    }
		    }
	    }
    }
}
