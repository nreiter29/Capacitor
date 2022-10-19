using System;
using System.Text.RegularExpressions;
using Capacitor.Models;

namespace Capacitor.Console {
    internal class Program {
        /// <summary>
        /// The entry point. Asks the user for input and calculates the values.
        /// </summary>
        public static void Main() {
            double C = 0;
            double R = 0;
            double U = 0;
            double I = 0;
            double T = 0;
            double t = 0;
            string input = "";

            input = GetInput("Capacitance (F)");
            C = ConvertInput(input);

            input = GetInput("Resistance (Ω)");
            R = ConvertInput(input);

            input = GetInput("Voltage (V)");
            U = ConvertInput(input);

            input = GetInput("Current (A)");
            I = ConvertInput(input);

            input = GetInput("Tau (s)");
            T = ConvertInput(input);

            System.Console.WriteLine("\n");
            System.Console.WriteLine("Tau: {0}", Models.Capacitor.CalculateTau(Convert.ToDecimal(C), Convert.ToDecimal(R)));
            System.Console.WriteLine("Capacitance: {0}", Models.Capacitor.CalculateCapacitance(Convert.ToDecimal(T), Convert.ToDecimal(R)));
            System.Console.WriteLine("Tau Charging Time: {0}", Models.Capacitor.CalculateTauChargingTime(Convert.ToDecimal(R), Convert.ToDecimal(C)));
            System.Console.WriteLine("Tau Discharging Time: {0}", Models.Capacitor.CalculateTauUnloadTime(Convert.ToDecimal(R), Convert.ToDecimal(C)));
            System.Console.WriteLine("Resistance: {0}", Models.Capacitor.CalculateResistance(Convert.ToDecimal(U), Convert.ToDecimal(I)));
            System.Console.WriteLine("Voltage: {0}", Models.Capacitor.CalculateVoltage(Convert.ToDecimal(R), Convert.ToDecimal(I)));
        }

        /// <summary>
        ///  Asks the user for input.
        /// </summary>
        /// <param name="label">
        ///  The label of the value.
        /// </param>
        /// <returns>
        ///  The input.
        /// </returns>
        private static string GetInput(string label) {
            System.Console.Write(label + ": ");
            return System.Console.ReadLine() ?? "";
        }

        /// <summary>
        ///  Calculates the value of the user input such as milli, micro, nano, pico, etc.
        /// </summary>
        /// <param name="input">
        ///  The user input.
        /// </param>
        /// <returns>
        ///  The converted value.
        /// </returns>
        private static double ConvertInput(string input) {
            if(input == "") {
                return 0;
            }

            string prefix = input.Substring(input.Length - 1);

            if(Regex.IsMatch(prefix, @"^\d+$")) {
                return Convert.ToDouble(input);
            }

            input = input.Substring(0, input.Length - 1);
            double value = Convert.ToDouble(input);

            return prefix switch {
                "p" => value * 1e-12,
                "n" => value * 1e-9,
                "u" => value * 1e-6,
                "m" => value * 1e-3,
                "k" => value * 1e3,
                "M" => value * 1e6,
                "G" => value * 1e9,
                "T" => value * 1e12,
                _ => throw new Exception("Invalid prefix.")
            };
        }
    }
}