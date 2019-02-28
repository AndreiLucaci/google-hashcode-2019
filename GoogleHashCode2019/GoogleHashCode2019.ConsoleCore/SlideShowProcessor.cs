using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using GoogleHashCode2019.ConsoleNET;

namespace GoogleHashCode2019.ConsoleCore
{
	public class SlideShowProcessor
    {
	    public IEnumerable<IEnumerable<ISlide>> SimpleGrouping(ICollection<ISlide> slids)
	    {
		    return slids
			    .Select((x, i) => new { Index = i, Value = x })
			    .GroupBy(x => x.Index / 2)
			    .Select(x => x.Select(v => v.Value).ToList())
			    .ToList();
	    }
	}
}
