public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        //Keep the given starting number.
        
        //Create an empty output array using the given length.
        double[] output = new double[length];
        //Start the position at index 0.
        int position = 0;
        //Continue while the position is smaller than the length.
        while (position < length)
        {
            //Calculate the multiple.
            output[position] = number * (position + 1);
            //Increase the position by 1.
            position++;
        }
        //Return the output array.
        return output;
    }
    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        //Preserve the original list so its values remain available.

        //Calculate the split position with data.Count - amount.
        int splitPosition = data.Count - amount;
        //Copy the original tail into a new result, in order.
        List<int> result = new List<int>(data.GetRange(splitPosition, amount));
        //Copy the original head into the same result, in order.
        result.AddRange(data.GetRange(0, splitPosition));
        //Replace the original data contents with the result.
        data.Clear();
        data.AddRange(result);
    }
}
