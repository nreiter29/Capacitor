namespace Capacitor.Models {
    public class Capacitor {
        /// <summary>
        /// Calculates Tau
        /// </summary>
        /// <param name="capacitance"></param>
        /// <param name="resistance"></param>
        /// <returns></returns>
        public static decimal CalculateTau(decimal capacitance, decimal resistance) => capacitance * resistance;

        /// <summary>
        /// Calculates the Capacitance
        /// </summary>
        /// <param name="tau"></param>
        /// <param name="resistance"></param>
        /// <returns></returns>
        public static decimal CalculateCapacitance(decimal tau, decimal resistance) => tau / resistance;

        /// <summary>
        /// Calculates the charging time from Tau
        /// </summary>
        /// <param name="resistance"></param>
        /// <param name="capacity"></param>
        /// <returns></returns>
        public static decimal CalculateTauChargingTime(decimal resistance, decimal capacity) => resistance * capacity * MaxTauLoadingTime;

        /// <summary>
        /// Calculates the unload time from Tau
        /// </summary>
        /// <param name="resistance"></param>
        /// <param name="capacity"></param>
        /// <returns></returns>
        public static decimal CalculateTauUnloadTime(decimal resistance, decimal capacity) => resistance * capacity * MaxTauLoadingTime;

        /// <summary>
        /// Calculates Resistance
        /// </summary>
        /// <param name="voltage"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        public static decimal CalculateResistance(decimal voltage, decimal current) => voltage / current;

        /// <summary>
        /// Calculates the voltage
        /// </summary>
        /// <param name="resistance"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        public static decimal CalculateVoltage(decimal resistance, decimal current) => resistance * current;

        /// <summary>
        /// Calculates the ampere
        /// </summary>
        /// <param name="voltage"></param>
        /// <param name="resistance"></param>
        /// <returns></returns>
        public static decimal CalculateAmpere(decimal voltage, decimal resistance) => voltage / resistance;

        /// <summary>
        /// Capacitor load and unload is every time 5 tau
        /// </summary>
        public static decimal MaxTauLoadingTime { get; } = 5;
    }
}