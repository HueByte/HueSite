using HueSite.Data.IServices.ISortingAlg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HueSite.Data.Services.SortingAlg
{
    public class Sorting : ISorting
    {
        public Sorting() { }

        public int[] BubbleSort(int[] arr)
        {
            int n = arr.Length;

            /*for(int x = 0; x <= n; x++)
            {
                for(int z = 0; z <= n - x; z++)
                    if(array[z] > array[z + 1])
                    {
                        int temp = array[z];
                        array[z + 1] = array[z];
                        array[z] = temp;
                    }
            }*/


            /*for(int x = 0; x < n - 1; x++)
            {
                for(int i = 0; i < n - i - 1; i++)
                {
                    if(arr[i] > arr[i+1])
                    {
                        int temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                    }
                }
            }

            return arr;*/


            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        // swap temp and arr[i] 
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }

            return arr;
        }
    }
}
