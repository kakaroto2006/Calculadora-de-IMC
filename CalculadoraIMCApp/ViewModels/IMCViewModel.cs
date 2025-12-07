using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CalculadoraIMCApp.Models;
using System;

namespace CalculadoraIMCApp.ViewModels
{
    public partial class IMCViewModel : ObservableObject
    {
        private readonly IMCData model = new IMCData();

        [ObservableProperty]
        double weightKg;

        [ObservableProperty]
        double heightMeters;

        [ObservableProperty]
        double imc;

        [ObservableProperty]
        string range = string.Empty;

        public IMCViewModel()
        {
            // default values (optional)
            WeightKg = 70;
            HeightMeters = 1.75;
            CalculateIMC();
        }

        [RelayCommand]
        void CalculateIMC()
        {
            // basic validation
            if (HeightMeters <= 0 || WeightKg <= 0)
            {
                Imc = 0;
                Range = "Ingrese peso y altura válidos";
                return;
            }

            // Save to model
            model.WeightKg = WeightKg;
            model.HeightMeters = HeightMeters;

            var imcValue = model.WeightKg / (model.HeightMeters * model.HeightMeters);
            Imc = Math.Round(imcValue, 2);

            // Determine range
            if (Imc < 18.5)
                Range = "Bajo peso (delgadez)"; 
            else if (Imc < 25)
                Range = "Normal (peso saludable)";
            else if (Imc < 30)
                Range = "Sobrepeso";
            else
                Range = "Obesidad";
        }

        [RelayCommand]
        void Clear()
        {
            WeightKg = 0;
            HeightMeters = 0;
            Imc = 0;
            Range = string.Empty;
        }
    }
}
