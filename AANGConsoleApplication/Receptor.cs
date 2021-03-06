﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AANGConsoleApplication
{
    class Receptor
    {
        public double ReceptorValue { get; set; }
        public double ExcitedReceptorValue { get; set; }
        public String Text { get; set; }
        public List<Neuron> ListOfNeurons { get; set; }


        public void ConnectNeuron(Neuron neuron)
        {
            ListOfNeurons = new List<Neuron>();
            ListOfNeurons.Add(neuron);
        }

        public void StimulateNeurons()
        {
           if (ExcitedReceptorValue >= 1)
            {
                foreach(Neuron neuron in ListOfNeurons)
                {
                    neuron.NeuronExcitatedValue += 1;
                }
            }
        }

        public void CalculateExcitation(double value, double interval)
        {
            this.ExcitedReceptorValue = 1 - Math.Abs(ReceptorValue - value) / interval;
        }

        public void CalculateExcitation(String text)
        {
            if (Text == text)
            {
                ExcitedReceptorValue = 1;
            }
        }

        public Receptor(double receptorValue)
        {
            this.ReceptorValue = receptorValue;
        }
        public Receptor(String text)
        {
            this.Text = text;
        }
        public Receptor(){}
    }
}


