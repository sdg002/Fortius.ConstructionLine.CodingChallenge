using System;
using System.Collections.Generic;
using System.Diagnostics;
using ConstructionLine.CodingChallenge.Tests.SampleData;
using NUnit.Framework;

namespace ConstructionLine.CodingChallenge.Tests
{
    [TestFixture]
    public class FasterSearchEnginePerformanceTests : SearchEngineTestsBase
    {
        private List<Shirt> _shirts;
        private FasterSearchEngine _searchEngine;

        private const int ExpectedPerformance = 100;
        private const int CountOfShirts = 1000000;

        [SetUp]
        public void Setup()

        {
            var dataBuilder = new SampleDataBuilder(CountOfShirts);

            _shirts = dataBuilder.CreateShirts();

            _searchEngine = new FasterSearchEngine(_shirts);
        }

        [Test]
        public void PerformanceTest()
        {
            var sw = new Stopwatch();
            sw.Start();

            var options = new SearchOptions
            {
                Colors = new List<Color> { Color.Red }
            };

            var results = _searchEngine.Search(options);

            sw.Stop();
            Console.WriteLine($"Test fixture finished in {sw.ElapsedMilliseconds} milliseconds");
            Assert.That(sw.ElapsedMilliseconds, Is.LessThan(ExpectedPerformance));

            AssertResults(results.Shirts, options);
            AssertSizeCounts(_shirts, options, results.SizeCounts);
            AssertColorCounts(_shirts, options, results.ColorCounts);
        }
    }
}