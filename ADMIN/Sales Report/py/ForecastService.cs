using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sizzlingeropos.ADMIN.Sales_Report.py
{
    public class ForecastService
    {
        private readonly string pythonExe;
        private readonly string scriptPath;

        public ForecastService(string pythonExePath, string forecastScriptPath)
        {
            pythonExe = pythonExePath;
            scriptPath = forecastScriptPath;
        }

        /// <summary>
        /// Runs the Python forecast and returns a DataTable with results.
        /// </summary>
        /// <param name="modelType">"weekly" or "monthly"</param>
        /// <param name="csvPath">Path to CSV file with sales data</param>
        /// <returns>DataTable with forecast metrics</returns>
        public DataTable RunForecast(string modelType, string csvPath)
        {
            if (!File.Exists(csvPath))
                throw new FileNotFoundException("CSV file not found: " + csvPath);

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = pythonExe,
                Arguments = $"\"{scriptPath}\" {modelType} \"{csvPath}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            using (var process = Process.Start(psi))
            {
                string output = process.StandardOutput.ReadToEnd().Trim();
                string errors = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (!string.IsNullOrEmpty(errors))
                    MessageBox.Show("Python Error:\n" + errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                string[] parts = output.Split(',');
                if (parts.Length >= 4 &&
                    double.TryParse(parts[0], NumberStyles.Any, CultureInfo.InvariantCulture, out double current) &&
                    double.TryParse(parts[1], NumberStyles.Any, CultureInfo.InvariantCulture, out double avg) &&
                    double.TryParse(parts[2], NumberStyles.Any, CultureInfo.InvariantCulture, out double best) &&
                    double.TryParse(parts[3], NumberStyles.Any, CultureInfo.InvariantCulture, out double worst))
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Metric");
                    dt.Columns.Add("Value", typeof(double));

                    dt.Rows.Add("Current Total", current);
                    dt.Rows.Add("Predicted Average", avg);
                    dt.Rows.Add("Forecast Best", best);
                    dt.Rows.Add("Forecast Worst", worst);

                    return dt;
                }
                else
                {
                    MessageBox.Show("Could not parse Python output:\n" + output, "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
            }
        }
    }
}
