using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ExamTwoCodeQuestions.Data
{
    public class Cobbler : IOrderItem, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;


        private FruitFilling filling; // private backing variable.
        /// <summary>
        /// The fruit used in the cobbler
        /// </summary>
        public FruitFilling Fruit 
        { 
            get
            {
                return filling;
            }
            set 
            {
                filling = value;
                NotifyThatPropertyChanged("Fruit");
            } 
        }


        private bool ificecream = true; //private backing variable
        /// <summary>
        /// If the cobbler is served with ice cream
        /// </summary>
        public bool WithIceCream 
        { 
            get
            {
                return ificecream;
            }
            set
            {
                ificecream = value;
                NotifyThatPropertyChanged("Price");
                NotifyThatPropertyChanged("WithIceCream");
                NotifyThatPropertyChanged("SpecialInstructions");
            }
        }

        /// <summary>
        /// Gets the price of the Cobbler
        /// </summary>
        public double Price
        {
            get
            {
                if (WithIceCream) return 5.32;
                else return 4.25;
            }
        }

        /// <summary>
        /// Gets any special instructions for preparing this dessert
        /// Since special instructinos change if there if it is with ice cream, we have to notify that this property has changed.
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                if(WithIceCream) { return new List<string>(); }
                else { return new List<string>() { "Hold Ice Cream" }; }
            }
        }


        /// <summary>
        /// Notifies that the property has changed.
        /// Exactly like in cowboy cafe.
        /// </summary>
        /// <param name="property"></param>
        private void NotifyThatPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
