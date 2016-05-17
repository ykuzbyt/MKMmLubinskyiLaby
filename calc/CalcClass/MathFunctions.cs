using System;

namespace CalcClass
{
    public class MathFunctions
    {

        /// <summary> 
        /// Останнє повідомлення про помилку. 
        /// Поле і властивість для нього 
        /// </summary> 
        private static string _lastError = String.Empty;

        public static string lastError
        {
            get { return _lastError; }
            set { _lastError = value; }
        }

        /// <summary> 
        /// Функція складання числа а і b 
        /// </summary> 
        /// <param name="a">доданок</param> 
        /// <param name="b">доданок</param> 
        /// <returns>сума</returns> 
        public static int Add(long a, long b)
        {
            try
            {
                if(CheckIfNumberIsInInt32Range(a,b)) throw new OverflowException();

                long result = a + b;
                return int.Parse(result.ToString());
            }
            catch (ArgumentException)
            {
                lastError = Constants.OverflowErrorText;
                throw new ApplicationException(lastError);
            }
            catch (OverflowException)
            {
                lastError = Constants.OverflowErrorText;
                throw new ApplicationException(lastError);
            }
        }

        /// <summary> 
        /// функція віднімання чисел а і b 
        /// </summary> 
        /// <param name="a">зменшуване</param> 
        /// <param name="b">від’ємне</param> 
        /// <returns>різниця</returns> 
        public static int Sub(long a, long b)
        {
            try
            {
                if (CheckIfNumberIsInInt32Range(a, b)) throw new OverflowException();

                long result = a - b;
                return int.Parse(result.ToString());
            }
            catch (ArgumentException)
            {
                lastError = Constants.OverflowErrorText;
                throw new ApplicationException(lastError);
            }
            catch (OverflowException)
            {
                lastError = Constants.OverflowErrorText;
                throw new ApplicationException(lastError);
            }
        }

        /// <summary> 
        /// функція множення чисел а і b 
        /// </summary> 
        /// <param name="a">множник</param> 
        /// <param name="b">множник</param> 
        /// <returns>добуток</returns> 
        public static int Mult(long a, long b)
        {
            try
            {
                if (CheckIfNumberIsInInt32Range(a, b)) throw new OverflowException();

                long result = a * b;
                return int.Parse(result.ToString());
            }
            catch (ArgumentException)
            {
                lastError = Constants.OverflowErrorText;
                throw new ApplicationException(lastError);
            }
            catch (OverflowException)
            {
                lastError = Constants.OverflowErrorText;
                throw new ApplicationException(lastError);
            }
        }

        /// <summary> 
        /// функція знаходження частки 
        /// </summary> 
        /// <param name="a">ділене</param> 
        /// <param name="b">дільник</param> 
        /// <returns>частка</returns> 
        public static int Div(long a, long b)
        {
            try
            {
                if (CheckIfNumberIsInInt32Range(a, b)) throw new OverflowException();
                if (a == 0)
                    throw new ApplicationException(Constants.DividingOnNullErrorText);

                long result = b/a;
                return int.Parse(result.ToString());
            }
            catch (ArgumentException)
            {
                lastError = Constants.OverflowErrorText;
                throw new ApplicationException(lastError);
            }
            catch (OverflowException)
            {
                lastError = Constants.OverflowErrorText;
                throw new ApplicationException(lastError);
            }
            catch (ApplicationException ex)
            {
                lastError = ex.Message;
                throw new ApplicationException(lastError);
            }
        }

        /// <summary> 
        /// функція ділення по модулю 
        /// </summary> 
        /// <param name="a">ділене</param> 
        /// <param name="b">дільник</param> 
        /// <returns>остача</returns> 
        public static int Mod(long a, long b)
        {
            try
            {
                if (CheckIfNumberIsInInt32Range(a, b)) throw new OverflowException();
                if (b == 0)
                    throw new ApplicationException(Constants.DividingOnNullErrorText);

                long result = Math.Abs(a / b);
                return int.Parse(result.ToString());
            }
            catch (ArgumentException)
            {
                lastError = Constants.OverflowErrorText;
                throw new ApplicationException(lastError);
            }
            catch (OverflowException)
            {
                lastError = Constants.OverflowErrorText;
                throw new ApplicationException(lastError);
            }
            catch (ApplicationException ex)
            {
                lastError = ex.Message;
                throw new ApplicationException(lastError);
            }
        }
        /// <summary> 
        /// унарний плюс  
        /// </summary> 
        /// <param name="a"></param> 
        /// <returns></returns> 
        public static int ABS(long a)
        {
            try
            {
                if (CheckIfNumberIsInInt32Range(a)) throw new OverflowException();

                long result = Math.Abs(a);
                return int.Parse(result.ToString());
            }
            catch (ArgumentException)
            {
                lastError = Constants.OverflowErrorText;
                throw new ApplicationException(lastError);
            }
            catch (OverflowException)
            {
                lastError = Constants.OverflowErrorText;
                throw new ApplicationException(lastError);
            }
        }
        /// <summary> 
        /// унарний мінус  
        /// </summary> 
        /// <param name="a"></param> 
        /// <returns></returns> 
        public static int IABS(long a)
        {
            try
            {
                if (CheckIfNumberIsInInt32Range(a)) throw new OverflowException();

                long result = -1 * Math.Abs(a);
                return int.Parse(result.ToString());
            }
            catch (ArgumentException)
            {
                lastError = Constants.OverflowErrorText;
                throw new ApplicationException(lastError);
            }
            catch (OverflowException)
            {
                lastError = Constants.OverflowErrorText;
                throw new ApplicationException(lastError);
            }
        }

        private static bool CheckIfNumberIsInInt32Range(long a)
        {
            return a < Int32.MinValue || a > Int32.MaxValue;
        }

        private static bool CheckIfNumberIsInInt32Range(long a, long b)
        {
            return CheckIfNumberIsInInt32Range(a) && CheckIfNumberIsInInt32Range(b);
        }
    }
}
