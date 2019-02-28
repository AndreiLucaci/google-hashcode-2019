using System.Linq;

namespace GoogleHashCode2019.ConsoleNET
{
	public class InterestFactorProcessor
	{
		public int InterestFactor(ISlide firstSlide, ISlide secondSlide)
		{
			var commonTags = firstSlide.Tags.Intersect(secondSlide.Tags).ToArray();
			var leftOuterJoinExcluded = firstSlide.Tags.Except(secondSlide.Tags).ToArray();
			var rightOuterJoinExluded = secondSlide.Tags.Except(firstSlide.Tags).ToArray();

			return new[] { commonTags.Length, leftOuterJoinExcluded.Length, rightOuterJoinExluded.Length }.Min();
		}
	}
}
