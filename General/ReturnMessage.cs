using System;

namespace UniversitasApp.General
{
    public class ReturnMessage
    {
        /// <summary>
        /// Error Code
        /// </summary>
        public int Code = 0;

        /// <summary>
        /// Error Message
        /// </summary>
        public string Message = string.Empty;

        /// <summary>
        /// Menentukan apakah Error dari system atau bukan
        /// </summary>
        /// <param name="Exception">ex</param>
        public void Error(Exception ex)
        {
            if (ex.InnerException == null)
            {
                Code = -1;
                Message = ex.Message;
            }
            else
            {
                Code = 0;
                Message = ex.InnerException.Message;
            }
        }
    }
}