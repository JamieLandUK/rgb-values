using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rgb_values
{
    class Program
    {
        static string RGBCalculator (string r, string g, string b)
        {
            int r_dec;
            int g_dec;
            int b_dec;
            // mc = Monochrome
            string mc_colour;
            Console.Write("Please enter a threshold for the monochrome colour decision. (0 to 1) ");
            double mc_threshold = Convert.ToDouble(Console.ReadLine());

            // Converted by int32's hex function.
            r_dec = Convert.ToInt32(r, 16);
            g_dec = Convert.ToInt32(g, 16);
            b_dec = Convert.ToInt32(b, 16);
            double rgb_average = (r_dec + g_dec + b_dec) / 3;

            /* If it is above the average (midpoint as 127.5),
             * it is a white colour, else it is a black colour.
             */
            mc_colour = rgb_average >= (255 * mc_threshold) ? "white" : "black";

            /* The invert of a colour is it's values taken away from white
             * #FFFFFF = (255, 255, 255)
             */
            int r_inv = 255 - r_dec;
            int g_inv = 255 - g_dec;
            int b_inv = 255 - b_dec;

            // Multiline return
            return 
                $"#{r+g+b} : ({r_dec}, {g_dec}, {b_dec}). It is a {mc_colour} colour.\n" +
                $"The inverted RGB value for this is: ({r_inv}, {g_inv}, {b_inv})";
        }

        static void Main(string[] args)
        {
        /* Using goto labels because I don't need to worry about changing args
         * And it is more concise to call to a label
         */
        start:
            Console.Write("Please write your RGB Hex value to translate: #");
            string rgbvalue = Console.ReadLine();
            string r_value;
            string g_value;
            string b_value;
            char[] hexadecimal_values = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

            foreach (var number in rgbvalue)
            {
                if (!hexadecimal_values.Contains(number))
                {
                    Console.WriteLine("That is not a correct hexadecimal value.");
                    Console.WriteLine();
                    goto start;
                }
            }

            // Make sure that it is actually the length of an RGB colour code
            if (rgbvalue.Length > 6 || rgbvalue.Length < 6)
            {
                // Restart the code as an error catch.
                Console.WriteLine("Please write 6 characters.");
                Console.WriteLine();
                goto start;
            }
            else
            {
                // Get the first two characters of the string.
                r_value = rgbvalue.Substring(0, 2);
                // Middle two.
                g_value = rgbvalue.Substring(2, 2);
                // Last two.
                b_value = rgbvalue.Substring(4, 2);
            }

            Console.WriteLine(RGBCalculator(r_value, g_value, b_value));
            Console.WriteLine();
            goto start;
        }
    }
}
