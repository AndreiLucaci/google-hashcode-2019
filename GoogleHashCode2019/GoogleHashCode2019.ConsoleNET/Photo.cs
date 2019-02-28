using System.Collections.Generic;

namespace GoogleHashCode2019.ConsoleNET
{
	public class Photo : IPhoto
	{
        public Orientation Orientation { get; set; }
        public int NumberOfTags { get; set; }
        public HashSet<string> Tags { get; set; }
		public int Id { get; set; }

		public override bool Equals(object obj)
		{
			return Equals(obj as Photo);
		}

		public bool Equals(Photo other)
		{
			return other != null &&
				   Id == other.Id;
		}

		public override int GetHashCode()
		{
			return 2108858624 + Id.GetHashCode();
		}

		public int CompareTo(object obj)
		{
			return CompareTo(obj as IPhoto);
		}

		public static bool operator ==(Photo photo1, Photo photo2)
		{
			return EqualityComparer<Photo>.Default.Equals(photo1, photo2);
		}

		public static bool operator !=(Photo photo1, Photo photo2)
		{
			return !(photo1 == photo2);
		}

		public int CompareTo(IPhoto other)
		{
			if (ReferenceEquals(this, other)) return 0;
			if (ReferenceEquals(null, other)) return 1;
			return Id.CompareTo(other.Id);
		}
	}
}
