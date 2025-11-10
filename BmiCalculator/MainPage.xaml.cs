namespace BmiCalculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnInputChanged(object? sender, TextChangedEventArgs e)
        {
            // Hide results when user changes input
            ResultFrame.IsVisible = false;
        }

        private void OnCalculateClicked(object? sender, EventArgs e)
        {
            // Hide keyboard
            WeightEntry.IsEnabled = false;
            HeightEntry.IsEnabled = false;
            WeightEntry.IsEnabled = true;
            HeightEntry.IsEnabled = true;
            // Validate inputs
            if (!double.TryParse(WeightEntry.Text, out double weight) || weight <= 0)
            {
                DisplayAlert("Invalid Input", "Please enter a valid weight in kilograms.", "OK");
                return;
            }

            if (!double.TryParse(HeightEntry.Text, out double heightCm) || heightCm <= 0)
            {
                DisplayAlert("Invalid Input", "Please enter a valid height in centimeters.", "OK");
                return;
            }

            // Convert height from cm to meters
            double heightM = heightCm / 100.0;

            // Calculate BMI
            double bmi = weight / (heightM * heightM);

            // Determine BMI category and description
            string category;
            string description;
            Color categoryColor;

            if (bmi < 18.5)
            {
                category = "Underweight";
                description = "You may need to gain weight. Consult with a healthcare provider for personalized advice.";
                categoryColor = Color.FromArgb("#F59E0B"); // Modern amber/warning color
            }
            else if (bmi >= 18.5 && bmi < 25)
            {
                category = "Normal Weight";
                description = "You have a healthy weight. Keep up the good work with a balanced diet and regular exercise.";
                categoryColor = Color.FromArgb("#10B981"); // Modern green/success color
            }
            else if (bmi >= 25 && bmi < 30)
            {
                category = "Overweight";
                description = "You may benefit from losing some weight. Consider a healthy diet and increased physical activity.";
                categoryColor = Color.FromArgb("#F59E0B"); // Modern amber/warning color
            }
            else
            {
                category = "Obesity";
                description = "Your health may be at risk. Please consult with a healthcare provider for guidance.";
                categoryColor = Color.FromArgb("#EF4444"); // Modern red/danger color
            }

            // Display results
            BmiValueLabel.Text = bmi.ToString("F1");
            BmiCategoryLabel.Text = category;
            BmiCategoryLabel.TextColor = categoryColor;
            BmiDescriptionLabel.Text = description;
            ResultFrame.IsVisible = true;

            // Announce result for accessibility
            SemanticScreenReader.Announce($"Your BMI is {bmi:F1}, which is classified as {category}");
        }
    }
}
