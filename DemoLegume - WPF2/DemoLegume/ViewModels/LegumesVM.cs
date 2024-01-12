using DemoLegume.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.ViewModels
{
    class LegumesVM
    {
        private List<LegumeModel> _legumesList;
        private PotagerContext context = new PotagerContext();


        public List<LegumeModel> LegumesList {
            get {
                //if (_legumesList == null) _legumesList = loadLegumes2();
                //return _legumesList;
                return _legumesList = _legumesList ?? loadLegumes2();
            }
        }


       /* private List<LegumeModel> loadLegumes2()
        {
            List<Legume> localCollection = new List<Legume>();
            foreach (var item in context.Legumes)
            {
                localCollection.Add(item);

            }

            return localCollection;

        } */
         

        private List<LegumeModel> loadLegumes2()
        {
            List<LegumeModel> localCollection = new List<LegumeModel>();
            foreach (var item in context.Legumes)
            {
                localCollection.Add(new LegumeModel(item));

            }

            return localCollection;

        }


      
    }
}
