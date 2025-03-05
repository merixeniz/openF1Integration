using ApiIntegration.DTOs;

namespace ApiIntegration.Utils
{
    #region Guard Clauses
    public static class Guard
    {
        private static HashSet<int> f1DriverNumbers = new HashSet<int>
        {
            81, // Oscar Piastri (McLaren)
            4,  // Lando Norris (McLaren)
            16, // Charles Leclerc (Ferrari)
            44, // Lewis Hamilton (Ferrari)
            1,  // Max Verstappen (Red Bull Racing)
            30, // Liam Lawson (Red Bull Racing)
            63, // George Russell (Mercedes)
            12, // Andrea Kimi Antonelli (Mercedes)
            18, // Lance Stroll (Aston Martin)
            14, // Fernando Alonso (Aston Martin)
            10, // Pierre Gasly (Alpine)
            7,  // Jack Doohan (Alpine)
            31, // Esteban Ocon (Haas)
            87, // Oliver Bearman (Haas)
            6,  // Isack Hadjar (Racing Bulls)
            22, // Yuki Tsunoda (Racing Bulls)
            23, // Alexander Albon (Williams)
            55, // Carlos Sainz (Williams)
            27, // Nico Hülkenberg (Kick Sauber)
            5   // Gabriel Bortoleto (Kick Sauber)
        };
        public static void AgainstNullOrEmpty(string? input, string message)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException(message);
        }

        public static int AgainstIncorrectDriverNumber(string? driverInput)
        {
            if (!int.TryParse(driverInput, out int driverNumber) || !f1DriverNumbers.Contains(driverNumber))
                throw new ArgumentException("Incorrect driver's number.");

            return driverNumber;
        }

        public static void AgainstInvalidSessionKey(int sessionKey)
        {
            if (sessionKey == 0)
                throw new ArgumentException("No data for selected testing day.");
        }

        public static void AgainstNullOrEmptyLaps(IReadOnlyList<Lap>? laps)
        {
            if (laps == null || laps.Count == 0)
                throw new ArgumentException("No data for selected driver.");
        }
    }

    #endregion
}
