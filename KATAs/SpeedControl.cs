using System;
using System.Collections.Generic;
using System.Text;

namespace KATAs
{
    public class SpeedControl
    {
        public static int GetMaxAverageSpeedPerHour(int seconds, double[] distanceSamples)
        {
            int result = 0;

            if (distanceSamples.Length < 2)
            {
                return 0;
            }

            double[] distanceSegments = GetDistanceSegments(distanceSamples);

            int[] segmentsAverageSpeeds = GetSegmentsAverageSpeeds(distanceSegments, seconds);

            foreach (int speed in segmentsAverageSpeeds)
            {
                if (speed > result)
                {
                    result = speed;
                }
            }

            return result;
        }

        public static int[] GetSegmentsAverageSpeeds(double[] distanceSegments, int seconds)
        {
            int[] averageSpeedOfEachSegment = new int[distanceSegments.Length];

            for (int i = 0; i < distanceSegments.Length; ++i)
            {
                averageSpeedOfEachSegment[i] = (int)Math.Floor((3600 * distanceSegments[i]) / seconds);
            }

            return averageSpeedOfEachSegment;
        }

        public static double[] GetDistanceSegments(double[] distanceSamples)
        {
            double[] distanceSegments = new double[distanceSamples.Length - 1];

            double previousDistance = distanceSamples[0];
            for (int i = 1; i < distanceSamples.Length; ++i)
            {
                distanceSegments[i - 1] = distanceSamples[i] - previousDistance;

                previousDistance = distanceSamples[i];
            }

            return distanceSegments;
        }
    }
}

