namespace MauiApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }
    
    private void OnShowResultClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameEntry.Text))
        {
            ResultLabel.Text = "Ошибка: Поле 'Имя' надо заполнить";
            ResultLabel.TextColor = Colors.Red;
            return;
        }

        if (string.IsNullOrWhiteSpace(EmailEntry.Text) || !EmailEntry.Text.Contains("@"))
        {
            ResultLabel.Text = "Ошибка: Введите корректный Email!";
            ResultLabel.TextColor = Colors.Red;
            return;
        }
        
        var selectedRadio = "Unknown";
        if (JuniorRadio.IsChecked)
        {
            selectedRadio = "Junior";
        }
        else if (MiddleRadio.IsChecked)
        {
            selectedRadio = "Middle";
        }
        else if (SeniorRadio.IsChecked)
        {
            selectedRadio = "Senior";
        }
        
        
        ResultLabel.TextColor = Colors.Black;
        ResultLabel.Text = $"Результаты анкеты\n" +
                           $"Имя: {NameEntry.Text}\n" +
                           $"Email: {EmailEntry.Text}\n" +
                           $"О себе: {BioEditor.Text}\n" +
                           $"Язык: {LanguagePicker.SelectedItem}\n" +
                           $"Уровень: {selectedRadio}\n" +
                           $"Удаленка: {(RemoteCheckBox.IsChecked ? "Да" : "Нет")}\n" +
                           $"Релокация: {(RelocateCheckBox.IsChecked ? "Да" : "Нет")}\n" +
                           $"Уведомления: {(NotifySwitch.IsToggled ? "Вкл" : "Выкл")}\n" +
                           $"Дата рождения: {BirthDatePicker.Date:dd.MM.yyyy}\n" +
                           $"Стаж: {ExpSlider.Value:F0} лет";
    }
    
    private void OnClearClicked(object sender, EventArgs e)
    {
        NameEntry.Text = string.Empty;
        EmailEntry.Text = string.Empty;
        BioEditor.Text = string.Empty;
        LanguagePicker.SelectedItem = null;
        
        var radios = LogicalChildren.OfType<RadioButton>().ToList();
        foreach (var radio in radios) radio.IsChecked = false;
        
        RemoteCheckBox.IsChecked = false;
        RelocateCheckBox.IsChecked = false;
        NotifySwitch.IsToggled = false;
        
        BirthDatePicker.Date = new DateTime(2000, 1, 1);
        ExpSlider.Value = 5;
        
        ResultLabel.Text = string.Empty;
    }
}