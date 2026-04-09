//using System;
//using System.Diagnostics;
//using System.Globalization;
//using System.Windows.Forms;

//namespace Ai_test
//{
//    public partial class Form1 : Form
//    {
//        public Form1()
//        {
//            InitializeComponent();
//        }

//        private void Form1_Load(object sender, EventArgs e)
//        {
//        }


//        // Unified method for both weekly and monthly forecasts
//        private void RunForecast(string modelType)
//        {
//            // ----------------------------
//            // 1. Python executable path
//            // ----------------------------
//            string pythonExe = @"C:\Users\DJ akhi\AppData\Local\Microsoft\WindowsApps\PythonSoftwareFoundation.Python.3.11_qbz5n2kfra8p0\python.exe";
//            string scriptPath = @"C:\Users\DJ akhi\Downloads\AiWinForms-20251011T181917Z-1-001\AiWinForms\Ai_test\Ai_test\forecast.py";
//            string dataPath = @"C:\Users\DJ akhi\Downloads\AiWinForms-20251011T181917Z-1-001\AiWinForms\Ai_test\Ai_test\sales.csv";

//            try
//            {
//                ProcessStartInfo checkPsi = new ProcessStartInfo
//                {
//                    FileName = pythonExe,
//                    Arguments = "-c \"import pandas; import prophet\"",
//                    UseShellExecute = false,
//                    RedirectStandardError = true,
//                    RedirectStandardOutput = true,
//                    CreateNoWindow = true
//                };

//                using (var checkProcess = Process.Start(checkPsi))
//                {
//                    string checkErrors = checkProcess.StandardError.ReadToEnd();
//                    checkProcess.WaitForExit();
//                    if (!string.IsNullOrEmpty(checkErrors))
//                    {
//                        MessageBox.Show("Python environment missing required packages:\n" + checkErrors,
//                                        "Python Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                        return;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Failed to check Python environment:\n" + ex.Message,
//                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            // ----------------------------
//            // 3. Run forecast.py
//            // ----------------------------
//            ProcessStartInfo psi = new ProcessStartInfo
//            {
//                FileName = pythonExe,
//                Arguments = $"\"{scriptPath}\" {modelType} \"{dataPath}\"",
//                UseShellExecute = false,
//                RedirectStandardOutput = true,
//                RedirectStandardError = true,
//                CreateNoWindow = true
//            };

//            try
//            {
//                using (var process = Process.Start(psi))
//                {
//                    string output = process.StandardOutput.ReadToEnd().Trim();
//                    string errors = process.StandardError.ReadToEnd();
//                    process.WaitForExit();

//                    if (!string.IsNullOrEmpty(errors))
//                    {
//                        MessageBox.Show("Python Error:\n" + errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                        return;
//                    }

//                    // ----------------------------
//                    // 4. Parse output
//                    // ----------------------------
//                    string[] parts = output.Split(',');
//                    if (parts.Length >= 4 &&
//                        double.TryParse(parts[0], NumberStyles.Any, CultureInfo.InvariantCulture, out double current) &&
//                        double.TryParse(parts[1], NumberStyles.Any, CultureInfo.InvariantCulture, out double avg) &&
//                        double.TryParse(parts[2], NumberStyles.Any, CultureInfo.InvariantCulture, out double best) &&
//                        double.TryParse(parts[3], NumberStyles.Any, CultureInfo.InvariantCulture, out double worst))
//                    {
//                        string message =
//                            $"Forecast Summary ({modelType.ToUpper()})\n\n" +
//                            $"• Current Total: {FormatCurrency(current)}\n" +
//                            $"• Predicted Average ({modelType}): {FormatCurrency(avg)}\n" +
//                            $"• Forecast Range: {FormatCurrency(worst)} — {FormatCurrency(best)}";

//                        MessageBox.Show(message, "Forecast Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    }
//                    else
//                    {
//                        MessageBox.Show("⚠️ Could not parse Python output:\n" + output, "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Failed to run Python forecast:\n" + ex.Message,
//                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        // ----------------------------
//        // Helper method: format currency
//        // ----------------------------
//        private string FormatCurrency(double sale)
//        {
//            return "₱" + sale.ToString("N0", CultureInfo.InvariantCulture);
//        }


//        // Button handlers
//        private void button1_Click(object sender, EventArgs e)
//        {
//            RunForecast("weekly");
//        }

//        private void button2_Click(object sender, EventArgs e)
//        {
//            RunForecast("monthly");
//        }
//    }
//}
