using DemoLegume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.ViewModels
{
    class LegumeModel
    {
        private readonly Legume _legume;
 
        
        public LegumeModel(Legume legume)
        {
            _legume = legume;
        }
        
        
        public int Id {
            get { return _legume.Id; }
        }

        public string Name
        {
            get { return _legume.Name; }
        }
        


    }
}
