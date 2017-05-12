using System;

namespace Image_Processing_Lab_Clone
{
    internal class ExcelFileWriter<T>
    {
        public static implicit operator ExcelFileWriter<T>(ExcelWrite v)
        {
            throw new NotImplementedException();
        }
    }
}