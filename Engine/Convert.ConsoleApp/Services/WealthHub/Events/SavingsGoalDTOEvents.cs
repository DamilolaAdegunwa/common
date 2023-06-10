using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace ExerciseApp.ConsoleApp.Services.WealthHub.Events
{
    public class SavingsGoalDTO : INotifyPropertyChanged
    {
        private bool isTargetReached;
        private bool hasCustomerMadeAnyPayment;

        public bool IsTargetReached
        {
            get { return isTargetReached; }
            set
            {
                if (value != isTargetReached)
                {
                    isTargetReached = value;
                    OnPropertyChanged(nameof(IsTargetReached));
                }
            }
        }

        public bool HasCustomerMadeAnyPayment
        {
            get { return hasCustomerMadeAnyPayment; }
            set
            {
                if (value != hasCustomerMadeAnyPayment)
                {
                    hasCustomerMadeAnyPayment = value;
                    OnPropertyChanged(nameof(HasCustomerMadeAnyPayment));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Program_SavingsGoalDTO
    {
        public static void Main_SavingsGoalDTO()
        {
            SavingsGoalDTO savingsGoal = new SavingsGoalDTO();
            savingsGoal.PropertyChanged += SavingsGoal_PropertyChanged;

            Console.WriteLine("Enter 'true' or 'false' to update the IsTargetReached property:");
            while (true)
            {
                string input = Console.ReadLine();
                if (bool.TryParse(input, out bool value))
                {
                    savingsGoal.IsTargetReached = value;
                }
                else
                {
                    Console.WriteLine("Invalid input. Enter 'true' or 'false'.");
                }
            }
        }

        private static void SavingsGoal_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SavingsGoalDTO.IsTargetReached))
            {
                SavingsGoalDTO savingsGoal = (SavingsGoalDTO)sender;
                Console.WriteLine($"IsTargetReached changed to: {savingsGoal.IsTargetReached}");
            }
            if (e.PropertyName == nameof(SavingsGoalDTO.HasCustomerMadeAnyPayment))
            {
                SavingsGoalDTO savingsGoal = (SavingsGoalDTO)sender;
                Console.WriteLine($"HasCustomerMadeAnyPayment changed to: {savingsGoal.HasCustomerMadeAnyPayment}");
            }
        }
    }

    //internal class SavingsGoalDTOEvents
    //{
    //}
}
