﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackExchange.Opserver.Data.Dashboard
{
    public partial class Volume
    {
        public class VolumeUtilization : GraphPoint
        {
            public override long DateEpoch { get; set; }
            public double AvgDiskUsed { get; internal set; }

            public override double? Value => AvgDiskUsed;
        }

        public class VolumeQueueLength : GraphPoint
        {
            public override long DateEpoch { get; set; }
            public double AvgQueueLength { get; internal set; }

            public override double? Value => AvgQueueLength;
        }

        public class VolumeLatency : GraphPoint
        {
            public override long DateEpoch { get; set; }
            public double AvgSecPerTransfer { get; internal set; }

            public override double? Value => AvgSecPerTransfer;
        }

        public class VolumePerformanceUtilization : DoubleGraphPoint
        {
            public override long DateEpoch { get; set; }
            public float? AvgReads { get; internal set; }
            public float? AvgWrites { get; internal set; }

            public override double? Value => AvgReads;
            public override double? BottomValue => AvgWrites;
        }

        /// <summary>
        /// Gets usage for this volume (optionally) for the given time period, optionally sampled if pointCount is specified
        /// </summary>
        /// <param name="start">Start date, unbounded if null</param>
        /// <param name="end">End date, unbounded if null</param>
        /// <param name="pointCount">Points to return, if specified results will be sampled rather than including every point</param>
        /// <returns>Volume usage data points</returns>
        public Task<List<GraphPoint>> GetVolumeUtilization(DateTime? start, DateTime? end, int? pointCount = null)
        {
            return Node.DataProvider.GetUtilizationAsync(this, start, end, pointCount);
        }

        /// <summary>
        /// Gets I/O utilization for this volume (optionally) for the given time period, optionally sampled if pointCount is specified
        /// </summary>
        /// <param name="start">Start date, unbounded if null</param>
        /// <param name="end">End date, unbounded if null</param>
        /// <param name="pointCount">Points to return, if specified results will be sampled rather than including every point</param>
        /// <returns>Volume usage data points</returns>
        public Task<List<DoubleGraphPoint>> GetPerformanceUtilization(DateTime? start, DateTime? end, int? pointCount = null)
        {
            return Node.DataProvider.GetPerformanceUtilizationAsync(this, start, end, pointCount);
        }
    }
}