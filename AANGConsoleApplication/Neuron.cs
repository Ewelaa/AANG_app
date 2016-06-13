using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AANGConsoleApplication
{
    class Neuron
    {
        public float NeuronExcitatedValue { get; set; }
        public String Name { get; set; }
        List<Receptor> ListOfReceptors { get; set; }

        public void ConnectReceptor(Receptor receptor)
        {
            ListOfReceptors.Add(receptor);
        }

        public void StimulateReceptors()
        {
            foreach(Receptor receptor in ListOfReceptors)
            {
                receptor.ExcitedReceptorValue = 1;
                receptor.StimulateNeurons();
            }
        }

        public Neuron(String name)
        {
            this.Name = name;
        }

        public Neuron() { }
        
    }
}
