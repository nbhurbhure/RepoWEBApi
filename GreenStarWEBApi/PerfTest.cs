using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NBench.Util;
using NBench;
using System.Web.Http;
using WebAPI.Controllers;

namespace GreenStarWEBApi
{
    public class PerfTest
    {
        [PerfBenchmark(Description = "Test to ensure that CityController is having optimal performance.",
            NumberOfIterations = 3, RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        [CounterThroughputAssertion("TestCounter", MustBe.GreaterThanOrEqualTo, 0.0d)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, 27800000)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]
        public void CityPerfTest()
        {
            CityController cc = new CityController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            cc.GetCitys();
        }


        [PerfBenchmark(Description = "Test to ensure that TeamWiseTrackingController is having optimal performance.",
           NumberOfIterations = 3, RunMode = RunMode.Throughput,
           RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        [CounterThroughputAssertion("TestCounter", MustBe.GreaterThanOrEqualTo, 0.0d)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, 27800000)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]
        public void TeamWiseTrackingControllerPerfTest()
        {
            TeamWiseTrackingController cc = new TeamWiseTrackingController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            cc.GetTeamWiseTrackings();
        }


        [PerfBenchmark(Description = "Test to ensure that IndividualTrackingController is having optimal performance.",
           NumberOfIterations = 3, RunMode = RunMode.Throughput,
           RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        [CounterThroughputAssertion("TestCounter", MustBe.GreaterThanOrEqualTo, 0.0d)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, 27800000)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]
        public void IndividualTrackingPerfTest()
        {
            IndividualTrackingController cc = new IndividualTrackingController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            cc.GetIndividualTrackings();
        }


        [PerfBenchmark(Description = "Test to ensure that ClassWiseTrackingController is having optimal performance.",
           NumberOfIterations = 3, RunMode = RunMode.Throughput,
           RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        [CounterThroughputAssertion("TestCounter", MustBe.GreaterThanOrEqualTo, 0.0d)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, 27800000)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]
        public void ClassWiseTrackingPerfTest()
        {
            ClassWiseTrackingController cc = new ClassWiseTrackingController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            cc.GetClassWiseTrackings();
        }

        [PerfBenchmark(Description = "Test to ensure that OutreachController is having optimal performance.",
           NumberOfIterations = 3, RunMode = RunMode.Throughput,
           RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        [CounterThroughputAssertion("TestCounter", MustBe.GreaterThanOrEqualTo, 0.0d)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, 27800000)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]
        public void OutreachPerfTest()
        {
            OutreachController cc = new OutreachController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            cc.GetOutreachs();
        }

        [PerfBenchmark(Description = "Test to ensure that ParameterController is having optimal performance.",
           NumberOfIterations = 3, RunMode = RunMode.Throughput,
           RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        [CounterThroughputAssertion("TestCounter", MustBe.GreaterThanOrEqualTo, 0.0d)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, 27800000)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]
        public void ParameterPerfTest()
        {
            ParameterController cc = new ParameterController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            cc.GetParameters();
        }



        //[PerfCleanup]
        //public void Cleanup()
        //{
        //    // does nothing
        //}
    }
}