using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AANGConsoleApplication
{
    class SensoryField
    {
        public String Name { get; set; }
        public float Interval { get; set; }
        public Receptor Max { get; set; }
        public Receptor Min { get; set; }
        public List<Receptor> ListOfReceptors { get; set; }
        public Receptor AddReceptor(float interval)
        {
            ListOfReceptors = new List<Receptor>();
            Max = new Receptor();
            Min = new Receptor();

            if (ListOfReceptors.Count == 0)
            {
                Max.ReceptorValue = interval;
                Min.ReceptorValue = interval;
                Interval = Max.ReceptorValue;
            }
            else
            {
                if (Interval > Max.ReceptorValue)
                {
                    Max.ReceptorValue = interval;
                    Interval = Max.ReceptorValue - Min.ReceptorValue;
                }
                else if (Interval < Min.ReceptorValue)
                {
                    Min.ReceptorValue = interval;
                    Interval = Max.ReceptorValue - Min.ReceptorValue;
                }
            }
            foreach (Receptor receptor in ListOfReceptors)
            {
                if(receptor.ReceptorValue == interval)
                {
                    return receptor;
                }
            }
            Receptor newReceptor = new Receptor(interval);
            ListOfReceptors.Add(newReceptor);
            return newReceptor; 
        }
        public Receptor AddReceptor(String name)
        {
            foreach(Receptor receptor in ListOfReceptors)
            {
                if (receptor.Text == name)
                {
                    return receptor;
                }
            }

            Receptor newReceptor = new Receptor(name);
            ListOfReceptors.Add(newReceptor);
            return newReceptor;
        }
        public void StimulateReceptor(float value)
        {
            if(Interval > 0)
            {
                Min.ExcitedReceptorValue = (Max.ReceptorValue - value)/ Interval;
                Max.ExcitedReceptorValue = (value - Min.ReceptorValue) / Interval;
            }
            else if (Interval == 0)
            {
                Min.ExcitedReceptorValue = 0;
                Max.ExcitedReceptorValue = 0;
            }

            foreach (Receptor receptor in ListOfReceptors)
            {
                receptor.CalculateExcitation(value, Interval);
                receptor.StimulateNeurons();
            }
        }
        public void StimulateReceptor(String name)
        {
            foreach (Receptor receptor in ListOfReceptors)
            {
                receptor.CalculateExcitation(name);
                receptor.StimulateNeurons();
            }
        }

        public float getMaximum()
        {
            return Max.ReceptorValue;
        }

        public float getMinimum()
        {
            return Min.ReceptorValue;
        }

        public SensoryField()
        {
            this.Name = "";
        }
        public SensoryField(string name)
        {
            this.Name = Name;
        }
        public void Write()
        {
            Console.WriteLine(Name);
            Console.ReadLine();
        }

    }
}
