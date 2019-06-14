using System;

namespace Hackerrank
{
    public class WaterContainer
    {
        public int MaxArea(int[] height) 
        {
            int MaxArea = 0;
            for(int i = 0; i < height.Length; i++)
            {
                for(int j = i + 1; j < height.Length ;  j++)
                {
                    MaxArea = Math.Max(MaxArea, Math.Min(height[j], height[i]) * (j- i)  );
                }
            }
            return MaxArea;
        }
    }
}