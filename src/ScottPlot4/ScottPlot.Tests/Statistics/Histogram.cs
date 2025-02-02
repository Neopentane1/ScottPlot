﻿using FluentAssertions;
using NUnit.Framework;
using ScottPlot.Cookbook.Recipes.Plottable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottPlotTests.Statistics
{
    class Histogram
    {
        [Test]
        public void Test_Histogram_MatchesKnownValues1()
        {
            // Values generated with Python and Numpy (see hist.py)

            double[] values = SampleData.NORM_1000_12_34;

            double[] expectedEdges = {
                -25.0, -20.0, -15.0, -10.0, -5.0, 0.0, 5.0, 10.0, 15.0, 20.0, 25.0, 30.0,
                35.0, 40.0, 45.0, 50.0, 55.0, 60.0, 65.0, 70.0, 75.0, 80.0, 85.0, 90.0, 95.0, 100.0
            };

            double[] expectedCounts = {
                0, 0, 0, 0, 2, 7, 15, 35, 66, 111, 159, 165, 167,
                105, 84, 44, 25, 12, 3, 0, 0, 0, 0, 0, 0
            };

            double[] expectedDensities = {
                0.0, 0.0, 0.0, 0.0, 0.0004, 0.0014, 0.003, 0.007, 0.0132, 0.0222, 0.0318, 0.033, 0.0334, 0.021,
                0.0168, 0.0088, 0.005, 0.0024, 0.0006, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0
            };

            // test the static methods
            var (counts, binEdges) = ScottPlot.Statistics.Common.Histogram(values, binCount: 25, density: false, min: -25, max: 100);
            var (densities, _) = ScottPlot.Statistics.Common.Histogram(values, binCount: 25, density: true, min: -25, max: 100);
            binEdges.Should().HaveCount(expectedEdges.Length);
            counts.Should().HaveCount(expectedCounts.Length);
            densities.Should().HaveCount(expectedDensities.Length);
            densities.Should().Equal(expectedDensities);
        }

        [Test]
        public void Test_Histogram_MatchesKnownValues2()
        {
            // Values generated with Python and Numpy (see hist.py)

            double[] expectedEdges = {
                10.0, 10.4375, 10.875, 11.3125, 11.75, 12.1875, 12.625, 13.0625, 13.5, 13.9375, 14.375, 14.8125, 15.25,
                15.6875, 16.125, 16.5625, 17.0, 17.4375, 17.875, 18.3125, 18.75, 19.1875, 19.625, 20.0625, 20.5, 20.9375,
                21.375, 21.8125, 22.25, 22.6875, 23.125, 23.5625, 24.0, 24.4375, 24.875, 25.3125, 25.75, 26.1875, 26.625,
                27.0625, 27.5, 27.9375, 28.375, 28.8125, 29.25, 29.6875, 30.125, 30.5625, 31.0, 31.4375, 31.875, 32.3125,
                32.75, 33.1875, 33.625, 34.0625, 34.5, 34.9375, 35.375, 35.8125, 36.25, 36.6875, 37.125, 37.5625, 38.0,
                38.4375, 38.875, 39.3125, 39.75, 40.1875, 40.625, 41.0625, 41.5, 41.9375, 42.375, 42.8125, 43.25, 43.6875,
                44.125, 44.5625, 45.0 };

            double[] expectedCounts = {
                2, 3, 0, 1, 3, 3, 3, 2, 5, 4, 9, 4, 5, 3, 4, 7, 3, 8, 5, 7, 4, 7, 10, 10, 6, 7, 9, 6, 11, 12, 12, 11, 14,
                11, 10, 11, 19, 10, 10, 6, 18, 11, 18, 13, 25, 10, 17, 10, 15, 14, 10, 20, 14, 19, 10, 20, 14, 11, 9, 15,
                15, 14, 15, 17, 14, 22, 13, 16, 8, 10, 9, 9, 7, 14, 8, 6, 13, 9, 14, 5
            };

            double[] expectedDensities = {
                0.005657708628005657, 0.008486562942008486, 0.0, 0.0028288543140028285, 0.008486562942008486, 0.008486562942008486,
                0.008486562942008486, 0.005657708628005657, 0.014144271570014145, 0.011315417256011314, 0.02545968882602546,
                0.011315417256011314, 0.014144271570014145, 0.008486562942008486, 0.011315417256011314, 0.019801980198019802,
                0.008486562942008486, 0.022630834512022628, 0.014144271570014145, 0.019801980198019802, 0.011315417256011314,
                0.019801980198019802, 0.02828854314002829, 0.02828854314002829, 0.016973125884016973, 0.019801980198019802,
                0.02545968882602546, 0.016973125884016973, 0.031117397454031116, 0.033946251768033946, 0.033946251768033946,
                0.031117397454031116, 0.039603960396039604, 0.031117397454031116, 0.02828854314002829, 0.031117397454031116,
                0.05374823196605375, 0.02828854314002829, 0.02828854314002829, 0.016973125884016973, 0.05091937765205092,
                0.031117397454031116, 0.05091937765205092, 0.036775106082036775, 0.07072135785007072, 0.02828854314002829,
                0.048090523338048086, 0.02828854314002829, 0.042432814710042434, 0.039603960396039604, 0.02828854314002829,
                0.05657708628005658, 0.039603960396039604, 0.05374823196605375, 0.02828854314002829, 0.05657708628005658,
                0.039603960396039604, 0.031117397454031116, 0.02545968882602546, 0.042432814710042434, 0.042432814710042434,
                0.039603960396039604, 0.042432814710042434, 0.048090523338048086, 0.039603960396039604, 0.06223479490806223,
                0.036775106082036775, 0.045261669024045256, 0.022630834512022628, 0.02828854314002829, 0.02545968882602546,
                0.02545968882602546, 0.019801980198019802, 0.039603960396039604, 0.022630834512022628, 0.016973125884016973,
                0.036775106082036775, 0.02545968882602546, 0.039603960396039604, 0.014144271570014145
            };

            // test the static methods
            double[] values = SampleData.NORM_1000_12_34;
            var (counts, binEdges) = ScottPlot.Statistics.Common.Histogram(values, binCount: 80, density: false, min: 10, max: 45);
            var (densities, _) = ScottPlot.Statistics.Common.Histogram(values, binCount: 80, density: true, min: 10, max: 45);
            binEdges.Should().HaveCount(expectedEdges.Length);
            counts.Should().HaveCount(expectedCounts.Length);
            densities.Should().HaveCount(expectedDensities.Length);
            for (int i = 0; i < densities.Length; i++)
            {
                densities[i].Should().BeApproximately(expectedDensities[i], precision: 1e-10);
            }
        }

        [Test]
        [Obsolete]
        public void Test_Histogram_jwsuh()
        {
            // https://github.com/ScottPlot/ScottPlot/issues/1348

            var values = new double[] { 10, 20, 20, 10, 20, 10, 20, 10, 10, 20, 10, 10, 20, 15, 10, 30 };
            var (counts, binEdges) = ScottPlot.Statistics.Common.Histogram(values, 15, 30, 1, false);

            Console.WriteLine("Counts:" + String.Join(", ", counts.Select(x => x.ToString())));
            Console.WriteLine("Edges:" + String.Join(", ", binEdges.Select(x => x.ToString())));
        }

        [Test]
        public void Test_Histogram_IgnoringOutliers()
        {
            ScottPlot.Statistics.Histogram hist = new(min: 100, max: 200, binCount: 5, addOutliersToEdgeBins: false, addFinalBin: false);

            hist.Min.Should().Be(100);
            hist.Max.Should().Be(200);
            hist.Bins.First().Should().Be(100);
            hist.Bins.Last().Should().Be(180);

            hist.Bins.Should().BeEquivalentTo(new double[] { 100, 120, 140, 160, 180 });
            hist.Counts.Should().BeEquivalentTo(new double[] { 0, 0, 0, 0, 0 });

            hist.Add(123);
            hist.Counts.Should().BeEquivalentTo(new double[] { 0, 1, 0, 0, 0 });

            hist.Add(173);
            hist.Counts.Should().BeEquivalentTo(new double[] { 0, 1, 0, 1, 0 });

            hist.Add(123);
            hist.Counts.Should().BeEquivalentTo(new double[] { 0, 2, 0, 1, 0 });

            hist.Sum.Should().Be(123 + 173 + 123);

            hist.Clear();
            hist.Counts.Should().BeEquivalentTo(new double[] { 0, 0, 0, 0, 0 });

            hist.Add(50);
            hist.Counts.Should().BeEquivalentTo(new double[] { 0, 0, 0, 0, 0 });

            hist.Add(250);
            hist.Counts.Should().BeEquivalentTo(new double[] { 0, 0, 0, 0, 0 });

            hist.Sum.Should().Be(0);
        }

        [Test]
        public void Test_Histogram_IncludingOutliers()
        {
            ScottPlot.Statistics.Histogram hist = new(min: 100, max: 200, binCount: 5, addOutliersToEdgeBins: true, addFinalBin: false);

            hist.Counts.Should().BeEquivalentTo(new double[] { 0, 0, 0, 0, 0 });

            hist.Add(50);
            hist.Counts.Should().BeEquivalentTo(new double[] { 1, 0, 0, 0, 0 });

            hist.Add(250);
            hist.Counts.Should().BeEquivalentTo(new double[] { 1, 0, 0, 0, 1 });

            hist.Sum.Should().Be(50 + 250);
        }

        [Test]
        public void Test_Histogram_Normalization()
        {
            ScottPlot.Statistics.Histogram hist = new(min: 100, max: 200, binCount: 5, addFinalBin: false);

            hist.Add(125);
            hist.Add(145);
            hist.Add(145);
            hist.Add(165);
            hist.Counts.Should().BeEquivalentTo(new double[] { 0, 1, 2, 1, 0 });

            hist.GetProbability().Should().BeEquivalentTo(new double[] { 0, .25, .5, .25, 0 });

            hist.GetNormalized().Should().BeEquivalentTo(new double[] { 0, .5, 1, .5, 0 });

            hist.GetNormalized(256).Should().BeEquivalentTo(new double[] { 0, 128, 256, 128, 0 });
        }

        [Test]
        public void Test_Histogram_CPH()
        {
            ScottPlot.Statistics.Histogram hist = new(min: 100, max: 200, binCount: 5, addFinalBin: false);

            hist.Add(125);
            hist.Add(145);
            hist.Add(145);
            hist.Add(165);
            hist.Counts.Should().BeEquivalentTo(new double[] { 0, 1, 2, 1, 0 });

            hist.GetCumulative().Should().BeEquivalentTo(new double[] { 0, 1, 3, 4, 4 });

            hist.GetCumulativeProbability().Should().BeEquivalentTo(new double[] { 0, .25, .75, 1, 1 });
        }

        [Test]
        [Obsolete]
        public void Test_Histogram_FixedSizeBins()
        {
            // This test reproduces issue described by @Xerxes004 in #2299
            // https://github.com/ScottPlot/ScottPlot/issues/2299

            double[] data = { 1.0, 2.0, 3.0 };
            double binSize = 1.5;
            double[] expectedBins = { 1.0, 2.5, 4.0 };
            double min = data.Min();
            double max = data.Max();

            // Test old static methods
            (_, double[] bins1) = ScottPlot.Statistics.Common.Histogram(data, min, max, binSize);
            bins1.Should().BeEquivalentTo(expectedBins);
            (_, double[] bins2, _, _) = ScottPlot.Statistics.Common.HistogramWithOutliers(data, min, max, binSize);
            bins2.Should().BeEquivalentTo(expectedBins);
        }

        [Test]
        public void Test_Histogram_FixedBinSize()
        {
            // Extending conversation in #2403, this test confirms bins meet expectations
            // https://github.com/ScottPlot/ScottPlot/issues/2403

            var hist1 = ScottPlot.Statistics.Histogram.WithFixedBinSize(min: 0, max: 10, binSize: 1);

            hist1.BinSize.Should().Be(1);

            hist1.Bins.Should().BeEquivalentTo(new double[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            hist1.Counts.Should().BeEquivalentTo(new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });

            hist1.Add(10); // since bins are max-exclusive, this counts as an outlier
            hist1.Counts.Should().BeEquivalentTo(new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 });
        }

        [Test]
        public void Test_Histogram_FixedBinCount()
        {
            // Extending conversation in #2403, this test confirms bins meet expectations
            // https://github.com/ScottPlot/ScottPlot/issues/2403

            var hist1 = ScottPlot.Statistics.Histogram.WithFixedBinCount(min: 0, max: 10, binCount: 10);

            hist1.BinSize.Should().Be(1);

            hist1.Bins.Should().BeEquivalentTo(new double[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            hist1.Counts.Should().BeEquivalentTo(new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });

            hist1.Add(10); // since bins are max-exclusive, this counts as an outlier
            hist1.Counts.Should().BeEquivalentTo(new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 });
        }
    }
}
