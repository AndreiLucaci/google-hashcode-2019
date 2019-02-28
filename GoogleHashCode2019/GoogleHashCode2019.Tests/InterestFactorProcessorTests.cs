using System;
using System.Collections.Generic;
using GoogleHashCode2019.ConsoleNET;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GoogleHashCode2019.Tests
{
	[TestClass]
	public class InterestFactorProcessorTests
	{
		private InterestFactorProcessor sut;

		[TestInitialize]
		public void Initialize()
		{
			sut = new InterestFactorProcessor();
		}

		[TestMethod]
		public void InterestFactor_SlidesWithOneCommonTag_OutputsCorrectInformation()
		{
			// arrange
			var slide1Mock = new Mock<ISlide>();
			slide1Mock.Setup(x => x.Tags).Returns(new HashSet<string>(new [] {"garden", "cat"}));

			var slide2Mock = new Mock<ISlide>();
			slide2Mock.Setup(x => x.Tags).Returns(new HashSet<string>(new [] {"selfie", "smile", "garden"}));

			// act
			var result = sut.InterestFactor(slide1Mock.Object, slide2Mock.Object);

			// assert
			Assert.AreEqual(1, result);
		}

		[TestMethod]
		public void InterestFactor_SlidesWithNoCommonTags_OutputsCorrectInformation()
		{
			// arrange
			var slide1Mock = new Mock<ISlide>();
			slide1Mock.Setup(x => x.Tags).Returns(new HashSet<string>(new [] {"garden", "cat"}));

			var slide2Mock = new Mock<ISlide>();
			slide2Mock.Setup(x => x.Tags).Returns(new HashSet<string>(new [] {"selfie", "smile", "garden1"}));

			// act
			var result = sut.InterestFactor(slide1Mock.Object, slide2Mock.Object);

			// assert
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void InterestFactor_SlidesMinimumOne_OutputsCorrectInformation()
		{
			// arrange
			var slide1Mock = new Mock<ISlide>();
			slide1Mock.Setup(x => x.Tags).Returns(new HashSet<string>(new [] { "desk", "cat", "selfie", "room" }));

			var slide2Mock = new Mock<ISlide>();
			slide2Mock.Setup(x => x.Tags).Returns(new HashSet<string>(new [] { "room", "selfie", "tree" }));

			// act
			var result = sut.InterestFactor(slide1Mock.Object, slide2Mock.Object);

			// assert
			Assert.AreEqual(1, result);
		}

		[TestMethod]
		public void InterestFactor_SlidesWithAllTagsCommon_OutputsCorrectInformation()
		{
			// arrange
			var slide1Mock = new Mock<ISlide>();
			slide1Mock.Setup(x => x.Tags).Returns(new HashSet<string>(new [] {"garden", "cat"}));

			var slide2Mock = new Mock<ISlide>();
			slide2Mock.Setup(x => x.Tags).Returns(new HashSet<string>(new [] {"cat", "garden"}));

			// act
			var result = sut.InterestFactor(slide1Mock.Object, slide2Mock.Object);

			// assert
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void InterestFactor_SlidesWithCommonTags_OutputsCorrectInformation()
		{
			// arrange
			var slide1Mock = new Mock<ISlide>();
			slide1Mock.Setup(x => x.Tags).Returns(new HashSet<string>(new [] {"desk", "cat", "selfie", "room"}));

			var slide2Mock = new Mock<ISlide>();
			slide2Mock.Setup(x => x.Tags).Returns(new HashSet<string>(new [] {"room", "selfie", "tree", "pool", "garden"}));

			// act
			var result = sut.InterestFactor(slide1Mock.Object, slide2Mock.Object);

			// assert
			Assert.AreEqual(2, result);
		}
	}
}
